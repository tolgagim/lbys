using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Server.Application.Common.Exceptions;
using Server.Application.Common.Mailing;
using Server.Application.Identity.Users;
using Server.Domain.Common;
using Server.Domain.Identity;
using Server.Infrastructure.Constants;
using Server.Shared.Authorization;
using System.Globalization;
using System.Security.Claims;
using System.Threading;

namespace Server.Infrastructure.Identity;
internal partial class UserService
{
    /// <summary>
    /// This is used when authenticating with AzureAd.
    /// The local user is retrieved using the objectidentifier claim present in the ClaimsPrincipal.
    /// If no such claim is found, an InternalServerException is thrown.
    /// If no user is found with that ObjectId, a new one is created and populated with the values from the ClaimsPrincipal.
    /// If a role claim is present in the principal, and the user is not yet in that roll, then the user is added to that role.
    /// </summary>
    public async Task<string> GetOrCreateFromPrincipalAsync(ClaimsPrincipal principal)
    {
        string? objectId = principal.GetObjectId();
        if (string.IsNullOrWhiteSpace(objectId))
        {
            throw new InternalServerException(_t[MessageConstants.InvalidObjectId]);
        }

        var user = await _userManager.Users.Where(u => u.ObjectId == objectId).FirstOrDefaultAsync()
            ?? await CreateOrUpdateFromPrincipalAsync(principal);

        if (principal.FindFirstValue(ClaimTypes.Role) is string role &&
            await _roleManager.RoleExistsAsync(role) &&
            !await _userManager.IsInRoleAsync(user, role))
        {
            await _userManager.AddToRoleAsync(user, role);
        }

        return user.Id;
    }

    private async Task<ApplicationUser> CreateOrUpdateFromPrincipalAsync(ClaimsPrincipal principal)
    {
        string? email = principal.FindFirstValue(ClaimTypes.Upn);
        string? username = principal.GetDisplayName();
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username))
        {
            throw new InternalServerException(string.Format(_t[MessageConstants.UsernameOrEmailNotValid]));
        }

        var user = await _userManager.FindByNameAsync(username);
        if (user is not null && !string.IsNullOrWhiteSpace(user.ObjectId))
        {
            throw new InternalServerException(string.Format(_t["Username {0} is already taken."], username));
        }

        if (user is null)
        {
            user = await _userManager.FindByEmailAsync(email);
            if (user is not null && !string.IsNullOrWhiteSpace(user.ObjectId))
            {
                throw new InternalServerException(string.Format(_t["Email {0} is already taken."], email));
            }
        }

        IdentityResult? result;
        if (user is not null)
        {
            user.ObjectId = principal.GetObjectId();
            result = await _userManager.UpdateAsync(user);

            await _events.PublishAsync(new ApplicationUserUpdatedEvent(user.Id));
        }
        else
        {
            user = new ApplicationUser
            {
                ObjectId = principal.GetObjectId(),
                FirstName = principal.FindFirstValue(ClaimTypes.GivenName),
                LastName = principal.FindFirstValue(ClaimTypes.Surname),
                Email = email,
                NormalizedEmail = email.ToUpperInvariant(),
                UserName = username,
                NormalizedUserName = username.ToUpperInvariant(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                IsActive = true
            };
            result = await _userManager.CreateAsync(user);

            await _events.PublishAsync(new ApplicationUserCreatedEvent(user.Id));
        }

        if (!result.Succeeded)
        {
            throw new InternalServerException(_t[MessageConstants.ValidationErrorsOccurred], result.GetErrors(_t));
        }

        return user;
    }

    public async Task<string> CreateAsync(CreateUserRequest request, string origin)
    {
        // burada frontend de user kaydında user ait id gönderiliyor başka user kaydeden admin user
        // bu yüzden id den customer id alıyorum
        // bunu customer oluşuran andpoint ekleme yapınca direk customer id gönderiyor
        var userCheck = await _userManager.Users
        .AsNoTracking()
          .Where(u => u.Id == request.CustomerId.ToString())
          .FirstOrDefaultAsync();
        if (userCheck != null)
        {
            request.CustomerId = userCheck.CustomerId;
        }

        string newCode=string.Empty;
        string year = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
        var lastUser = await _userManager.Users
        .AsNoTracking().OrderByDescending(u => u.EntCode).Take(1)
          .FirstOrDefaultAsync();
        if (lastUser != null && lastUser.EntCode.Length == 15 && lastUser.EntCode.StartsWith($"U{year}"))
        {
            long lastNumber = long.Parse(lastUser.EntCode.Substring(5)); // C ve yıl kısmını çıkar
            newCode = $"U{year}{(lastNumber + 1).ToString().PadLeft(10, '0')}"; // C, yıl ve numarayı birleştir
        }

        var user = new ApplicationUser
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            PhoneNumber = request.PhoneNumber,
            IsActive = true,
            EmailConfirmed = true,
            CustomerId = request.CustomerId,
            Admin = request.Admin,
            EntCode = newCode
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            throw new InternalServerException("Users." + result.Errors.LastOrDefault().Code, result.GetErrors(_t));
        }

        if (request.Admin)
        {
            await _userManager.AddToRoleAsync(user, FSHRoles.CustomerAdmin);
        }

        if (request.CustomerId == null)
        {
            await _userManager.AddToRoleAsync(user, FSHRoles.Basic);
        }



        var messages = new List<string> { string.Format(_t["User {0} Registered."], user.UserName) };

        if (_securitySettings.RequireConfirmedAccount && !string.IsNullOrEmpty(user.Email))
        {
            // send verification email
            string emailVerificationUri = await GetEmailVerificationUriAsync(user, origin);
            RegisterUserEmailModel eMailModel = new RegisterUserEmailModel()
            {
                Email = user.Email,
                UserName = user.UserName,
                Url = emailVerificationUri
            };
            var mailRequest = new MailRequest(
                new List<string> { user.Email },
                _t[MessageConstants.ConfirmRegistration],
                _templateService.GenerateEmailTemplate("email-confirmation", eMailModel));
            _jobService.Enqueue(() => _mailService.SendAsync(mailRequest, CancellationToken.None));
            messages.Add(_t[$"Please check {user.Email} to verify your account!"]);
        }

        await _events.PublishAsync(new ApplicationUserCreatedEvent(user.Id));

        return string.Join(Environment.NewLine, messages);
    }
    public async Task UpdateAsync(UpdateUserRequest request, string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        _ = user ?? throw new NotFoundException(_t[MessageConstants.UserNotFound]);

        string currentImage = user.ImageUrl ?? string.Empty;

        if (request.Image != null || request.DeleteCurrentImage)
        {
            user.ImageUrl = await _fileStorage.UploadAsync<ApplicationUser>(request.Image, FileType.Image);
            if (request.DeleteCurrentImage && !string.IsNullOrEmpty(currentImage))
            {
                string root = Directory.GetCurrentDirectory();
                _fileStorage.Remove(Path.Combine(root, currentImage));
            }
        }

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.BirthDate = request.BirthDate;

        string? currentPhoneNumber = await _userManager.GetPhoneNumberAsync(user);

        if (request.PhoneNumber != currentPhoneNumber)
        {
            // Aynı telefon numarasına sahip başka bir kullanıcı olup olmadığını kontrol et
            var userWithSamePhoneNumber = await _userManager.Users
                .FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber && u.Id != userId);

            // Eğer aynı telefon numarasına sahip başka bir kullanıcı varsa hata döndür
            if (userWithSamePhoneNumber != null)
            {
                var failedResult = IdentityResult.Failed(new IdentityError { Description = MessageConstants.PhoneAlreadyUse });
                throw new InternalServerException(_t[MessageConstants.UserErrorDescription], failedResult.GetErrors(_t));
            }

            // Telefon numarasını güncelle
            await _userManager.SetPhoneNumberAsync(user, request.PhoneNumber);
        }

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            throw new InternalServerException(_t[MessageConstants.UpdateProfileFailed], result.GetErrors(_t));
        }

        await _signInManager.RefreshSignInAsync(user);
        await _events.PublishAsync(new ApplicationUserUpdatedEvent(user.Id));
    }

    public async Task DeleteAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        _ = user ?? throw new NotFoundException(_t[MessageConstants.UserNotFound]);

        if (user.Admin)
        {
            var failedResult = IdentityResult.Failed(new IdentityError { Description = MessageConstants.ErrorAdminAccount });
            throw new InternalServerException(_t[MessageConstants.UserErrorDescription], failedResult.GetErrors(_t));
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            throw new InternalServerException(_t[MessageConstants.DeleteProfileFailed], result.GetErrors(_t));
        }

        await _signInManager.RefreshSignInAsync(user);
        await _events.PublishAsync(new ApplicationUserUpdatedEvent(user.Id));
    }

}

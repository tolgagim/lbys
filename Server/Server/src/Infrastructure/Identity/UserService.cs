using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using DocumentFormat.OpenXml.Spreadsheet;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Server.Application.Common.Caching;
using Server.Application.Common.Events;
using Server.Application.Common.Exceptions;
using Server.Application.Common.FileStorage;
using Server.Application.Common.Interfaces;
using Server.Application.Common.Mailing;
using Server.Application.Common.Models;
using Server.Application.Common.Specification;
using Server.Application.Identity.Users;
using Server.Domain.Identity;
using Server.Infrastructure.Auth;
using Server.Infrastructure.Constants;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Infrastructure.Identity;
internal partial class UserService : IUserService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly ApplicationDbContext _db;
    private readonly IStringLocalizer _t;
    private readonly IJobService _jobService;
    private readonly IMailService _mailService;
    private readonly SecuritySettings _securitySettings;
    private readonly IEmailTemplateService _templateService;
    private readonly IFileStorageService _fileStorage;
    private readonly IEventPublisher _events;
    private readonly ICacheService _cache;
    private readonly ICacheKeyService _cacheKeys;

    public UserService(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        ApplicationDbContext db,
        IStringLocalizer<UserService> localizer,
        IJobService jobService,
        IMailService mailService,
        IEmailTemplateService templateService,
        IFileStorageService fileStorage,
        IEventPublisher events,
        ICacheService cache,
        ICacheKeyService cacheKeys,
        IOptions<SecuritySettings> securitySettings)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _db = db;
        _t = localizer;
        _jobService = jobService;
        _mailService = mailService;
        _templateService = templateService;
        _fileStorage = fileStorage;
        _events = events;
        _cache = cache;
        _cacheKeys = cacheKeys;
        _securitySettings = securitySettings.Value;
    }

    public async Task<PaginationResponse<UserDetailsDto>> SearchAsync(UserListFilter filter, CancellationToken cancellationToken)
    {
        var spec = new EntitiesByPaginationFilterSpec<ApplicationUser>(filter);

        var users = await _userManager.Users
            .WithSpecification(spec)
            .ProjectToType<UserDetailsDto>()
            .ToListAsync(cancellationToken);
        int count = await _userManager.Users
            .CountAsync(cancellationToken);

        return new PaginationResponse<UserDetailsDto>(users, count, filter.PageNumber, filter.PageSize);
    }

    public async Task<bool> ExistsWithNameAsync(string name)
    {
        return await _userManager.FindByNameAsync(name) is not null;
    }

    public async Task<bool> ExistsWithEmailAsync(string email, string? exceptId = null)
    {
        return await _userManager.FindByEmailAsync(email.Normalize()) is ApplicationUser user && user.Id != exceptId;
    }

    public async Task<bool> ExistsWithPhoneNumberAsync(string phoneNumber, string? exceptId = null)
    {
        return await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber) is ApplicationUser user && user.Id != exceptId;
    }

    //public async Task<List<UserDetailsDto>> GetListAsync(CancellationToken cancellationToken) =>
    //    (await _userManager.Users
    //            .AsNoTracking()
    //            .ToListAsync(cancellationToken))
    //        .Adapt<List<UserDetailsDto>>();

    public async Task<List<UserDetailsDto>> GetListAsync(string id, CancellationToken cancellationToken)
    {
        var users = await _userManager.Users
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return users.Select(u => new UserDetailsDto
        {
            Id = Guid.Parse(u.Id),
            UserName = u.UserName,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            IsActive = u.IsActive,
            EmailConfirmed = u.EmailConfirmed,
            PhoneNumber = u.PhoneNumber,
            ImageUrl = u.ImageUrl,
            BirthDate = u.BirthDate,
            EntCode = u.EntCode
        }).ToList();
    }

    public async Task<int> GetCountAsync(string? id, CancellationToken cancellationToken)
    {
        return await _userManager.Users.AsNoTracking().CountAsync(cancellationToken);
    }




    //public Task<int> GetCountAsync(string? id, CancellationToken cancellationToken) =>
    //    _userManager.Users.AsNoTracking().CountAsync(cancellationToken);

    public async Task<UserDetailsDto> GetAsync(string userId, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users
            .AsNoTracking()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync(cancellationToken);

        _ = user ?? throw new NotFoundException(_t[MessageConstants.UserNotFound]);

        return user.Adapt<UserDetailsDto>();
    }

    public async Task ToggleStatusAsync(ToggleUserStatusRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.Where(u => u.Id == request.UserId).FirstOrDefaultAsync(cancellationToken);

        _ = user ?? throw new NotFoundException(_t[MessageConstants.UserNotFound]);

        bool isAdmin = await _userManager.IsInRoleAsync(user, FSHRoles.Admin);
        if (isAdmin)
        {
            var array = new List<string>();
            array.Add(MessageConstants.AdministratorsProfilesStatusCannotBeToggled);
            throw new ConflictException(_t[MessageConstants.AdministratorsProfilesStatusCannotBeToggled], array);
        }

        user.IsActive = request.ActivateUser;

        await _userManager.UpdateAsync(user);

        await _events.PublishAsync(new ApplicationUserUpdatedEvent(user.Id));
    }
}
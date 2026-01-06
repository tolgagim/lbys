using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Exceptions;
using Server.Application.Identity.Users;
using Server.Domain.Identity;
using Server.Shared.Authorization;

namespace Server.Infrastructure.Identity;
internal partial class UserService
{
    private const string DefaultAdminEmail = "admin@root.com";

    public async Task<List<UserRoleDto>> GetRolesAsync(string userId, CancellationToken cancellationToken)
    {
        var userRoles = new List<UserRoleDto>();

        var user = await _userManager.FindByIdAsync(userId);
        if (user is null) throw new NotFoundException("User Not Found.");

        var customerId = user.CustomerId;

        var roles = await _roleManager.Roles.Where(p => p.CustomerId == customerId).AsNoTracking().ToListAsync(cancellationToken);
        if (roles is null) throw new NotFoundException("Roles Not Found.");
        foreach (var role in roles)
        {
            userRoles.Add(new UserRoleDto
            {
                RoleId = role.Id,
                RoleName = role.Name,
                Description = role.Description,
                Enabled = await _userManager.IsInRoleAsync(user, role.Name!)
            });
        }

        return userRoles;
    }

    public async Task<string> AssignRolesAsync(string userId, UserRolesRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var user = await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync(cancellationToken);

        _ = user ?? throw new NotFoundException(_t["User Not Found."]);

        // Check if the user is an admin for which the admin role is getting disabled
        if (await _userManager.IsInRoleAsync(user, FSHRoles.Admin)
            && request.UserRoles.Any(a => !a.Enabled && a.RoleName == FSHRoles.Admin))
        {
            // Get count of users in Admin Role
            int adminCount = (await _userManager.GetUsersInRoleAsync(FSHRoles.Admin)).Count;

            // Check if user is not Root Admin
            if (user.Email == DefaultAdminEmail)
            {
                var array = new List<string>();
                array.Add("Users.CannotRemoveAdminRoleFromRootAdmin");
                throw new ConflictException(_t["CannotRemoveAdminRoleFromRootAdmin"], array);
            }
            else if (adminCount <= 2)
            {
                var array = new List<string>();
                array.Add("Users.ShouldHaveAtLeast2Admins");
                throw new ConflictException(_t["Users.ShouldHaveAtLeast2Admins"], array);
            }
        }

        foreach (var userRole in request.UserRoles)
        {
            // Check if Role Exists
            if (await _roleManager.FindByNameAsync(userRole.RoleName!) is not null)
            {
                if (userRole.Enabled)
                {
                    if (!await _userManager.IsInRoleAsync(user, userRole.RoleName!))
                    {
                        await _userManager.AddToRoleAsync(user, userRole.RoleName!);
                    }
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, userRole.RoleName!);
                }
            }
        }

        await _events.PublishAsync(new ApplicationUserUpdatedEvent(user.Id, true));

        return _t["User Roles Updated Successfully."];
    }
}

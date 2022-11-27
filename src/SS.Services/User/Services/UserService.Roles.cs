using Microsoft.EntityFrameworkCore;
using SS.Application.Dtos.Users;
using SS.Application.Exceptions;
using SS.Services.Auth.Events;
using SS.Shared.Authorization;

namespace SS.Services.User.Services;

internal partial class UserService
{
    public async Task<List<UserRoleDto>> GetUserRolesAsync(string userId, CancellationToken cancellationToken)
    {
        var userRoles = new List<UserRoleDto>();

        var user = await _userManager.FindByIdAsync(userId);
        var roles = await _roleManager.Roles.AsNoTracking().ToListAsync(cancellationToken);
        foreach (var role in roles)
            userRoles.Add(new UserRoleDto
            {
                RoleId = role.Id,
                RoleName = role.Name,
                Description = role.Description,
                Enabled = await _userManager.IsInRoleAsync(user, role.Name)
            });

        return userRoles;
    }

    public async Task<string> AssignUserRolesAsync(string userId, UserRolesRequestDto request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var user = await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync(cancellationToken);

        _ = user ?? throw new NotFoundException(_t["User Not Found."]);

        // Check if the user is an admin for which the admin||Superuser||Root role is getting disabled
        if (await _userManager.IsInRoleAsync(user, SSRoles.Admin)
            && request.UserRoles.Any(a
                => !a.Enabled && a.RoleName is SSRoles.Admin))
        {
            // Get count of users in Admin||Superuser||Root Role
            var adminCount = (await _userManager.GetUsersInRoleAsync(SSRoles.Admin)).Count;

            if (adminCount <= 2) throw new ConflictException(_t["App should have at least 2 Admins."]);
        }

        foreach (var userRole in request.UserRoles)
            // Check if Role Exists
            if (await _roleManager.FindByNameAsync(userRole.RoleName!) is not null)
            {
                if (userRole.Enabled)
                {
                    if (!await _userManager.IsInRoleAsync(user, userRole.RoleName!))
                        await _userManager.AddToRoleAsync(user, userRole.RoleName!);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, userRole.RoleName!);
                }
            }

        await _events.PublishAsync(new ApplicationUserUpdatedEvent(user.Id, true));

        return _t["User Roles Updated Successfully."];
    }
}
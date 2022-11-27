using Microsoft.AspNetCore.Identity;
using SS.Application.Interfaces.Events;
using SS.Application.Interfaces.Service.User;
using SS.Domain.Users;
using SS.Services.Auth.Events;

namespace SS.Services.User.Utils;

internal class InvalidateUserPermissionCacheHandler : IEventNotificationHandler<ApplicationUserUpdatedEvent>,
    IEventNotificationHandler<ApplicationRoleUpdatedEvent>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserService _userService;

    public InvalidateUserPermissionCacheHandler(IUserService userService, UserManager<ApplicationUser> userManager)
    {
        (_userService, _userManager) = (userService, userManager);
    }

    public async Task Handle(EventNotification<ApplicationRoleUpdatedEvent> notification,
        CancellationToken cancellationToken)
    {
        if (notification.Event.PermissionsUpdated)
            foreach (var user in await _userManager.GetUsersInRoleAsync(notification.Event.RoleName))
                await _userService.InvalidatePermissionCacheAsync(user.Id, cancellationToken);
    }

    public async Task Handle(EventNotification<ApplicationUserUpdatedEvent> notification,
        CancellationToken cancellationToken)
    {
        if (notification.Event.RolesUpdated)
            await _userService.InvalidatePermissionCacheAsync(notification.Event.UserId, cancellationToken);
    }
}
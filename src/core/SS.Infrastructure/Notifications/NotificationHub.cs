using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SS.Application.Interfaces.Common;
using SS.Domain.Users;

namespace SS.Infrastructure.Notifications;

[Authorize]
public class NotificationHub : Hub, ITransientService
{
    private readonly ILogger<NotificationHub> _logger;
    private string groupName { get; set; }

    public NotificationHub(ILogger<NotificationHub> logger)
    {
        _logger = logger;
    }

    public override async Task OnConnectedAsync()
    {
        /*if (_userGroup is null)
        {
            throw new UnauthorizedException("Authentication Failed.");
        }*/

        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        await base.OnConnectedAsync();

        _logger.LogInformation("A client connected to NotificationHub: {connectionId}", Context.ConnectionId);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

        await base.OnDisconnectedAsync(exception);

        _logger.LogInformation("A client disconnected from NotificationHub: {connectionId}", Context.ConnectionId);
    }
}
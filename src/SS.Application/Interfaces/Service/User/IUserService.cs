using SS.Application.Dtos.Users;
using SS.Application.Interfaces.Common;

namespace SS.Application.Interfaces.Service.User;

public interface IUserService : ITransientService
{
    //Task<PaginationResponse<UserDetailsDto>> SearchAsync(UserListFilter filter, CancellationToken cancellationToken);

    Task<bool> UserExistsWithNameAsync(string name);
    Task<bool> UserExistsWithEmailAsync(string email, string? exceptId = null);
    Task<bool> UserExistsWithPhoneNumberAsync(string phoneNumber, string? exceptId = null);

    Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken);

    Task<int> GetUsersCountAsync(CancellationToken cancellationToken);
    Task InvalidatePermissionCacheAsync(string userId, CancellationToken cancellationToken);
    Task<UserWithDetailsDto> GetUserAsync(string userId, CancellationToken cancellationToken);

    Task<List<UserRoleDto>> GetUserRolesAsync(string userId, CancellationToken cancellationToken);
    Task<string> AssignUserRolesAsync(string userId, UserRolesRequestDto request, CancellationToken cancellationToken);

    Task<List<string>> GetUserPermissionsAsync(string userId, CancellationToken cancellationToken);
    Task<bool> HasPermissionAsync(string userId, string permission, CancellationToken cancellationToken = default);
    Task ToggleUserStatusAsync(ToggleUserStatusRequestDto request, CancellationToken cancellationToken);
    Task<string> CreateUserAsync(CreateUserRequestDto request, string origin);
    Task UpdateUserAsync(UpdateUserRequestDto request, string userId);

    Task<string> ConfirmEmailAsync(string userId, string code, CancellationToken cancellationToken);
    Task<string> ConfirmPhoneNumberAsync(string userId, string code);

    Task<string> ForgotPasswordAsync(ForgotPasswordRequestDto request, string origin);
    Task<string> ResetPasswordAsync(ResetPasswordRequestDto request);
    Task ChangePasswordAsync(ChangePasswordRequestDto request, string userId);
}
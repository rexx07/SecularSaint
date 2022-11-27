using SS.Application.Dtos.Auth.Roles;
using SS.Application.Interfaces.Common;

namespace SS.Application.Interfaces.Service.Auth;

public interface IRoleService : ITransientService
{
    Task<List<RoleDto>> GetListAsync(CancellationToken cancellationToken);
    Task<int> GetCountAsync(CancellationToken cancellationToken);

    Task<bool> ExistsAsync(string roleName, string? excludeId);

    Task<RoleDto> GetByIdAsync(string id);

    Task<RoleDto> GetByIdWithPermissionsAsync(string roleId, CancellationToken cancellationToken);

    Task<string> CreateOrUpdateAsync(CreateOrUpdateRoleRequestDto request);

    Task<string> UpdatePermissionsAsync(UpdateRolePermissionsRequestDto request, CancellationToken cancellationToken);

    Task<string> DeleteAsync(string id);
}
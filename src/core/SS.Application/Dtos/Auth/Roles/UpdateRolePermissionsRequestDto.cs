namespace SS.Application.Dtos.Auth.Roles;

public class UpdateRolePermissionsRequestDto
{
    public string RoleId { get; set; } = default!;
    public List<string> Permissions { get; set; } = default!;
}
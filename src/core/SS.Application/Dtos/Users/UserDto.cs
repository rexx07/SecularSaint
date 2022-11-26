namespace SS.Application.Dtos.Users;

public class UserDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Bio { get; set; }
    public bool EmailConfirmed { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; }
    public bool IsAuthor { get; set; }
}
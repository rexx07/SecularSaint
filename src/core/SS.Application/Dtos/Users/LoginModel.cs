using System.ComponentModel.DataAnnotations;

namespace SS.Application.Dtos.Users;

public class LoginModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [EmailAddress]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
using SS.Application.Dtos.Blog;

namespace SS.Application.Dtos.Users;

public record UserWithDetailsDto
{
    public string Id { get; set; }

    public string? UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; } = true;

    public bool EmailConfirmed { get; set; }

    public string? PhoneNumber { get; set; }

    public string? ImageUrl { get; set; }
    public string? CoverUrl { get; set; }
    public List<string> MediaUrls { get; set; }
    public ICollection<ArticleDto> Articles { get; set; }
    public ICollection<CommentDto> Comment { get; set; }
}
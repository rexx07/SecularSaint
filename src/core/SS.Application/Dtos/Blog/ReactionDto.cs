using SS.Domain.Blog;

namespace SS.Application.Dtos.Blog;

public class ReactionDto
{
    public Guid ReactionId { get; init; }
    public UserReaction ReactionType { get; init; }
}
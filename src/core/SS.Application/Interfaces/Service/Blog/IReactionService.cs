using SS.Application.Dtos.Blog;

namespace SS.Application.Interfaces.Service.Blog;

public interface IReactionService
{
    Task<IEnumerable<ReactionDto>> GetAllReactionsAsync(bool trackChanges);
    Task<IEnumerable<ReactionDto>> SearchReactionsAsync(IEnumerable<Guid> reactionIds, bool trackChanges);
    Task<ReactionDto> GetReactionAsync(Guid reactionId, bool trackChanges);

    Task<ReactionDto> CreateReactionAsync(ReactionDto reaction, bool trackChanges);

    Task UpdateReactionAsync(Guid reactionId, ReactionDto reaction, bool trackChanges);
    Task DeleteReactionAsync(Guid reactionId, bool trackChanges);
}
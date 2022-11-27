using SS.Domain.Blog;

namespace SS.Application.Interfaces.Persistence.Repository;

public interface IReactionRepository
{
    Task<IEnumerable<Reaction>> GetAllReactionsAsync(bool trackChanges);
    Task<Reaction?> GetReactionAsync(Guid reactionId, bool trackChanges);
    void CreateReaction(Reaction reaction);
    void DeleteReaction(Reaction reaction);
}
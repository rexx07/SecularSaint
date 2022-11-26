namespace SS.Application.Interfaces.Persistence.Repository;

public interface IRepositoryManager
{
    IAddressRepository Address { get; }
    IArticleRepository Article { get; }
    ICommentRepository Comment { get; }
    IContactRepository Contact { get; }
    IReactionRepository Reaction { get; }
    Task SaveAsync();
}
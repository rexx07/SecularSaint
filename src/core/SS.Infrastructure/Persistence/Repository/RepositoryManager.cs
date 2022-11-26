using SS.Application.Interfaces.Persistence.Repository;
using SS.Infrastructure.Persistence.Context;

namespace SS.Infrastructure.Persistence.Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IAddressRepository> _addressRepository;
    private readonly Lazy<IArticleRepository> _articleRepository;
    private readonly Lazy<ICommentRepository> _commentRepository;
    private readonly Lazy<IContactRepository> _contactRepository;
    private readonly Lazy<IReactionRepository> _reactionRepository;
    private readonly ApplicationDbContext _repositoryContext;

    public RepositoryManager(ApplicationDbContext repositoryContext)
    {
        _repositoryContext = repositoryContext;

        _addressRepository = new Lazy<IAddressRepository>(() =>
            new AddressRepository(repositoryContext));

        _articleRepository = new Lazy<IArticleRepository>(() =>
            new ArticleRepository(repositoryContext));

        _commentRepository = new Lazy<ICommentRepository>(() =>
            new CommentRepository(repositoryContext));

        _contactRepository = new Lazy<IContactRepository>(() =>
            new ContactRepository(repositoryContext));

        _reactionRepository = new Lazy<IReactionRepository>(() =>
            new ReactionRepository(repositoryContext));
    }

    public IAddressRepository Address => _addressRepository.Value;
    public IArticleRepository Article => _articleRepository.Value;
    public ICommentRepository Comment => _commentRepository.Value;
    public IContactRepository Contact => _contactRepository.Value;
    public IReactionRepository Reaction => _reactionRepository.Value;

    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }
}
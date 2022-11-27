using SS.Application.Interfaces.Persistence.Repository;
using SS.Domain.Blog;
using SS.Infrastructure.Persistence.Context;

namespace SS.Infrastructure.Persistence.Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IArticleRepository> _articleRepository;
    private readonly Lazy<ICategoryRepository> _categoryRepository;
    private readonly Lazy<ICommentRepository> _commentRepository;
    private readonly Lazy<IMailSettingRepository> _maileSettingRepository;
    private readonly Lazy<INewsletterRepository> _newsletterRepository;
    private readonly Lazy<IReactionRepository> _reactionRepository;
    private readonly ApplicationDbContext _repositoryContext;

    public RepositoryManager(ApplicationDbContext repositoryContext)
    {
        _repositoryContext = repositoryContext;

        _categoryRepository = new Lazy<ICategoryRepository>(() =>
            new CategoryRepository(repositoryContext));

        _articleRepository = new Lazy<IArticleRepository>(() =>
            new ArticleRepository(repositoryContext));

        _commentRepository = new Lazy<ICommentRepository>(() =>
            new CommentRepository(repositoryContext));
        
        _maileSettingRepository = new Lazy<IMailSettingRepository>(() =>
            new MailSettingRepository(repositoryContext));

        _newsletterRepository = new Lazy<INewsletterRepository>(() =>
            new NewsletterRepository(repositoryContext));

        _reactionRepository = new Lazy<IReactionRepository>(() =>
            new ReactionRepository(repositoryContext));
    }

    public ICategoryRepository Category => _categoryRepository.Value;
    public IArticleRepository Article => _articleRepository.Value;
    public ICommentRepository Comment => _commentRepository.Value;
    public INewsletterRepository Newsletter => _newsletterRepository.Value;
    public IMailSettingRepository MailSetting => _maileSettingRepository.Value;
    public IReactionRepository Reaction => _reactionRepository.Value;

    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }
}
using SS.Domain.Blog;

namespace SS.Application.Interfaces.Persistence.Repository;

public interface INewsletterRepository
{
    Task<IEnumerable<Newsletter>> GetAllNewsletterAsync(bool trackChanges);
    Task<Newsletter?> GetNewsletterAsync(Guid newsletterId ,bool trackChanges);
    Void CreateNewsletter(Newsletter newsletter);
    Void DeleteNewsletter(Newsletter newsletter);
}
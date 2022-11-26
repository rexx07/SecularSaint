using SS.Domain.Common;

namespace SS.Application.Interfaces.Persistence.Repository;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllContactsAsync(bool trackChanges);
    Task<Contact?> GetContactAsync(Guid id, bool trackChanges);
    void CreateContact(Contact contact);
    void DeleteContact(Contact contact);
}
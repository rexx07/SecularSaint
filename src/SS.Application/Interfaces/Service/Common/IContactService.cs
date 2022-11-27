using SS.Application.Dtos.Common;

namespace SS.Application.Interfaces.Service.Common;

public interface IContactService
{
    Task<IEnumerable<ContactDto>> GetAllContactsAsync(bool trackChanges);
    Task<IEnumerable<ContactDto>> SearchContactsAsync(IEnumerable<Guid> contactId, bool trackChanges);
    Task<ContactDto> GetContactAsync(Guid contactId, bool trackChanges);
    Task<ContactDto> CreateContactAsync(CreateUpdateContactRequestDto contact, bool trackChanges);
    Task UpdateContactAsync(Guid contactId, CreateUpdateAddressRequestDto contact, bool trackChanges);
    Task DeleteContactAsync(Guid contactId, bool trackChanges);
}
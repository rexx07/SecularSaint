using SS.Domain.Common;

namespace SS.Application.Interfaces.Persistence.Repository;

public interface IAddressRepository
{
    Task<IEnumerable<Address>> GetAllAddressesAsync(bool trackChanges);
    Task<Address?> GetAddressAsync(Guid id, bool trackChanges);
    void CreateAddress(Address address);
    void DeleteAddress(Address address);
}
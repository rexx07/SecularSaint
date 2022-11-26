using Microsoft.EntityFrameworkCore;
using SS.Application.Interfaces.Persistence.Repository;
using SS.Domain.Common;
using SS.Infrastructure.Persistence.Context;

namespace SS.Infrastructure.Persistence.Repository;

internal sealed class AddressRepository : RepositoryBase<Address>, IAddressRepository
{
    public AddressRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Address>> GetAllAddressesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(a => a.Name)
            .ToListAsync();
    }

    public async Task<Address?> GetAddressAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(a => a.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateAddress(Address address)
    {
        Create(address);
    }

    public void DeleteAddress(Address address)
    {
        Delete(address);
    }
}
using SS.Application.Dtos.Common;

namespace SS.Application.Interfaces.Service.Common;

public interface IAddressService
{
    Task<IEnumerable<AddressDto>> GetAllAddressesAsync(bool trackChanges);
    Task<IEnumerable<AddressDto>> SearchAddressAsync(IEnumerable<Guid> addressIds, bool trackChanges);
    Task<AddressDto> GetAddressAsync(Guid addressId, bool trackChanges);
    Task<AddressDto> CreateAddressAsync(CreateUpdateAddressRequestDto address, bool trackChanges);
    Task UpdateAddrressAsync(Guid addressId, CreateUpdateAddressRequestDto address, bool trackChanges);
    Task DeleteAddressAsync(Guid addressId, bool trackChanges);
}
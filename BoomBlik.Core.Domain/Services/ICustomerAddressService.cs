using BoomBlik.Core.Domain.Dtos;

namespace BoomBlik.Core.Domain.Services
{
    public interface ICustomerAddressService
    {
        Task<CustomerAddressDto> GetCustomerAddressByIdAsync(Guid customerAddressId);
        Task<IEnumerable<CustomerAddressDto>> GetAllCustomerAddressesAsync();
        Task<CustomerAddressDto> CreateCustomerAddressAsync(CustomerAddressDto customerAddressDto);
        Task<CustomerAddressDto> UpdateCustomerAddressAsync(CustomerAddressDto customerAddressDto);
        Task DeleteCustomerAddressAsync(Guid customerAddressId);
    }
}
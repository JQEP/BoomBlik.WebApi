using BoomBlik.Core.Domain.Dtos;

public interface ICustomerService
{
    Task<CustomerDto> GetCustomerByIdAsync(Guid customerId);
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto);
    Task<CustomerDto> UpdateCustomerAsync(CustomerDto customerDto);
    Task DeleteCustomerAsync(Guid customerId);
}
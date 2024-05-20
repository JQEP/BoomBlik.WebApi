using BoomBlik.Core.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using BoomBlik.Core.Infrastructure.Entities;
using AutoMapper;
using BoomBlik.Infrastructure.Repository;
using BoomBlik.Common.Extensions;

namespace BoomBlik.Modules.Reports.Services;

public class CustomerService(BoomBlikDbContext dbContext, IMapper mapper) : ICustomerService
{
    public async Task<CustomerDto> CreateCustomerAsync(CustomerDto customer)
    {
        ArgumentNullException.ThrowIfNull(customer);

        var entity = mapper.Map<CustomerEntity>(customer);

        dbContext.Customers.Add(entity);
        await dbContext.SaveChangesAsync();

        return mapper.Map<CustomerDto>(entity);
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        var customer = await dbContext.Customers.FindAsync(id);
        await customer.AssertEntityFoundOrThrowEntityNotFoundException(id);

        dbContext.Customers.Remove(customer);
        await dbContext.SaveChangesAsync();
    }

    public async Task<CustomerDto> GetCustomerByIdAsync(Guid id)
    {
        var customer = await dbContext.Customers.FindAsync(id);
        await customer.AssertEntityFoundOrThrowEntityNotFoundException(id);

        return mapper.Map<CustomerDto>(customer);
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
    {
        return await dbContext.Customers
            .Select(x => mapper.Map<CustomerDto>(x))
            .ToListAsync();
    }

    public async Task<CustomerDto> UpdateCustomerAsync(CustomerDto customerDto)
    {
        var customer = await dbContext.Customers.FindAsync(customerDto.Id);
        await customer.AssertEntityFoundOrThrowEntityNotFoundException(customerDto.Id);

        mapper.Map(customerDto, customer);
        await dbContext.SaveChangesAsync();
        return mapper.Map<CustomerDto>(customer);
    }
}
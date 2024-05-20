using BoomBlik.Core.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using BoomBlik.Core.Infrastructure.Entities;
using AutoMapper;
using BoomBlik.Infrastructure.Repository;
using BoomBlik.Common.Extensions;
using BoomBlik.Core.Domain.Services;

namespace BoomBlik.Modules.Reports.Services
{
    public class CustomerAddressService(BoomBlikDbContext dbContext, IMapper mapper) : ICustomerAddressService
    {
        public async Task<CustomerAddressDto> CreateCustomerAddressAsync(CustomerAddressDto customerAddress)
        {
            ArgumentNullException.ThrowIfNull(customerAddress);

            var entity = mapper.Map<CustomerAddressEntity>(customerAddress);

            dbContext.CustomerAddresses.Add(entity);
            await dbContext.SaveChangesAsync();

            return mapper.Map<CustomerAddressDto>(entity);
        }

        public async Task DeleteCustomerAddressAsync(Guid id)
        {
            var customerAddress = await dbContext.CustomerAddresses.FindAsync(id);
            await customerAddress.AssertEntityFoundOrThrowEntityNotFoundException(id);

            dbContext.CustomerAddresses.Remove(customerAddress);
            await dbContext.SaveChangesAsync();
        }

        public async Task<CustomerAddressDto> GetCustomerAddressByIdAsync(Guid id)
        {
            var customerAddress = await dbContext.CustomerAddresses.FindAsync(id);
            await customerAddress.AssertEntityFoundOrThrowEntityNotFoundException(id);

            return mapper.Map<CustomerAddressDto>(customerAddress);
        }

        public async Task<IEnumerable<CustomerAddressDto>> GetAllCustomerAddressesAsync()
        {
            return await dbContext.CustomerAddresses
                .Select(x => mapper.Map<CustomerAddressDto>(x))
                .ToListAsync();
        }

        public async Task<CustomerAddressDto> UpdateCustomerAddressAsync(CustomerAddressDto customerAddressDto)
        {
            var customerAddress = await dbContext.CustomerAddresses.FindAsync(customerAddressDto.Id);
            await customerAddress.AssertEntityFoundOrThrowEntityNotFoundException(customerAddressDto.Id);

            mapper.Map(customerAddressDto, customerAddress);
            await dbContext.SaveChangesAsync();
            return mapper.Map<CustomerAddressDto>(customerAddress);
        }
    }
}
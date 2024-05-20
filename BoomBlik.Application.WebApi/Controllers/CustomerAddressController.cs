using Asp.Versioning;
using BoomBlik.Core.Domain.Dtos;
using BoomBlik.Core.Domain.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SmartOffice.Common.Helpers;
using Swashbuckle.AspNetCore.Annotations;

namespace boomblik_api.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class CustomerAddressController(
    ICustomerAddressService customerAddressService,
    IValidator<CustomerAddressDto> validator)
    : ControllerBase
{
    [SwaggerOperation(Summary = "Adds a new customer address.")]
    [HttpPost]
    public async Task<ActionResult<CustomerAddressDto>> AddCustomerAddressAsync([FromBody] CustomerAddressDto customerAddressDto) 
    {
        customerAddressDto.ValidateAndThrowArgumentException(validator);

        var newCustomerAddress = await customerAddressService.CreateCustomerAddressAsync(customerAddressDto);
        return CreatedAtAction(nameof(GetCustomerAddressByIdAsync), new { id = newCustomerAddress.Id }, newCustomerAddress);
    }

    [HttpGet("{id:Guid}"), ActionName(nameof(GetCustomerAddressByIdAsync))]
    [SwaggerOperation(Summary = "Retrieves the customer address with the specified ID.")]
    public async Task<ActionResult<CustomerAddressDto>> GetCustomerAddressByIdAsync([FromRoute] Guid id) 
    {
        return Ok(await customerAddressService.GetCustomerAddressByIdAsync(id));
    }

    [SwaggerOperation(Summary = "Retrieves the collection of customer addresses.")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerAddressDto>>> GetCustomerAddressesAsync()
    {
        return Ok(await customerAddressService.GetAllCustomerAddressesAsync());
    }

    [SwaggerOperation(Summary = "Updates a customer address.")]
    [HttpPut]
    public async Task<ActionResult<CustomerAddressDto>> UpdateCustomerAddressAsync([FromBody] CustomerAddressDto customerAddressDto) 
    {
        customerAddressDto.ValidateAndThrowArgumentException(validator);

        var updatedCustomerAddress = await customerAddressService.UpdateCustomerAddressAsync(customerAddressDto);
        return CreatedAtAction(nameof(GetCustomerAddressByIdAsync), new { id = updatedCustomerAddress.Id }, updatedCustomerAddress);
    }

    [SwaggerOperation(Summary = "Deletes a customer address.")]
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteCustomerAddressAsync([FromRoute] Guid id) 
    {
        await customerAddressService.DeleteCustomerAddressAsync(id);
        return NoContent();
    }
}
using Asp.Versioning;
using BoomBlik.Core.Domain.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SmartOffice.Common.Helpers;
using Swashbuckle.AspNetCore.Annotations;

namespace boomblik_api.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class CustomerController(ICustomerService customerService, IValidator<CustomerDto> validator)
    : ControllerBase
{
    [SwaggerOperation(Summary = "Adds a new customer.")]
    [HttpPost]
    public async Task<ActionResult<CustomerDto>> AddCustomerAsync([FromBody] CustomerDto customerDto) 
    {
        customerDto.ValidateAndThrowArgumentException(validator);

        var newCustomer = await customerService.CreateCustomerAsync(customerDto);
        return CreatedAtAction(nameof(GetCustomerByIdAsync), new { id = newCustomer.Id }, newCustomer);
    }

    [HttpGet("{id:Guid}"), ActionName(nameof(GetCustomerByIdAsync))]
    [SwaggerOperation(Summary = "Retrieves the customer with the specified ID.")]
    public async Task<ActionResult<CustomerDto>> GetCustomerByIdAsync([FromRoute] Guid id) 
    {
        return Ok(await customerService.GetCustomerByIdAsync(id));
    }

    [SwaggerOperation(Summary = "Retrieves the collection of customers within the specified range.")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomersAsync([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        return Ok(await customerService.GetAllCustomersAsync());
    }

    [SwaggerOperation(Summary = "Updates a customer to the new customer.")]
    [HttpPut]
    public async Task<ActionResult<CustomerDto>> UpdateCustomerAsync([FromBody] CustomerDto customerDto) 
    {
        customerDto.ValidateAndThrowArgumentException(validator);

        var updatedCustomer = await customerService.UpdateCustomerAsync(customerDto);
        return CreatedAtAction(nameof(GetCustomerByIdAsync), new { id = updatedCustomer.Id }, updatedCustomer);
    }

    [SwaggerOperation(Summary = "Deletes a customer.")]
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteCustomerAsync([FromRoute] Guid id) 
    {
        await customerService.DeleteCustomerAsync(id);
        return NoContent();
    }
}
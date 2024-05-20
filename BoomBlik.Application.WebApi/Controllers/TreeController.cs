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
public class TreeController(ITreeService treeService, IValidator<TreeDto> validator) : ControllerBase
{
    [SwaggerOperation(Summary = "Adds a new tree.")]
    [HttpPost]
    public async Task<ActionResult<TreeDto>> AddTreeAsync([FromBody] TreeDto treeDto) 
    {
        treeDto.ValidateAndThrowArgumentException(validator);

        var newTree = await treeService.CreateTreeAsync(treeDto);
        return CreatedAtAction(nameof(GetTreeByIdAsync), new { id = newTree.Id }, newTree);
    }

    [HttpGet("{id:Guid}"), ActionName(nameof(GetTreeByIdAsync))]
    [SwaggerOperation(Summary = "Retrieves the tree with the specified ID.")]
    public async Task<ActionResult<TreeDto>> GetTreeByIdAsync([FromRoute] Guid id) 
    {
        return Ok(await treeService.GetTreeByIdAsync(id));
    }

    [SwaggerOperation(Summary = "Retrieves the collection of trees within the specified range.")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TreeDto>>> GetTreesAsync([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        return Ok(await treeService.GetAllTreesAsync());
    }

    [SwaggerOperation(Summary = "Updates a tree to the new tree.")]
    [HttpPut]
    public async Task<ActionResult<TreeDto>> UpdateTreeAsync([FromBody] TreeDto treeDto) 
    {
        treeDto.ValidateAndThrowArgumentException(validator);

        var updatedTree = await treeService.UpdateTreeAsync(treeDto);
        return CreatedAtAction(nameof(GetTreeByIdAsync), new { id = updatedTree.Id }, updatedTree);
    }

    [SwaggerOperation(Summary = "Deletes a tree.")]
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteTreeAsync([FromRoute] Guid id) 
    {
        await treeService.DeleteTreeAsync(id);
        return NoContent();
    }
}
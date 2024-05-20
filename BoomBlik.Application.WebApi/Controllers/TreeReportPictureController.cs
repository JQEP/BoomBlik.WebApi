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
public class TreeReportPictureController(
    ITreeReportPictureService treeReportPictureService,
    IValidator<TreeReportPictureDto> validator)
    : ControllerBase
{
    [SwaggerOperation(Summary = "Adds a new TreeReportPicture.")]
    [HttpPost]
    public async Task<ActionResult<TreeReportPictureDto>> AddTreeReportPictureAsync([FromBody] TreeReportPictureDto treeReportPictureDto) 
    {
        treeReportPictureDto.ValidateAndThrowArgumentException(validator);

        var newTreeReportPicture = await treeReportPictureService.CreateTreeReportPictureAsync(treeReportPictureDto);
        return CreatedAtAction(nameof(GetTreeReportPictureByIdAsync), new { id = newTreeReportPicture.Id }, newTreeReportPicture);
    }

    [HttpGet("{id:Guid}"), ActionName(nameof(GetTreeReportPictureByIdAsync))]
    [SwaggerOperation(Summary = "Retrieves the TreeReportPicture with the specified ID.")]
    public async Task<ActionResult<TreeReportPictureDto>> GetTreeReportPictureByIdAsync([FromRoute] Guid id) 
    {
        return Ok(await treeReportPictureService.GetTreeReportPictureByIdAsync(id));
    }

    [SwaggerOperation(Summary = "Retrieves the collection of TreeReportPictures within the specified range.")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TreeReportPictureDto>>> GetTreeReportPicturesAsync([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        return Ok(await treeReportPictureService.GetAllTreeReportPicturesAsync());
    }

    [SwaggerOperation(Summary = "Updates a TreeReportPicture to the new TreeReportPicture.")]
    [HttpPut]
    public async Task<ActionResult<TreeReportPictureDto>> UpdateTreeReportPictureAsync([FromBody] TreeReportPictureDto treeReportPictureDto) 
    {
        treeReportPictureDto.ValidateAndThrowArgumentException(validator);

        var updatedTreeReportPicture = await treeReportPictureService.UpdateTreeReportPictureAsync(treeReportPictureDto);
        return CreatedAtAction(nameof(GetTreeReportPictureByIdAsync), new { id = updatedTreeReportPicture.Id }, updatedTreeReportPicture);
    }

    [SwaggerOperation(Summary = "Deletes a TreeReportPicture.")]
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteTreeReportPictureAsync([FromRoute] Guid id) 
    {
        await treeReportPictureService.DeleteTreeReportPictureAsync(id);
        return NoContent();
    }
}
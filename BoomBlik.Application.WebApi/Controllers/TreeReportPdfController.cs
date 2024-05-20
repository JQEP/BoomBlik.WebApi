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
public class TreeReportPdfController(ITreeReportPdfService treeReportPdfService, IValidator<TreeReportPdfDto> validator)
    : ControllerBase
{
    [SwaggerOperation(Summary = "Adds a new TreeReportPdf.")]
    [HttpPost]
    public async Task<ActionResult<TreeReportPdfDto>> AddTreeReportPdfAsync([FromBody] TreeReportPdfDto treeReportPdfDto) 
    {
        treeReportPdfDto.ValidateAndThrowArgumentException(validator);

        var newTreeReportPdf = await treeReportPdfService.CreateTreeReportPdfAsync(treeReportPdfDto);
        return CreatedAtAction(nameof(GetTreeReportPdfByIdAsync), new { id = newTreeReportPdf.Id }, newTreeReportPdf);
    }

    [HttpGet("{id:Guid}"), ActionName(nameof(GetTreeReportPdfByIdAsync))]
    [SwaggerOperation(Summary = "Retrieves the TreeReportPdf with the specified ID.")]
    public async Task<ActionResult<TreeReportPdfDto>> GetTreeReportPdfByIdAsync([FromRoute] Guid id) 
    {
        return Ok(await treeReportPdfService.GetTreeReportPdfByIdAsync(id));
    }

    [SwaggerOperation(Summary = "Retrieves the collection of TreeReportPdfs within the specified range.")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TreeReportPdfDto>>> GetTreeReportPdfsAsync([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        return Ok(await treeReportPdfService.GetAllTreeReportPdfsAsync());
    }

    [SwaggerOperation(Summary = "Updates a TreeReportPdf to the new TreeReportPdf.")]
    [HttpPut]
    public async Task<ActionResult<TreeReportPdfDto>> UpdateTreeReportPdfAsync([FromBody] TreeReportPdfDto treeReportPdfDto) 
    {
        treeReportPdfDto.ValidateAndThrowArgumentException(validator);

        var updatedTreeReportPdf = await treeReportPdfService.UpdateTreeReportPdfAsync(treeReportPdfDto);
        return CreatedAtAction(nameof(GetTreeReportPdfByIdAsync), new { id = updatedTreeReportPdf.Id }, updatedTreeReportPdf);
    }

    [SwaggerOperation(Summary = "Deletes a TreeReportPdf.")]
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteTreeReportPdfAsync([FromRoute] Guid id) 
    {
        await treeReportPdfService.DeleteTreeReportPdfAsync(id);
        return NoContent();
    }
}
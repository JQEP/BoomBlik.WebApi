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
public class TreeReportController(ITreeReportService treeReportService, IValidator<TreeReportDto> validator)
    : ControllerBase
{
    [SwaggerOperation(Summary = "Adds a new tree report.")]
    [HttpPost]
    public async Task<ActionResult<TreeReportDto>> AddTreeReportAsync([FromBody] TreeReportDto treeReportDto) 
    {
        treeReportDto.ValidateAndThrowArgumentException(validator);

        var newTreeReport = await treeReportService.CreateTreeReportAsync(treeReportDto);
        return CreatedAtAction(nameof(GetTreeReportByIdAsync), new { id = newTreeReport.Id }, newTreeReport);
    }

    [HttpGet("{id:Guid}"), ActionName(nameof(GetTreeReportByIdAsync))]
    [SwaggerOperation(Summary = "Retrieves the tree report with the specified ID.")]
    public async Task<ActionResult<TreeReportDto>> GetTreeReportByIdAsync([FromRoute] Guid id) 
    {
        return Ok(await treeReportService.GetTreeReportByIdAsync(id));
    }

    [SwaggerOperation(Summary = "Retrieves the collection of tree reports.")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TreeReportDto>>> GetTreeReportsAsync()
    {
        return Ok(await treeReportService.GetAllTreeReportsAsync());
    }

    [SwaggerOperation(Summary = "Updates a tree report.")]
    [HttpPut]
    public async Task<ActionResult<TreeReportDto>> UpdateTreeReportAsync([FromBody] TreeReportDto treeReportDto) 
    {
        treeReportDto.ValidateAndThrowArgumentException(validator);

        var updatedTreeReport = await treeReportService.UpdateTreeReportAsync(treeReportDto);
        return CreatedAtAction(nameof(GetTreeReportByIdAsync), new { id = updatedTreeReport.Id }, updatedTreeReport);
    }

    [SwaggerOperation(Summary = "Deletes a tree report.")]
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteTreeReportAsync([FromRoute] Guid id) 
    {
        await treeReportService.DeleteTreeReportAsync(id);
        return NoContent();
    }
}
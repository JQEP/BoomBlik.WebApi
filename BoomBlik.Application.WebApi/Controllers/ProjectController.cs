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
public class ProjectController(IProjectService projectService, IValidator<ProjectDto> validator)
    : ControllerBase
{
    [SwaggerOperation(Summary = "Adds a new project.")]
    [HttpPost]
    public async Task<ActionResult<ProjectDto>> AddProjectAsync([FromBody] ProjectDto projectDto) 
    {
        projectDto.ValidateAndThrowArgumentException(validator);

        var newProject = await projectService.CreateProjectAsync(projectDto);
        return CreatedAtAction(nameof(GetProjectByIdAsync), new { id = newProject.Id }, newProject);
    }

    [HttpGet("{id:Guid}"), ActionName(nameof(GetProjectByIdAsync))]
    [SwaggerOperation(Summary = "Retrieves the project with the specified ID.")]
    public async Task<ActionResult<ProjectDto>> GetProjectByIdAsync([FromRoute] Guid id) 
    {
        return Ok(await projectService.GetProjectByIdAsync(id));
    }

    [SwaggerOperation(Summary = "Retrieves the collection of projects within the specified range.")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjectsAsync([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        return Ok(await projectService.GetAllProjectsAsync());
    }

    [SwaggerOperation(Summary = "Updates a project to the new project.")]
    [HttpPut]
    public async Task<ActionResult<ProjectDto>> UpdateProjectAsync([FromBody] ProjectDto projectDto) 
    {
        projectDto.ValidateAndThrowArgumentException(validator);

        var updatedProject = await projectService.UpdateProjectAsync(projectDto);
        return CreatedAtAction(nameof(GetProjectByIdAsync), new { id = updatedProject.Id }, updatedProject);
    }

    [SwaggerOperation(Summary = "Deletes a project.")]
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteProjectAsync([FromRoute] Guid id) 
    {
        await projectService.DeleteProjectAsync(id);
        return NoContent();
    }
}
using BoomBlik.Core.Domain.Dtos;

public interface IProjectService
{
    Task<ProjectDto> GetProjectByIdAsync(Guid projectId);
    Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
    Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto);
    Task<ProjectDto> UpdateProjectAsync(ProjectDto projectDto);
    Task DeleteProjectAsync(Guid projectId);
}

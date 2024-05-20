using BoomBlik.Core.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using BoomBlik.Core.Infrastructure.Entities;
using AutoMapper;
using BoomBlik.Infrastructure.Repository;
using BoomBlik.Common.Extensions;

namespace BoomBlik.Modules.Reports.Services
{
    public class ProjectService(BoomBlikDbContext dbContext, IMapper mapper) : IProjectService
    {
        public async Task<ProjectDto> CreateProjectAsync(ProjectDto project)
        {
            ArgumentNullException.ThrowIfNull(project);

            var entity = mapper.Map<ProjectEntity>(project);

            dbContext.Projects.Add(entity);
            await dbContext.SaveChangesAsync();

            return mapper.Map<ProjectDto>(entity);
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var project = await dbContext.Projects.FindAsync(id);
            await project.AssertEntityFoundOrThrowEntityNotFoundException(id);

            dbContext.Projects.Remove(project);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ProjectDto> GetProjectByIdAsync(Guid id)
        {
            var project = await dbContext.Projects.FindAsync(id);
            await project.AssertEntityFoundOrThrowEntityNotFoundException(id);

            return mapper.Map<ProjectDto>(project);
        }

        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
        {
            return await dbContext.Projects
                .Select(x => mapper.Map<ProjectDto>(x))
                .ToListAsync();
        }

        public async Task<ProjectDto> UpdateProjectAsync(ProjectDto projectDto)
        {
            var project = await dbContext.Projects.FindAsync(projectDto.Id);
            await project.AssertEntityFoundOrThrowEntityNotFoundException(projectDto.Id);

            mapper.Map(projectDto, project);
            await dbContext.SaveChangesAsync();
            return mapper.Map<ProjectDto>(project);
        }
    }
}
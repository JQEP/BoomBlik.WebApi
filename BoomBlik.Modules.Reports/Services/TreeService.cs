using BoomBlik.Core.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using BoomBlik.Core.Infrastructure.Entities;
using AutoMapper;
using BoomBlik.Infrastructure.Repository;
using BoomBlik.Common.Extensions;

namespace BoomBlik.Modules.Reports.Services
{
    public class TreeService(BoomBlikDbContext dbContext, IMapper mapper) : ITreeService
    {
        public async Task<TreeDto> CreateTreeAsync(TreeDto tree)
        {
            ArgumentNullException.ThrowIfNull(tree);

            var entity = mapper.Map<TreeEntity>(tree);

            dbContext.Trees.Add(entity);
            await dbContext.SaveChangesAsync();

            return mapper.Map<TreeDto>(entity);
        }

        public async Task DeleteTreeAsync(Guid id)
        {
            var tree = await dbContext.Trees.FindAsync(id);
            await tree.AssertEntityFoundOrThrowEntityNotFoundException(id);

            dbContext.Trees.Remove(tree);
            await dbContext.SaveChangesAsync();
        }

        public async Task<TreeDto> GetTreeByIdAsync(Guid id)
        {
            var tree = await dbContext.Trees.FindAsync(id);
            await tree.AssertEntityFoundOrThrowEntityNotFoundException(id);

            return mapper.Map<TreeDto>(tree);
        }

        public async Task<IEnumerable<TreeDto>> GetAllTreesAsync()
        {
            return await dbContext.Trees
                .Select(x => mapper.Map<TreeDto>(x))
                .ToListAsync();
        }

        public async Task<TreeDto> UpdateTreeAsync(TreeDto treeDto)
        {
            var tree = await dbContext.Trees.FindAsync(treeDto.Id);
            await tree.AssertEntityFoundOrThrowEntityNotFoundException(treeDto.Id);

            mapper.Map(treeDto, tree);
            await dbContext.SaveChangesAsync();
            return mapper.Map<TreeDto>(tree);
        }
    }
}
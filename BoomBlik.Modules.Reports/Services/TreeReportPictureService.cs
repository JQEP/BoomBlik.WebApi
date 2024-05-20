using BoomBlik.Core.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using BoomBlik.Core.Infrastructure.Entities;
using AutoMapper;
using BoomBlik.Infrastructure.Repository;
using BoomBlik.Common.Extensions;

namespace BoomBlik.Modules.Reports.Services
{
    public class TreeReportPictureService(BoomBlikDbContext dbContext, IMapper mapper) : ITreeReportPictureService
    {
        public async Task<TreeReportPictureDto> CreateTreeReportPictureAsync(TreeReportPictureDto treeReportPicture)
        {
            ArgumentNullException.ThrowIfNull(treeReportPicture);

            var entity = mapper.Map<TreeReportPictureEntity>(treeReportPicture);

            dbContext.TreeReportPictures.Add(entity);
            await dbContext.SaveChangesAsync();

            return mapper.Map<TreeReportPictureDto>(entity);
        }

        public async Task DeleteTreeReportPictureAsync(Guid id)
        {
            var treeReportPicture = await dbContext.TreeReportPictures.FindAsync(id);
            await treeReportPicture.AssertEntityFoundOrThrowEntityNotFoundException(id);

            dbContext.TreeReportPictures.Remove(treeReportPicture);
            await dbContext.SaveChangesAsync();
        }

        public async Task<TreeReportPictureDto> GetTreeReportPictureByIdAsync(Guid id)
        {
            var treeReportPicture = await dbContext.TreeReportPictures.FindAsync(id);
            await treeReportPicture.AssertEntityFoundOrThrowEntityNotFoundException(id);

            return mapper.Map<TreeReportPictureDto>(treeReportPicture);
        }

        public async Task<IEnumerable<TreeReportPictureDto>> GetAllTreeReportPicturesAsync()
        {
            return await dbContext.TreeReportPictures
                .Select(x => mapper.Map<TreeReportPictureDto>(x))
                .ToListAsync();
        }

        public async Task<TreeReportPictureDto> UpdateTreeReportPictureAsync(TreeReportPictureDto treeReportPictureDto)
        {
            var treeReportPicture = await dbContext.TreeReportPictures.FindAsync(treeReportPictureDto.Id);
            await treeReportPicture.AssertEntityFoundOrThrowEntityNotFoundException(treeReportPictureDto.Id);

            mapper.Map(treeReportPictureDto, treeReportPicture);
            await dbContext.SaveChangesAsync();
            return mapper.Map<TreeReportPictureDto>(treeReportPicture);
        }
    }
}
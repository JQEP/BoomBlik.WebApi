using BoomBlik.Core.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using BoomBlik.Core.Infrastructure.Entities;
using AutoMapper;
using BoomBlik.Infrastructure.Repository;
using BoomBlik.Common.Extensions;

namespace BoomBlik.Modules.Reports.Services
{
    public class TreeReportService(BoomBlikDbContext dbContext, IMapper mapper) : ITreeReportService
    {
        public async Task<TreeReportDto> CreateTreeReportAsync(TreeReportDto treeReport)
        {
            ArgumentNullException.ThrowIfNull(treeReport);

            var entity = mapper.Map<TreeReportEntity>(treeReport);

            dbContext.TreeReports.Add(entity);
            await dbContext.SaveChangesAsync();

            return mapper.Map<TreeReportDto>(entity);
        }

        public async Task DeleteTreeReportAsync(Guid id)
        {
            var treeReport = await dbContext.TreeReports.FindAsync(id);
            await treeReport.AssertEntityFoundOrThrowEntityNotFoundException(id);

            dbContext.TreeReports.Remove(treeReport);
            await dbContext.SaveChangesAsync();
        }

        public async Task<string> GetTemplatePdfUrlAsync(string templatePdfUrl)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTemplatePdfUrlAsync(string templatePdfUrl)
        {
            throw new NotImplementedException();
        }

        public async Task<TreeReportDto> GetTreeReportByIdAsync(Guid id)
        {
            var treeReport = await dbContext.TreeReports.FindAsync(id);
            await treeReport.AssertEntityFoundOrThrowEntityNotFoundException(id);

            return mapper.Map<TreeReportDto>(treeReport);
        }

        public async Task<IEnumerable<TreeReportDto>> GetAllTreeReportsAsync()
        {
            return await dbContext.TreeReports
                .Select(x => mapper.Map<TreeReportDto>(x))
                .ToListAsync();
        }

        public async Task<TreeReportDto> UpdateTreeReportAsync(TreeReportDto treeReportDto)
        {
            var treeReport = await dbContext.TreeReports.FindAsync(treeReportDto.Id);
            await treeReport.AssertEntityFoundOrThrowEntityNotFoundException(treeReportDto.Id);

            mapper.Map(treeReportDto, treeReport);
            await dbContext.SaveChangesAsync();
            return mapper.Map<TreeReportDto>(treeReport);
        }
    }
}
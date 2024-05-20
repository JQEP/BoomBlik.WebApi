using BoomBlik.Core.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using BoomBlik.Core.Infrastructure.Entities;
using AutoMapper;
using BoomBlik.Infrastructure.Repository;
using BoomBlik.Common.Extensions;
using BoomBlik.Core.Domain.Services;

namespace BoomBlik.Modules.Reports.Services
{
    public class TreeReportPdfService(BoomBlikDbContext dbContext, IMapper mapper, IPdfService pdfService)
        : ITreeReportPdfService
    {
        public async Task<TreeReportPdfDto> CreateTreeReportPdfAsync(TreeReportPdfDto treeReportPdf)
        {
            ArgumentNullException.ThrowIfNull(treeReportPdf);

            var entity = mapper.Map<TreeReportPdfEntity>(treeReportPdf);

            dbContext.TreeReportPdfs.Add(entity);
            await dbContext.SaveChangesAsync();

            // Process the PDF
            await pdfService.ProcessPdfAsync(entity.PdfUrl);

            return mapper.Map<TreeReportPdfDto>(entity);
        }

        public async Task DeleteTreeReportPdfAsync(Guid id)
        {
            var treeReportPdf = await dbContext.TreeReportPdfs.FindAsync(id);
            await treeReportPdf.AssertEntityFoundOrThrowEntityNotFoundException(id);

            dbContext.TreeReportPdfs.Remove(treeReportPdf);
            await dbContext.SaveChangesAsync();
        }

        public async Task<TreeReportPdfDto> GetTreeReportPdfByIdAsync(Guid id)
        {
            var treeReportPdf = await dbContext.TreeReportPdfs.FindAsync(id);
            await treeReportPdf.AssertEntityFoundOrThrowEntityNotFoundException(id);

            return mapper.Map<TreeReportPdfDto>(treeReportPdf);
        }

        public async Task<IEnumerable<TreeReportPdfDto>> GetAllTreeReportPdfsAsync()
        {
            return await dbContext.TreeReportPdfs
                .Select(x => mapper.Map<TreeReportPdfDto>(x))
                .ToListAsync();
        }

        public async Task<TreeReportPdfDto> UpdateTreeReportPdfAsync(TreeReportPdfDto treeReportPdfDto)
        {
            var treeReportPdf = await dbContext.TreeReportPdfs.FindAsync(treeReportPdfDto.Id);
            await treeReportPdf.AssertEntityFoundOrThrowEntityNotFoundException(treeReportPdfDto.Id);

            mapper.Map(treeReportPdfDto, treeReportPdf);
            await dbContext.SaveChangesAsync();

            // Process the PDF
            await pdfService.ProcessPdfAsync(treeReportPdf.PdfUrl);

            return mapper.Map<TreeReportPdfDto>(treeReportPdf);
        }
    }
}
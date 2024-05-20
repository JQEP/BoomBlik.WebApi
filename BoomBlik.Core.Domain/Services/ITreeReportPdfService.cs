using BoomBlik.Core.Domain.Dtos;

public interface ITreeReportPdfService
{
    Task<TreeReportPdfDto> GetTreeReportPdfByIdAsync(Guid treeReportPdfId);
    Task<IEnumerable<TreeReportPdfDto>> GetAllTreeReportPdfsAsync();
    Task<TreeReportPdfDto> CreateTreeReportPdfAsync(TreeReportPdfDto treeReportPdfDto);
    Task<TreeReportPdfDto> UpdateTreeReportPdfAsync(TreeReportPdfDto treeReportPdfDto);
    Task DeleteTreeReportPdfAsync(Guid treeReportPdfId);
}
using BoomBlik.Core.Domain.Dtos;

public interface ITreeReportService
{
    Task<TreeReportDto> GetTreeReportByIdAsync(Guid treeReportId);
    Task<IEnumerable<TreeReportDto>> GetAllTreeReportsAsync();
    Task<TreeReportDto> CreateTreeReportAsync(TreeReportDto treeReportDto);
    Task<TreeReportDto> UpdateTreeReportAsync(TreeReportDto treeReportDto);
    Task DeleteTreeReportAsync(Guid treeReportId);
    Task<string> GetTemplatePdfUrlAsync(string templatePdfUrl);
    Task UpdateTemplatePdfUrlAsync(string templatePdfUrl);
}
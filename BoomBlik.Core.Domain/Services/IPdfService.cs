using BoomBlik.Core.Domain.Dtos;

public interface IPdfService
{
    Task<string> GeneratePdfFromTemplateAsync(string templatePdfUrl, TreeReportDto treeReportDto);
    Task SavePdfAsync(string pdfContent, string destinationPath);
    // Other methods as needed
    Task ProcessPdfAsync(string? entityPdfUrl);
}
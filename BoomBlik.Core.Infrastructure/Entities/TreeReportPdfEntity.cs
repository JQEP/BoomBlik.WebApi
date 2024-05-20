using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoomBlik.Core.Infrastructure.Entities;

public class TreeReportPdfEntity : DefaultEntity
{
    [ForeignKey("TreeReport")]
    public Guid TreeReportId { get; set; }
    public string? PdfUrl { get; set; }
}
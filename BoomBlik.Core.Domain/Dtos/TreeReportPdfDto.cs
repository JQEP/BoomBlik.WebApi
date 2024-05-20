namespace BoomBlik.Core.Domain.Dtos;

public class TreeReportPdfDto
{
    public Guid Id { get; set; }
    public Guid TreeReportId { get; set; }
    public string? PdfUrl { get; set; }
    /// <summary>
    /// The date and time the entity was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// The date and time the entity was last modified.
    /// </summary>
    public DateTime ModifiedOn { get; set; }

    /// <summary>
    /// The entity's status.
    /// </summary>
    public bool IsActive { get; set; } = true;
}
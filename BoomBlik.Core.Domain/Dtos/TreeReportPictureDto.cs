namespace BoomBlik.Core.Domain.Dtos;

public class TreeReportPictureDto
{
    public Guid Id { get; set; }
    public Guid TreeReportId { get; set; }
    public string? ImageUrl { get; set; }
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
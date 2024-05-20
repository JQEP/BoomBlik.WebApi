namespace BoomBlik.Core.Domain.Dtos;

public class TreeDto
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string? Location { get; set; }
    public float Longitude { get; set; }
    public float Latitude { get; set; }
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
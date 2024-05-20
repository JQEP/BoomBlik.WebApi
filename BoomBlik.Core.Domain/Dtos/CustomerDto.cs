namespace BoomBlik.Core.Domain.Dtos;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string PrimaryEmail { get; set; }
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
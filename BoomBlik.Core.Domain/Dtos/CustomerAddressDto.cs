namespace BoomBlik.Core.Domain.Dtos;

public class CustomerAddressDto
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string NumberAddition { get; set; }
    public string Zipcode { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public bool IsPrimary { get; set; }
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
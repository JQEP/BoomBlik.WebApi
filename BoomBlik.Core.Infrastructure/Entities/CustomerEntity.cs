using System.ComponentModel.DataAnnotations;

namespace BoomBlik.Core.Infrastructure.Entities;

public class CustomerEntity : DefaultEntity
{
    [Required]
    public string Name { get; set; }
    public string Location { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string PrimaryEmail { get; set; }
}
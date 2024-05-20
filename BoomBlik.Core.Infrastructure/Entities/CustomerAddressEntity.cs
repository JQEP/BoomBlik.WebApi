using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoomBlik.Core.Infrastructure.Entities;

public class CustomerAddressEntity : DefaultEntity
{
    [Required]
    public string Street { get; set; }
    public int Number { get; set; }
    public string NumberAddition { get; set; }
    [Required]
    public string Zipcode { get; set; }
    [Required]
    public string City { get; set; }
    public string Province { get; set; }
    public bool IsPrimary { get; set; }
}
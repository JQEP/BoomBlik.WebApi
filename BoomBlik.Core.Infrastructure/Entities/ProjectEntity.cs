using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoomBlik.Core.Infrastructure.Entities;

public class ProjectEntity : DefaultEntity
{
    [Required]
    public string Name { get; set; }
    public string Location { get; set; }
    [ForeignKey("Customer")]
    public Guid CustomerId { get; set; }
}
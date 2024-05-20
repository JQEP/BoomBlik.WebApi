using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoomBlik.Core.Infrastructure.Entities;

public class TreeEntity : DefaultEntity
{
    [ForeignKey("Project")]
    public Guid ProjectId { get; set; }
    public string? Location { get; set; }
    public float Longitude { get; set; }
    public float Latitude { get; set; }
}
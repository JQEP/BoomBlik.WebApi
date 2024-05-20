using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoomBlik.Core.Infrastructure.Entities;

/// <summary>
/// The default entity.
/// </summary>
public abstract class DefaultEntity
{
    /// <summary>
    /// The ID of the default entity.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    /// <summary>
    /// The date and time the entity was created.
    /// </summary>
    [Required]
    public DateTime CreatedOn { get; set; }
    /// <summary>
    /// The date and time the entity was last modified.
    /// </summary>
    [Required]
    public DateTime ModifiedOn { get; set; }
    /// <summary>
    /// The entity's status.
    /// </summary>
    [Required]
    public bool IsActive { get; set; } = true;
}

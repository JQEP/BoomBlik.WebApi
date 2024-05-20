using BoomBlik.Core.Domain.Enums;

namespace BoomBlik.Core.Domain.Dtos;

public class TreeReportDto
{
    public Guid Id { get; set; }
    public Guid TreeId { get; set; }
    public AdviceEnum Advice { get; set; }
    public string? AdviceAddition { get; set; }
    public TreeHeightEnum TreeHeight { get; set; }
    public string? TreeHeightAddition { get; set; }
    public ConditionEnum Condition { get; set; }
    public string? ConditionAddition { get; set; }
    public GrowthPhaseEnum Groeifase { get; set; }
    public string? GrowthPhaseAddition { get; set; }
    public ISGEnum Crown { get; set; }
    public string? CrownAddition { get; set; }
    public ISGEnum Stem { get; set; }
    public string? StemAddition { get; set; }
    public ISGEnum StemFoot { get; set; }
    public string? StemFootAddition { get; set; }
    public RiskClassEnum RiskClass { get; set; }
    public string? RiskClassAddition { get; set; }
    public OrientationEnum Orientation { get; set; }
    public string? OrientationAddition { get; set; }
    public FutureExpectationEnum FutureExpectation { get; set; }
    public string? FutureExpectationAddition { get; set; }
    public UrgencyEnum Urgency { get; set; }
    public string? UrgencyAddition { get; set; }
    public DateTime Date { get; set; }
    public DateTime DateNextCheck { get; set; }
    public string? TemplatePdfUrl { get; set; }
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
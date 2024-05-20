using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoomBlik.Core.Domain.Enums;

namespace BoomBlik.Core.Infrastructure.Entities;

public class TreeReportEntity : DefaultEntity
{
    [ForeignKey("Tree")]
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
}
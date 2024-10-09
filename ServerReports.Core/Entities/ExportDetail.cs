using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerReports.Core.Entities;

[Table("ExportDetails")]
public class ExportDetail
{
    [Key]
    public Guid Id { get; set; }
    public Guid ExportId { get; set; }
    public string User { get; set; } = string.Empty;
    public DateTime SessionStart { get; set; }
    public DateTime SessionEnd { get; set; }
    public int SessionLength { get; set; }
    public string IpAddress { get; set; } = string.Empty;
    public AuthorizationStatus AuthorizationResult { get; set; }

    [ForeignKey(nameof(ExportId))]
    public virtual Export Export { get; set; }
}
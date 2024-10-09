using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerReports.Core.Entities;

[Table("Exports")]
public class Export
{
    [Key]
    public Guid Id { get; set; }
    public string ExportedBy { get; set; } = string.Empty;
    public DateTime ExportedOn { get; set; }
    public string ExportedSource { get; set; } = string.Empty;

    public virtual ICollection<ExportDetail> ExportDetails { get; set; } = new List<ExportDetail>();
}
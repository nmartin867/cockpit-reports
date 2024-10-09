using Microsoft.EntityFrameworkCore;
using ServerReports.Core.Entities;

namespace ServerReports.Infrastructure.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
    
    public DbSet<Export> Exports { get; set; }
    public DbSet<ExportDetail> ExportDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ApplicationDbContextConfigurations.Configure(modelBuilder);
    }
}
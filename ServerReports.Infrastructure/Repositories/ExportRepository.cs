using ServerReports.Core.Entities;
using ServerReports.Core.Interfaces.IRepositories;
using ServerReports.Infrastructure.Data;

namespace ServerReports.Infrastructure.Repositories;

public class ExportRepository(ApplicationDbContext context) : BaseRepository<Export>(context), IExportRepository
{
    
}
using ServerReports.Core.Interfaces;
using ServerReports.Core.Interfaces.IRepositories;
using ServerReports.Infrastructure.Data;

namespace ServerReports.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public IExportRepository ExportsRepository { get; }

    public UnitOfWork(ApplicationDbContext applicationDbContext, IExportRepository exportsRepository)
    {
        _context = applicationDbContext;
        ExportsRepository = exportsRepository;
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}
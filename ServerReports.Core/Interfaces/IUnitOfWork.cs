using ServerReports.Core.Interfaces.IRepositories;

namespace ServerReports.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IExportRepository ExportsRepository { get; }
    Task<int> SaveChangesAsync();
}
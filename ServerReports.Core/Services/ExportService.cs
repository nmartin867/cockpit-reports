using ServerReports.Core.Interfaces;
using ServerReports.Core.Interfaces.IServices;

namespace ServerReports.Core.Services;

public class ExportService : IExportService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public ExportService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
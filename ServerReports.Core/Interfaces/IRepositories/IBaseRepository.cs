using ServerReports.Core.ViewModels;

namespace ServerReports.Core.Interfaces.IRepositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<PaginatedDataViewModel<TEntity>> GetPaginatedData(int pageNumber, int pageSize);
    Task<TEntity> GetById<TId>(TId id);
    Task<bool> IsExists<TValue>(string key, TValue value);
    Task<bool> IsExistsForUpdate<TId>(TId id, string key, string value);
    Task<TEntity> Create(TEntity model);
    Task CreateRange(List<TEntity> model);
    void Update(TEntity model);
    void Delete(TEntity model);
}
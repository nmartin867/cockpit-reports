using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ServerReports.Core.Exceptions;
using ServerReports.Core.Interfaces.IRepositories;
using ServerReports.Core.ViewModels;
using ServerReports.Infrastructure.Data;

namespace ServerReports.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext context;
    
    protected DbSet<TEntity> DbSet => context.Set<TEntity>();

    public BaseRepository(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<PaginatedDataViewModel<TEntity>> GetPaginatedData(int pageNumber, int pageSize)
    {
        var query = context.Set<TEntity>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking();

        var data = await query.ToListAsync();
        var totalCount = await context.Set<TEntity>().CountAsync();

        return new PaginatedDataViewModel<TEntity>(data, totalCount);
    }

    public async Task<TEntity> GetById<TId>(TId id)
    {
        var data = await context.Set<TEntity>().FindAsync(id);
        return data ?? throw new NotFoundException();
    }

    public async Task<bool> IsExists<TValue>(string key, TValue value)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var property = Expression.Property(parameter, key);
        var constant = Expression.Constant(value);
        var equality = Expression.Equal(property, constant);
        var lambda = Expression.Lambda<Func<TEntity, bool>>(equality, parameter);

        return await context.Set<TEntity>().AnyAsync(lambda);
    }

    public async Task<bool> IsExistsForUpdate<TId>(TId id, string key, string value)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var property = Expression.Property(parameter, key);
        var constant = Expression.Constant(value);
        var equality = Expression.Equal(property, constant);

        var idProperty = Expression.Property(parameter, "Id");
        var idEquality = Expression.NotEqual(idProperty, Expression.Constant(id));

        var combinedExpression = Expression.AndAlso(equality, idEquality);
        var lambda = Expression.Lambda<Func<TEntity, bool>>(combinedExpression, parameter);

        return await context.Set<TEntity>().AnyAsync(lambda);
    }

    public async Task<TEntity> Create(TEntity model)
    {
        await context.Set<TEntity>().AddAsync(model);
        return model;
    }

    public async Task CreateRange(List<TEntity> model)
    {
        await context.Set<TEntity>().AddRangeAsync(model);
    }

    public void Update(TEntity model)
    {
        context.Set<TEntity>().Update(model);
    }

    public void Delete(TEntity model)
    {
        context.Set<TEntity>().Remove(model);
    }
}
using Book.Data.Entities;
using Book.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Book.Data.Repositories;

public class Repository<TEntity>(AppDbContext dbContext)
    : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _dbSet.FirstOrDefault(e => e.Id == id);
        _dbSet.Remove(entity);
        _dbContext.SaveChanges();
    }

    public List<TEntity> GetAll()
    {
        var list = _dbSet.ToList();
        return list;
    }

    public TEntity GetById(int id)
    {
        var entity = _dbSet.FirstOrDefault(e => e.Id == id);
        return entity;
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
        _dbContext.SaveChanges();
    }
}

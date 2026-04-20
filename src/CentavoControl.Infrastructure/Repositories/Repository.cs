using CentavoControl.Domain;
using CentavoControl.Domain.Interfaces;
using CentavoControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CentavoControl.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly CentavoControlDbContext Context;
    protected readonly DbSet<T> DbSet;

    public Repository(CentavoControlDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public virtual T GetById(Guid id)
    {
        var entity = DbSet.Find(id);
        return entity ?? throw new KeyNotFoundException($"{typeof(T).Name} com id '{id}' nao encontrado.");
    }

    public virtual IEnumerable<T> GetAll()
    {
        return DbSet.AsNoTracking().ToList();
    }

    public virtual void Add(T entity)
    {
        DbSet.Add(entity);
        Context.SaveChanges();
    }

    public virtual void Update(T entity)
    {
        DbSet.Update(entity);
        Context.SaveChanges();
    }

    public virtual void Remove(Guid id)
    {
        var entity = DbSet.Find(id);
        if (entity == null)
        {
            return;
        }

        DbSet.Remove(entity);
        Context.SaveChanges();
    }
}


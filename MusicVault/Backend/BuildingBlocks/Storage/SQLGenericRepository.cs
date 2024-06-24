using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MusicVault.Backend.BuildingBlocks.Storage;

public abstract class SQLGenericRepository<T> where T : IDAble {
    private readonly DbContext context;
    private readonly DbSet<T> dbSet;

    public SQLGenericRepository(DbContext dbContext) {
        context = dbContext;
        dbSet = context.Set<T>();
    }

    public T Add(T entity) {
        dbSet.Add(entity);
        context.SaveChanges();
        return entity;
    }

    public T? Get(int id) {
        return dbSet.Find(id);
    }

    public List<T> GetAll() {
        return dbSet.AsEnumerable().ToList();
    }

    public T? Update(T entity) {
        T? foundEntity = Get(entity.Id);
        if (foundEntity == null) { return null; }

        context.Entry(foundEntity).State = EntityState.Detached;
        context.Update(entity);

        context.SaveChanges();
        return entity;
    }
}

using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Shared.Repositories;

public abstract class AbstractRepository<TEntity>(DataContext dbContext) where TEntity : class {

    private readonly DataContext _dbContext = dbContext;

    public async virtual Task<TEntity> Create(TEntity entity) {
        try {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;

        } catch (Exception e) { Debug.WriteLine(e); }

        return null!;
    }

    public async virtual Task<TEntity> GetOne(Expression<Func<TEntity, bool>> exp) {
        try {
            var tEntity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(exp)!;

            return tEntity ?? null!;

        } catch (Exception e) { Debug.WriteLine(e); }
        return null!;
    }
    public async virtual Task<ICollection<TEntity>> GetAll() {
        try {
            var tEntities = await _dbContext.Set<TEntity>().ToListAsync();

            return tEntities ?? null!;

        } catch (Exception e) { Debug.WriteLine(e); }
        return null!;
    }

    public async virtual Task<bool> UpdateEntity(Expression<Func<TEntity, bool>> exp, TEntity updatedEntity) {
        try {
            var tEntity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(exp)!;
            if (tEntity != null) {
                _dbContext.Entry(tEntity).CurrentValues.SetValues(updatedEntity);
                await _dbContext.SaveChangesAsync();

                return true;
            }

        } catch (Exception e) { Debug.WriteLine(e); }
        return false;
    }

    public async virtual Task<bool> RemoveEntity(Expression<Func<TEntity, bool>> exp) {
        try {
            var tEntity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(exp!);
            if (tEntity != null) {
                _dbContext.Set<TEntity>().Remove(tEntity);
                await _dbContext.SaveChangesAsync();

                return true;
            }

        } catch (Exception e) { Debug.WriteLine(e); }
        return false;
    }

    public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> exp) {
        try {
            return await _dbContext.Set<TEntity>().AnyAsync(exp);

        } catch (Exception e) { Debug.WriteLine(e); }
        return false;
    }

    public virtual async Task<bool> Exists(TEntity entity) {
        try {
            foreach (TEntity tEntity in await _dbContext.Set<TEntity>().ToListAsync()) {
                if (entity.Equals(tEntity)) return true;
            }

        } catch (Exception e) { Debug.WriteLine(e); }
        return false;
    }
}

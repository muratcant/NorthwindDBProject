using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindDBProject.Core.DataAccess.EntityFramework
{
    /// <summary>
    /// EntityFramework için hazırlıyor olduğumuz bu repositoriyi daha önceden tasarladığımız generic repositorimiz olan IRepository arayüzünü implemente ederek tasarladık.
    /// Bu şekilde tasarlamamızın ana sebebi ise veritabanına independent(bağımsız) bir durumda kalabilmek. Örneğin MongoDB için ise ilgili provider'ı aracılığı ile MongoDBRepository tasarlayabiliriz.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFRepository<T, TContext> : IRepository<T>
    where T : class, new()
    where TContext : DbContext, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public EFRepository()
        {
            _dbContext = new TContext();
            _dbSet = _dbContext.Set<T>();
        }

        #region CRUD
        IQueryable<T> IRepository<T>.Table => _dbSet;
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            else
            {
                Delete(entity, true);
            }
        }
        public void Delete(T entity, bool realDelete = true)
        {
            if (!realDelete)
            {
                if (entity.GetType().GetProperty("IsDeleted") != null)
                {
                    T _entity = entity;
                    _entity.GetType().GetProperty("IsDeleted")?.SetValue(_entity, true);
                    Update(_entity);
                }
                else
                {
                    throw new Exception("IsDeleted alanı bulunamadı");
                }
            }
            else
            {
                EntityEntry<T> deletedEntity = _dbContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
            }
        }
        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _dbSet.ToList() : _dbSet.Where(filter).ToList();
        }
        public void AddRange(List<T> entities)
        {
            _dbSet.AddRange(entities);
        }
        public void RemoveRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public void RemoveRange(Expression<Func<T, bool>> filter = null)
        {
            var deleted = filter == null ? _dbSet : _dbSet.Where(filter);
            _dbContext.RemoveRange(deleted);
        }
        public int CountAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _dbSet.Count() : _dbSet.Count(filter);
        }
        public bool Any(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Any(filter);
        }
        public double Sum(Expression<Func<T, double>> filter = null)
        {
            return _dbSet.Sum(filter);
        }
        public double Max(Expression<Func<T, double>> filter = null)
        {
            return _dbSet.Max(filter);
        }
        public double Min(Expression<Func<T, double>> filter = null)
        {
            return _dbSet.Min(filter);
        }
        public double Average(Expression<Func<T, double>> filter = null)
        {
            return _dbSet.Average(filter);
        }

        #endregion

        #region AsyncCRUD     
        public async Task<T> GetByIdAsync(int id, CancellationToken token = default)
        {
            return await _dbSet.FindAsync(id, token);
        }
        public async Task AddRangeAsync(List<T> entities, CancellationToken token = default)
        {
            await _dbSet.AddRangeAsync(entities, token);
        }
        public async Task AddAsync(T entity, CancellationToken token = default)
        {
            await _dbSet.AddAsync(entity, token);
        }
        public async Task DeleteAsync(T entity, CancellationToken token = default, bool realDelete = false)
        {
            await Task.Run(async () =>
            {
                if (!realDelete)
                {
                    if (entity.GetType().GetProperty("IsDeleted") != null)
                    {
                        T _entity = entity;
                        _entity.GetType().GetProperty("IsDeleted")?.SetValue(_entity, true);
                        await this.UpdateAsync(_entity, token);
                    }
                    else
                    {
                        throw new Exception("IsDeleted alanı bulunamadı");
                    }
                }
                else
                {
                    EntityEntry<T> deletedEntity = _dbContext.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                }
            }, token);
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await Task.Run(() =>
            {
                var entity = this.GetById(id);
                if (entity == null) return;
                else
                {
                    if (entity.GetType().GetProperty("IsDelete") != null)
                    {
                        T _entity = entity;
                        _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

                        this.Update(_entity);
                    }
                    else
                    {
                        Delete(entity);
                    }
                }
            }, token);

        }
        public async Task UpdateAsync(T entity, CancellationToken token = default)
        {
            await Task.Run(() =>
            {
                _dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }, token);
        }
        public async Task<int> CountAllAsync(CancellationToken token = default, Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return await _dbSet.CountAsync(token);
            }
            return await _dbSet.CountAsync(filter, token);

        }
        public async Task<List<T>> GetAllAsync(CancellationToken token = default, Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return await _dbSet.ToListAsync(token);
            }
            return await _dbSet.Where(filter).ToListAsync(token);

        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, CancellationToken token = default)
        {
            return await _dbSet.FirstOrDefaultAsync(filter, token);
        }
        public async Task RemoveRangeAsync(List<T> entities, CancellationToken token = default)
        {
            await Task.Run(() =>
            {
                _dbSet.RemoveRange(entities);
            }, token);
        }

        public async Task RemoveRangeAsync(Expression<Func<T, bool>> filter = null, CancellationToken token = default)
        {
            await RemoveRangeAsync(GetAll(filter));
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken token = default)
        {
            return await _dbSet.AnyAsync(filter, token);
        }

        public async Task<double> SumAsync(Expression<Func<T, double>> filter = null, CancellationToken token = default)
        {
            return await _dbSet.SumAsync(filter, token);
        }

        public async Task<double> MaxAsync(Expression<Func<T, double>> filter = null, CancellationToken token = default)
        {
            return await _dbSet.MaxAsync(filter, token);
        }

        public async Task<double> MinAsync(Expression<Func<T, double>> filter = null, CancellationToken token = default)
        {
            return await _dbSet.MinAsync(filter, token);
        }

        public async Task<double> AverageAsync(Expression<Func<T, double>> filter = null, CancellationToken token = default)
        {
            return await _dbSet.AverageAsync(filter, token);
        }


        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
        public async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            return await _dbContext.SaveChangesAsync(token);
        }

        #endregion
    }
}

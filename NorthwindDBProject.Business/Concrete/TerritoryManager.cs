using NorthwindDBProject.Business.Abstract;
using NorthwindDBProject.DataAccess.Abstract;
using NorthwindDBProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindDBProject.Business.Concrete
{
    public class TerritoryManager:ITerritoryService
    {
        private readonly ITerritoryDal _territoryDal;
        public TerritoryManager(ITerritoryDal territoryDal)
        {
            _territoryDal = territoryDal;
        }


        #region CRUD
        public void Add(Territory entity)
        {
            _territoryDal.Add(entity);
        }

        public void Delete(Territory entity, bool realDelete = true)
        {
            _territoryDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _territoryDal.Delete(id);
        }

        public void Update(Territory entity)
        {
            _territoryDal.Update(entity);
        }

        public Territory Get(Expression<Func<Territory, bool>> filter)
        {
            return _territoryDal.Get(filter);
        }

        public Territory GetById(int id)
        {
            return _territoryDal.GetById(id);
        }

        public List<Territory> GetAll(Expression<Func<Territory, bool>> filter = null)
        {
            return _territoryDal.GetAll(filter);
        }

        public void AddRange(List<Territory> entities)
        {
            _territoryDal.AddRange(entities);
        }

        public void RemoveRange(List<Territory> entities)
        {
            _territoryDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<Territory, bool>> filter = null)
        {
            _territoryDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<Territory, bool>> filter = null)
        {
            return _territoryDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<Territory> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _territoryDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<Territory> GetAsync(Expression<Func<Territory, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _territoryDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(Territory entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _territoryDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(Territory entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _territoryDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(Territory entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _territoryDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<Territory>> GetAllAsync(Expression<Func<Territory, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _territoryDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<Territory, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _territoryDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<Territory> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _territoryDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<Territory> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _territoryDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<Territory, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _territoryDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _territoryDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _territoryDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

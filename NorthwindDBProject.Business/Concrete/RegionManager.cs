using NorthwindDBProject.Business.Abstract;
using NorthwindDBProject.DataAccess.Abstract;
using NorthwindDBProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindDBProject.Business.Concrete
{
    public class RegionManager : IRegionService
    {
        private readonly IRegionDal _regionDal;
        public RegionManager(IRegionDal regionDal)
        {
            _regionDal = regionDal;
        }


        #region CRUD
        public void Add(Region entity)
        {
            _regionDal.Add(entity);
        }

        public void Delete(Region entity, bool realDelete = true)
        {
            _regionDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _regionDal.Delete(id);
        }

        public void Update(Region entity)
        {
            _regionDal.Update(entity);
        }

        public Region Get(Expression<Func<Region, bool>> filter)
        {
            return _regionDal.Get(filter);
        }

        public Region GetById(int id)
        {
            return _regionDal.GetById(id);
        }

        public List<Region> GetAll(Expression<Func<Region, bool>> filter = null)
        {
            return _regionDal.GetAll(filter);
        }

        public void AddRange(List<Region> entities)
        {
            _regionDal.AddRange(entities);
        }

        public void RemoveRange(List<Region> entities)
        {
            _regionDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<Region, bool>> filter = null)
        {
            _regionDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<Region, bool>> filter = null)
        {
            return _regionDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<Region> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _regionDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<Region> GetAsync(Expression<Func<Region, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _regionDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(Region entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _regionDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(Region entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _regionDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(Region entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _regionDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<Region>> GetAllAsync(Expression<Func<Region, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _regionDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<Region, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _regionDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<Region> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _regionDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<Region> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _regionDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<Region, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _regionDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _regionDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _regionDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

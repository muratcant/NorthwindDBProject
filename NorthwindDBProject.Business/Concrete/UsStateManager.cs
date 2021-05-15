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
    public class UsStateManager : IUsStateService
    {
        private readonly IUsStateDal _usStateDal;
        public UsStateManager(IUsStateDal usStateDal)
        {
            _usStateDal = usStateDal;
        }
        #region CRUD
        public void Add(UsState entity)
        {
            _usStateDal.Add(entity);
        }

        public void Delete(UsState entity, bool realDelete = true)
        {
            _usStateDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _usStateDal.Delete(id);
        }

        public void Update(UsState entity)
        {
            _usStateDal.Update(entity);
        }

        public UsState Get(Expression<Func<UsState, bool>> filter)
        {
            return _usStateDal.Get(filter);
        }

        public UsState GetById(int id)
        {
            return _usStateDal.GetById(id);
        }

        public List<UsState> GetAll(Expression<Func<UsState, bool>> filter = null)
        {
            return _usStateDal.GetAll(filter);
        }

        public void AddRange(List<UsState> entities)
        {
            _usStateDal.AddRange(entities);
        }

        public void RemoveRange(List<UsState> entities)
        {
            _usStateDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<UsState, bool>> filter = null)
        {
            _usStateDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<UsState, bool>> filter = null)
        {
            return _usStateDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<UsState> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _usStateDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<UsState> GetAsync(Expression<Func<UsState, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _usStateDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(UsState entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _usStateDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(UsState entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _usStateDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(UsState entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _usStateDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<UsState>> GetAllAsync(Expression<Func<UsState, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _usStateDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<UsState, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _usStateDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<UsState> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _usStateDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<UsState> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _usStateDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<UsState, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _usStateDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _usStateDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _usStateDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

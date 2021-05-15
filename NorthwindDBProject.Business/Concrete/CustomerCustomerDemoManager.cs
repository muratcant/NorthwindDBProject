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
    public class CustomerCustomerDemoManager:ICustomerCustomerDemoService
    {
        private readonly ICustomerCustomerDemoDal _customerCustomerDemoDal;
        public CustomerCustomerDemoManager(ICustomerCustomerDemoDal customerCustomerDemoDal)
        {
            _customerCustomerDemoDal = customerCustomerDemoDal;
        }

        #region CRUD
        public void Add(CustomerCustomerDemo entity)
        {
            _customerCustomerDemoDal.Add(entity);
        }

        public void Delete(CustomerCustomerDemo entity, bool realDelete = true)
        {
            _customerCustomerDemoDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _customerCustomerDemoDal.Delete(id);
        }

        public void Update(CustomerCustomerDemo entity)
        {
            _customerCustomerDemoDal.Update(entity);
        }

        public CustomerCustomerDemo Get(Expression<Func<CustomerCustomerDemo, bool>> filter)
        {
            return _customerCustomerDemoDal.Get(filter);
        }

        public CustomerCustomerDemo GetById(int id)
        {
            return _customerCustomerDemoDal.GetById(id);
        }

        public List<CustomerCustomerDemo> GetAll(Expression<Func<CustomerCustomerDemo, bool>> filter = null)
        {
            return _customerCustomerDemoDal.GetAll(filter);
        }

        public void AddRange(List<CustomerCustomerDemo> entities)
        {
            _customerCustomerDemoDal.AddRange(entities);
        }

        public void RemoveRange(List<CustomerCustomerDemo> entities)
        {
            _customerCustomerDemoDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<CustomerCustomerDemo, bool>> filter = null)
        {
            _customerCustomerDemoDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<CustomerCustomerDemo, bool>> filter = null)
        {
            return _customerCustomerDemoDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<CustomerCustomerDemo> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerCustomerDemoDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<CustomerCustomerDemo> GetAsync(Expression<Func<CustomerCustomerDemo, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerCustomerDemoDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(CustomerCustomerDemo entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerCustomerDemoDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(CustomerCustomerDemo entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerCustomerDemoDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(CustomerCustomerDemo entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerCustomerDemoDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<CustomerCustomerDemo>> GetAllAsync(Expression<Func<CustomerCustomerDemo, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerCustomerDemoDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<CustomerCustomerDemo, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerCustomerDemoDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<CustomerCustomerDemo> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerCustomerDemoDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<CustomerCustomerDemo> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerCustomerDemoDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<CustomerCustomerDemo, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerCustomerDemoDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _customerCustomerDemoDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerCustomerDemoDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

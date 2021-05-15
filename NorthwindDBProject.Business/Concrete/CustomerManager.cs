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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        #region CRUD
        public void Add(Customer entity)
        {
            _customerDal.Add(entity);
        }

        public void Delete(Customer entity, bool realDelete = true)
        {
            _customerDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _customerDal.Delete(id);
        }

        public void Update(Customer entity)
        {
            _customerDal.Update(entity);
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            return _customerDal.Get(filter);
        }

        public Customer GetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return _customerDal.GetAll(filter);
        }

        public void AddRange(List<Customer> entities)
        {
            _customerDal.AddRange(entities);
        }

        public void RemoveRange(List<Customer> entities)
        {
            _customerDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<Customer, bool>> filter = null)
        {
            _customerDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<Customer, bool>> filter = null)
        {
            return _customerDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<Customer> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(Customer entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(Customer entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(Customer entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<Customer>> GetAllAsync(Expression<Func<Customer, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<Customer, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<Customer> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<Customer> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<Customer, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _customerDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

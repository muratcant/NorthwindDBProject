using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NorthwindDBProject.Business.Abstract;
using NorthwindDBProject.DataAccess.Abstract;
using NorthwindDBProject.Entities.Entities;

namespace NorthwindDBProject.Business.Concrete
{
    public class CustomerDemographicManager : ICustomerDemographicService
    {
        private readonly ICustomerDemographicDal _customerDemographicDal;
        public CustomerDemographicManager(ICustomerDemographicDal customerDemographicDal)
        {
            _customerDemographicDal = customerDemographicDal;
        }

        #region CRUD
        public void Add(CustomerDemographic entity)
        {
            _customerDemographicDal.Add(entity);
        }

        public void Delete(CustomerDemographic entity, bool realDelete = true)
        {
            _customerDemographicDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _customerDemographicDal.Delete(id);
        }

        public void Update(CustomerDemographic entity)
        {
            _customerDemographicDal.Update(entity);
        }

        public CustomerDemographic Get(Expression<Func<CustomerDemographic, bool>> filter)
        {
            return _customerDemographicDal.Get(filter);
        }

        public CustomerDemographic GetById(int id)
        {
            return _customerDemographicDal.GetById(id);
        }

        public List<CustomerDemographic> GetAll(Expression<Func<CustomerDemographic, bool>> filter = null)
        {
            return _customerDemographicDal.GetAll(filter);
        }

        public void AddRange(List<CustomerDemographic> entities)
        {
            _customerDemographicDal.AddRange(entities);
        }

        public void RemoveRange(List<CustomerDemographic> entities)
        {
            _customerDemographicDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<CustomerDemographic, bool>> filter = null)
        {
            _customerDemographicDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<CustomerDemographic, bool>> filter = null)
        {
            return _customerDemographicDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<CustomerDemographic> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerDemographicDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<CustomerDemographic> GetAsync(Expression<Func<CustomerDemographic, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerDemographicDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(CustomerDemographic entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerDemographicDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(CustomerDemographic entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerDemographicDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(CustomerDemographic entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerDemographicDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<CustomerDemographic>> GetAllAsync(Expression<Func<CustomerDemographic, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerDemographicDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<CustomerDemographic, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerDemographicDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<CustomerDemographic> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerDemographicDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<CustomerDemographic> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerDemographicDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<CustomerDemographic, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _customerDemographicDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _customerDemographicDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _customerDemographicDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

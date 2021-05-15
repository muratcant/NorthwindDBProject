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
    public class SupplierManager:ISupplierService
    {
        private readonly ISupplierDal _supplierDal;
        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        #region CRUD
        public void Add(Supplier entity)
        {
            _supplierDal.Add(entity);
        }

        public void Delete(Supplier entity, bool realDelete = true)
        {
            _supplierDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _supplierDal.Delete(id);
        }

        public void Update(Supplier entity)
        {
            _supplierDal.Update(entity);
        }

        public Supplier Get(Expression<Func<Supplier, bool>> filter)
        {
            return _supplierDal.Get(filter);
        }

        public Supplier GetById(int id)
        {
            return _supplierDal.GetById(id);
        }

        public List<Supplier> GetAll(Expression<Func<Supplier, bool>> filter = null)
        {
            return _supplierDal.GetAll(filter);
        }

        public void AddRange(List<Supplier> entities)
        {
            _supplierDal.AddRange(entities);
        }

        public void RemoveRange(List<Supplier> entities)
        {
            _supplierDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<Supplier, bool>> filter = null)
        {
            _supplierDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<Supplier, bool>> filter = null)
        {
            return _supplierDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<Supplier> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _supplierDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<Supplier> GetAsync(Expression<Func<Supplier, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _supplierDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(Supplier entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _supplierDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(Supplier entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _supplierDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(Supplier entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _supplierDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<Supplier>> GetAllAsync(Expression<Func<Supplier, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _supplierDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<Supplier, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _supplierDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<Supplier> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _supplierDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<Supplier> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _supplierDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<Supplier, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _supplierDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _supplierDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _supplierDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

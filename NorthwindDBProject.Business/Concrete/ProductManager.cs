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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        #region CRUD
        public void Add(Product entity)
        {
            _productDal.Add(entity);
        }

        public void Delete(Product entity, bool realDelete = true)
        {
            _productDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _productDal.Delete(id);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _productDal.Get(filter);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.GetAll(filter);
        }

        public void AddRange(List<Product> entities)
        {
            _productDal.AddRange(entities);
        }

        public void RemoveRange(List<Product> entities)
        {
            _productDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<Product, bool>> filter = null)
        {
            _productDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<Product> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _productDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _productDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(Product entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _productDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(Product entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _productDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(Product entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _productDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _productDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<Product, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _productDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<Product> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _productDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<Product> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _productDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<Product, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _productDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _productDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _productDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

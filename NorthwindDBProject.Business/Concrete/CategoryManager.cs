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
    public class CategoryManager:ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        #region CRUD
        public void Add(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void Delete(Category entity, bool realDelete = true)
        {
            _categoryDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _categoryDal.Delete(id);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.Get(filter);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetAll(filter);
        }

        public void AddRange(List<Category> entities)
        {
            _categoryDal.AddRange(entities);
        }

        public void RemoveRange(List<Category> entities)
        {
            _categoryDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<Category, bool>> filter = null)
        {
            _categoryDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<Category> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _categoryDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _categoryDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(Category entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _categoryDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(Category entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _categoryDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(Category entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _categoryDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _categoryDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<Category, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _categoryDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<Category> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _categoryDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<Category> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _categoryDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<Category, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _categoryDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _categoryDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _categoryDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }


        #region CRUD
        public void Add(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void Delete(Order entity, bool realDelete = true)
        {
            _orderDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _orderDal.Delete(id);
        }

        public void Update(Order entity)
        {
            _orderDal.Update(entity);
        }

        public Order Get(Expression<Func<Order, bool>> filter)
        {
            return _orderDal.Get(filter);
        }

        public Order GetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public List<Order> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            return _orderDal.GetAll(filter);
        }

        public void AddRange(List<Order> entities)
        {
            _orderDal.AddRange(entities);
        }

        public void RemoveRange(List<Order> entities)
        {
            _orderDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<Order, bool>> filter = null)
        {
            _orderDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<Order, bool>> filter = null)
        {
            return _orderDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<Order> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _orderDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _orderDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(Order entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _orderDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(Order entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _orderDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(Order entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _orderDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<Order>> GetAllAsync(Expression<Func<Order, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _orderDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<Order, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _orderDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<Order> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _orderDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<Order> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _orderDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<Order, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _orderDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _orderDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _orderDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

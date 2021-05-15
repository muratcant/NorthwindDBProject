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
    public class OrderDetailManager:IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }


        #region CRUD
        public void Add(OrderDetail entity)
        {
            _orderDetailDal.Add(entity);
        }

        public void Delete(OrderDetail entity, bool realDelete = true)
        {
            _orderDetailDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _orderDetailDal.Delete(id);
        }

        public void Update(OrderDetail entity)
        {
            _orderDetailDal.Update(entity);
        }

        public OrderDetail Get(Expression<Func<OrderDetail, bool>> filter)
        {
            return _orderDetailDal.Get(filter);
        }

        public OrderDetail GetById(int id)
        {
            return _orderDetailDal.GetById(id);
        }

        public List<OrderDetail> GetAll(Expression<Func<OrderDetail, bool>> filter = null)
        {
            return _orderDetailDal.GetAll(filter);
        }

        public void AddRange(List<OrderDetail> entities)
        {
            _orderDetailDal.AddRange(entities);
        }

        public void RemoveRange(List<OrderDetail> entities)
        {
            _orderDetailDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<OrderDetail, bool>> filter = null)
        {
            _orderDetailDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<OrderDetail, bool>> filter = null)
        {
            return _orderDetailDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<OrderDetail> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _orderDetailDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<OrderDetail> GetAsync(Expression<Func<OrderDetail, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _orderDetailDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(OrderDetail entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _orderDetailDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(OrderDetail entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _orderDetailDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(OrderDetail entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _orderDetailDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<OrderDetail>> GetAllAsync(Expression<Func<OrderDetail, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _orderDetailDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<OrderDetail, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _orderDetailDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<OrderDetail> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _orderDetailDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<OrderDetail> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _orderDetailDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<OrderDetail, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _orderDetailDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _orderDetailDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _orderDetailDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

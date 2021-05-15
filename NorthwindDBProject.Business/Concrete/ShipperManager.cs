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
    public class ShipperManager : IShipperService
    {
        private readonly IShipperDal _shipperDal;
        public ShipperManager(IShipperDal supplierDal)
        {
            _shipperDal = supplierDal;
        }


        #region CRUD
        public void Add(Shipper entity)
        {
            _shipperDal.Add(entity);
        }

        public void Delete(Shipper entity, bool realDelete = true)
        {
            _shipperDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _shipperDal.Delete(id);
        }

        public void Update(Shipper entity)
        {
            _shipperDal.Update(entity);
        }

        public Shipper Get(Expression<Func<Shipper, bool>> filter)
        {
            return _shipperDal.Get(filter);
        }

        public Shipper GetById(int id)
        {
            return _shipperDal.GetById(id);
        }

        public List<Shipper> GetAll(Expression<Func<Shipper, bool>> filter = null)
        {
            return _shipperDal.GetAll(filter);
        }

        public void AddRange(List<Shipper> entities)
        {
            _shipperDal.AddRange(entities);
        }

        public void RemoveRange(List<Shipper> entities)
        {
            _shipperDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<Shipper, bool>> filter = null)
        {
            _shipperDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<Shipper, bool>> filter = null)
        {
            return _shipperDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<Shipper> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _shipperDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<Shipper> GetAsync(Expression<Func<Shipper, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _shipperDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(Shipper entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _shipperDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(Shipper entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _shipperDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(Shipper entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _shipperDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<Shipper>> GetAllAsync(Expression<Func<Shipper, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _shipperDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<Shipper, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _shipperDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<Shipper> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _shipperDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<Shipper> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _shipperDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<Shipper, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _shipperDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _shipperDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _shipperDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

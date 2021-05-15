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
    public class EmployeeTerritoryManager : IEmployeeTerritoryService
    {
        private readonly IEmployeeTerritoryDal _employeeTerritoryDal;
        public EmployeeTerritoryManager(IEmployeeTerritoryDal employeeTerritoryDal)
        {
            _employeeTerritoryDal = employeeTerritoryDal;
        }

        
        #region CRUD
        public void Add(EmployeeTerritory entity)
        {
            _employeeTerritoryDal.Add(entity);
        }

        public void Delete(EmployeeTerritory entity, bool realDelete = true)
        {
            _employeeTerritoryDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _employeeTerritoryDal.Delete(id);
        }

        public void Update(EmployeeTerritory entity)
        {
            _employeeTerritoryDal.Update(entity);
        }

        public EmployeeTerritory Get(Expression<Func<EmployeeTerritory, bool>> filter)
        {
            return _employeeTerritoryDal.Get(filter);
        }

        public EmployeeTerritory GetById(int id)
        {
            return _employeeTerritoryDal.GetById(id);
        }

        public List<EmployeeTerritory> GetAll(Expression<Func<EmployeeTerritory, bool>> filter = null)
        {
            return _employeeTerritoryDal.GetAll(filter);
        }

        public void AddRange(List<EmployeeTerritory> entities)
        {
            _employeeTerritoryDal.AddRange(entities);
        }

        public void RemoveRange(List<EmployeeTerritory> entities)
        {
            _employeeTerritoryDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<EmployeeTerritory, bool>> filter = null)
        {
            _employeeTerritoryDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<EmployeeTerritory, bool>> filter = null)
        {
            return _employeeTerritoryDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<EmployeeTerritory> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _employeeTerritoryDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<EmployeeTerritory> GetAsync(Expression<Func<EmployeeTerritory, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _employeeTerritoryDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(EmployeeTerritory entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _employeeTerritoryDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(EmployeeTerritory entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _employeeTerritoryDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(EmployeeTerritory entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _employeeTerritoryDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<EmployeeTerritory>> GetAllAsync(Expression<Func<EmployeeTerritory, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _employeeTerritoryDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<EmployeeTerritory, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _employeeTerritoryDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<EmployeeTerritory> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _employeeTerritoryDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<EmployeeTerritory> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _employeeTerritoryDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<EmployeeTerritory, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _employeeTerritoryDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _employeeTerritoryDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _employeeTerritoryDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

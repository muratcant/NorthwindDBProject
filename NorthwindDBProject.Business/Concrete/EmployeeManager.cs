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
    public class EmployeeManager:IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }


        #region CRUD
        public void Add(Employee entity)
        {
            _employeeDal.Add(entity);
        }

        public void Delete(Employee entity, bool realDelete = true)
        {
            _employeeDal.Delete(entity, realDelete);
        }

        public void Delete(int id)
        {
            _employeeDal.Delete(id);
        }

        public void Update(Employee entity)
        {
            _employeeDal.Update(entity);
        }

        public Employee Get(Expression<Func<Employee, bool>> filter)
        {
            return _employeeDal.Get(filter);
        }

        public Employee GetById(int id)
        {
            return _employeeDal.GetById(id);
        }

        public List<Employee> GetAll(Expression<Func<Employee, bool>> filter = null)
        {
            return _employeeDal.GetAll(filter);
        }

        public void AddRange(List<Employee> entities)
        {
            _employeeDal.AddRange(entities);
        }

        public void RemoveRange(List<Employee> entities)
        {
            _employeeDal.RemoveRange(entities);
        }

        public void RemoveRange(Expression<Func<Employee, bool>> filter = null)
        {
            _employeeDal.RemoveRange(filter);
        }

        public int CountAll(Expression<Func<Employee, bool>> filter = null)
        {
            return _employeeDal.CountAll(filter);
        }

        #endregion

        #region AsyncCRUD
        public async Task<Employee> GetByIdAsync(int id)
        {
            var cancelToken = new CancellationTokenSource();
            return await _employeeDal.GetByIdAsync(id, cancelToken.Token);
        }

        public async Task<Employee> GetAsync(Expression<Func<Employee, bool>> filter)
        {
            var cancelToken = new CancellationTokenSource();
            return await _employeeDal.GetAsync(filter, cancelToken.Token);
        }

        public async Task AddAsync(Employee entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _employeeDal.AddAsync(entity, cancelToken.Token);
        }

        public async Task UpdateAsync(Employee entity)
        {
            var cancelToken = new CancellationTokenSource();
            await _employeeDal.UpdateAsync(entity, cancelToken.Token);
        }

        public async Task DeleteAsync(Employee entity, bool realDelete = false)
        {
            var cancelToken = new CancellationTokenSource();
            await _employeeDal.DeleteAsync(entity, cancelToken.Token, realDelete);
        }

        public async Task<List<Employee>> GetAllAsync(Expression<Func<Employee, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _employeeDal.GetAllAsync(cancelToken.Token, filter);
        }

        public async Task<int> CountAllAsync(Expression<Func<Employee, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            return await _employeeDal.CountAllAsync(cancelToken.Token, filter);
        }

        public async Task AddRangeAsync(List<Employee> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _employeeDal.AddRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(List<Employee> entities)
        {
            var cancelToken = new CancellationTokenSource();
            await _employeeDal.RemoveRangeAsync(entities, cancelToken.Token);
        }

        public async Task RemoveRangeAsync(Expression<Func<Employee, bool>> filter = null)
        {
            var cancelToken = new CancellationTokenSource();
            await _employeeDal.RemoveRangeAsync(filter, cancelToken.Token);
        }

        #endregion

        #region UnitofWork
        public int SaveChanges()
        {
            return _employeeDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancelToken = new CancellationTokenSource();
            return await _employeeDal.SaveChangesAsync(cancelToken.Token);
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}

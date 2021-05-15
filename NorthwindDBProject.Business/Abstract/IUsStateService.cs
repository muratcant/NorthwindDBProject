using NorthwindDBProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDBProject.Business.Abstract
{
    public interface IUsStateService
    {
        #region CRUD
        /// <summary>
        /// Filtreleme yaptıktan sonra gönderilen tipe ait bir liste döndürür
        /// </summary>
        /// <param name="filter"></param>
        /// <returns> </returns>
        List<UsState> GetAll(Expression<Func<UsState, bool>> filter = null);
        UsState Get(Expression<Func<UsState, bool>> filter);
        UsState GetById(int id);
        void Add(UsState entity);
        void Update(UsState entity);
        void Delete(UsState entity, bool realDelete = false);
        void Delete(int id);
        void AddRange(List<UsState> entities);
        void RemoveRange(List<UsState> entities);
        void RemoveRange(Expression<Func<UsState, bool>> filter = null);
        #endregion

        #region AsyncCRUD
        /// <summary>
        /// Eğer DbSet in PK sı int ise EF Find metodu ile asenkron olarak bulur ve döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UsState> GetByIdAsync(int id);
        /// <summary>
        /// Asenkron olarak filtreleme yaptıktan sonra ilk Entity'yi döndürür.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<UsState> GetAsync(Expression<Func<UsState, bool>> filter);
        /// <summary>
        /// Gönderilen Entity yi asenkron olarak veritabanına ekler (insert)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(UsState entity);
        /// <summary>
        /// Gönderilen Entity'yi asenkron olarak veritabanında günceller (update)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(UsState entity);
        /// <summary>
        /// Gönderilen Entity'nin IsDeleted özelliği var ise true yapıp günceller yok ise siler. (delete)
        /// RealDelete özelliği true ise direkt siler.
        /// Asenkron olarak çalışır.
        /// </summary>
        /// <param name="entity" value="entity"></param>
        /// <param name="realDelete"></param>
        /// <returns></returns>
        Task DeleteAsync(UsState entity, bool realDelete = false);
        /// <summary>
        /// Filtreme yaptıktan sonra gönderilen tipe ait bir listeyi asenkron olarak döndürür.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<UsState>> GetAllAsync(Expression<Func<UsState, bool>> filter = null);
        /// <summary>
        /// Filtre boş ise tablo boyutunu, dolu ise filtremele sonucuna göre tablo boyutu döndürür.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<int> CountAllAsync(Expression<Func<UsState, bool>> filter = null);
        /// <summary>
        /// Gönderilen listeyi bulk halinde asenkron olarak veritabanına ekler (insert into)
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddRangeAsync(List<UsState> entities);
        /// <summary>
        /// Gönderilen Listeyi bulk halinde asenkron olarak veri tabanından siler
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(List<UsState> entities);
        Task RemoveRangeAsync(Expression<Func<UsState, bool>> filter = null);
        #endregion

        #region UnitofWork
        /// <summary>
        /// Yaptığımız değişiklikleri veritabanına kayıt işlemini gerçekleştirir.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
        /// <summary>
        /// Yaptığımız değişiklikleri asekron olarak veritabanına kayıt işlemini gerçekleştirir.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
        #endregion

        #region CustomMethods

        #endregion
    }
}

using NorthwindDBProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDBProject.Business.Abstract
{
    public interface IShipperService
    {
        #region CRUD
        /// <summary>
        /// Filtreleme yaptıktan sonra gönderilen tipe ait bir liste döndürür
        /// </summary>
        /// <param name="filter"></param>
        /// <returns> </returns>
        List<Shipper> GetAll(Expression<Func<Shipper, bool>> filter = null);
        Shipper Get(Expression<Func<Shipper, bool>> filter);
        Shipper GetById(int id);
        void Add(Shipper entity);
        void Update(Shipper entity);
        void Delete(Shipper entity, bool realDelete = false);
        void Delete(int id);
        void AddRange(List<Shipper> entities);
        void RemoveRange(List<Shipper> entities);
        void RemoveRange(Expression<Func<Shipper, bool>> filter = null);
        #endregion

        #region AsyncCRUD
        /// <summary>
        /// Eğer DbSet in PK sı int ise EF Find metodu ile asenkron olarak bulur ve döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Shipper> GetByIdAsync(int id);
        /// <summary>
        /// Asenkron olarak filtreleme yaptıktan sonra ilk Entity'yi döndürür.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<Shipper> GetAsync(Expression<Func<Shipper, bool>> filter);
        /// <summary>
        /// Gönderilen Entity yi asenkron olarak veritabanına ekler (insert)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(Shipper entity);
        /// <summary>
        /// Gönderilen Entity'yi asenkron olarak veritabanında günceller (update)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(Shipper entity);
        /// <summary>
        /// Gönderilen Entity'nin IsDeleted özelliği var ise true yapıp günceller yok ise siler. (delete)
        /// RealDelete özelliği true ise direkt siler.
        /// Asenkron olarak çalışır.
        /// </summary>
        /// <param name="entity" value="entity"></param>
        /// <param name="realDelete"></param>
        /// <returns></returns>
        Task DeleteAsync(Shipper entity, bool realDelete = false);
        /// <summary>
        /// Filtreme yaptıktan sonra gönderilen tipe ait bir listeyi asenkron olarak döndürür.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<Shipper>> GetAllAsync(Expression<Func<Shipper, bool>> filter = null);
        /// <summary>
        /// Filtre boş ise tablo boyutunu, dolu ise filtremele sonucuna göre tablo boyutu döndürür.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<int> CountAllAsync(Expression<Func<Shipper, bool>> filter = null);
        /// <summary>
        /// Gönderilen listeyi bulk halinde asenkron olarak veritabanına ekler (insert into)
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddRangeAsync(List<Shipper> entities);
        /// <summary>
        /// Gönderilen Listeyi bulk halinde asenkron olarak veri tabanından siler
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(List<Shipper> entities);
        Task RemoveRangeAsync(Expression<Func<Shipper, bool>> filter = null);
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

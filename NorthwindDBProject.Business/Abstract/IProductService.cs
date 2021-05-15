using NorthwindDBProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDBProject.Business.Abstract
{
    public interface IProductService
    {
        #region CRUD
        /// <summary>
        /// Filtreleme yaptıktan sonra gönderilen tipe ait bir liste döndürür
        /// </summary>
        /// <param name="filter"></param>
        /// <returns> </returns>
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
        Product Get(Expression<Func<Product, bool>> filter);
        Product GetById(int id);
        void Add(Product entity);
        void Update(Product entity);
        void Delete(Product entity, bool realDelete = false);
        void Delete(int id);
        void AddRange(List<Product> entities);
        void RemoveRange(List<Product> entities);
        void RemoveRange(Expression<Func<Product, bool>> filter = null);
        #endregion

        #region AsyncCRUD
        /// <summary>
        /// Eğer DbSet in PK sı int ise EF Find metodu ile asenkron olarak bulur ve döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetByIdAsync(int id);
        /// <summary>
        /// Asenkron olarak filtreleme yaptıktan sonra ilk Entity'yi döndürür.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<Product> GetAsync(Expression<Func<Product, bool>> filter);
        /// <summary>
        /// Gönderilen Entity yi asenkron olarak veritabanına ekler (insert)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(Product entity);
        /// <summary>
        /// Gönderilen Entity'yi asenkron olarak veritabanında günceller (update)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(Product entity);
        /// <summary>
        /// Gönderilen Entity'nin IsDeleted özelliği var ise true yapıp günceller yok ise siler. (delete)
        /// RealDelete özelliği true ise direkt siler.
        /// Asenkron olarak çalışır.
        /// </summary>
        /// <param name="entity" value="entity"></param>
        /// <param name="realDelete"></param>
        /// <returns></returns>
        Task DeleteAsync(Product entity, bool realDelete = false);
        /// <summary>
        /// Filtreme yaptıktan sonra gönderilen tipe ait bir listeyi asenkron olarak döndürür.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null);
        /// <summary>
        /// Filtre boş ise tablo boyutunu, dolu ise filtremele sonucuna göre tablo boyutu döndürür.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<int> CountAllAsync(Expression<Func<Product, bool>> filter = null);
        /// <summary>
        /// Gönderilen listeyi bulk halinde asenkron olarak veritabanına ekler (insert into)
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddRangeAsync(List<Product> entities);
        /// <summary>
        /// Gönderilen Listeyi bulk halinde asenkron olarak veri tabanından siler
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(List<Product> entities);
        Task RemoveRangeAsync(Expression<Func<Product, bool>> filter = null);
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

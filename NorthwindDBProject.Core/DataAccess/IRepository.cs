using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindDBProject.Core.DataAccess
{
    public interface IRepository<T> where T: class,new ()
    {
        #region CRUD
        /// <summary>
        /// Direkt Context e erişir. İlişkili tablolar ile işlem yapılabilir
        /// </summary>
        IQueryable<T> Table { get; }
        /// <summary>
        /// Filtreme yaptıktan sonra gönderilen tipe ait bir liste döndürür
        /// </summary>
        /// <param name="filter"></param>
        /// <returns> </returns>
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        /// <summary>
        /// Filtreleme yaptıktan sonra ilk entity yi döndürür
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> filter);
        /// <summary>
        /// Eğer DbSet in PK sı int ise EF Find metodu ile bulur ve döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);
        /// <summary>
        /// Gönderilen Entity yi veritabanına ekler (insert)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Add(T entity);
        /// <summary>
        /// Gönderilen Entity yi veritabanında günceller (update)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(T entity);
        /// <summary>
        /// Gönderilen Entity'nin IsDeleted özelliği var ise true yapıp günceller yok ise siler. (delete)
        /// realDelete özelliği true ise direkt siler
        /// </summary>
        /// <param name="entity" value="entity"></param>
        /// <param name="realDelete"></param>
        /// <returns></returns>
        void Delete(T entity, bool realDelete = true); //int Id de gönderebilrdik ama her zaman primary key int olmayabilir, o yüzden T gönderiyoruz.
        void Delete(int id);
        /// <summary>
        ///  Gönderilen listeyi bulk olarak veritabanına ekler
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        void AddRange(List<T> entities);
        /// <summary>
        /// Gönderilen Listeyi bulk olarak veri tabanından siler
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        void RemoveRange(List<T> entities);
        void RemoveRange(Expression<Func<T, bool>> filter = null);

        bool Any(Expression<Func<T, bool>> filter);
        /// <summary>
        /// Gönderilen filter içindeki toplam değeri kullanıcıya verir.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        double Sum(Expression<Func<T, double>> filter = null);
        double Max(Expression<Func<T, double>> filter = null);
        double Min(Expression<Func<T, double>> filter = null);
        double Average(Expression<Func<T, double>> filter = null);

        int CountAll(Expression<Func<T, bool>> filter = null);
        #endregion

        #region AsyncCRUD
        /// <summary>
        /// Eğer DbSet in PK sı int ise EF Find metodu ile asenkron olarak bulur ve döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id, CancellationToken token = default);
        /// <summary>
        /// Asenkron olarak filtreleme yaptıktan sonra ilk Entity'yi döndürür
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<T> GetAsync(Expression<Func<T, bool>> filter, CancellationToken token = default);
        /// <summary>
        /// Gönderilen Entity yi asenkron olarak veritabanına ekler (insert)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(T entity, CancellationToken token = default);
        /// <summary>
        /// Gönderilen Entity'yi asenkron olarak veritabanında günceller (update)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity, CancellationToken token = default);
        /// <summary>
        /// Gönderilen Entity'nin IsDeleted özelliği var ise true yapıp günceller yok ise siler. (delete)
        /// RealDelete özelliği true ise direkt siler.
        /// Asenkron olarak çalışır.
        /// </summary>
        /// <param name="entity" value="entity"></param>
        /// <param name="realDelete"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity, CancellationToken token = default, bool realDelete = false);
        /// <summary>
        /// Filtreme yaptıktan sonra gönderilen tipe ait bir listeyi asenkron olarak döndürür.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns> </returns>
        Task<List<T>> GetAllAsync(CancellationToken token = default, Expression<Func<T, bool>> filter = null);
        /// <summary>
        /// Filtre boş ise tablo boyutunu, dolu ise filtremele sonucuna göre tablo boyutu döndürür.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<int> CountAllAsync(CancellationToken token = default, Expression<Func<T, bool>> filter = null);
        /// <summary>
        ///  Gönderilen listeyi bulk halinde asenkron olarak veritabanına ekler (insert into)
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddRangeAsync(List<T> entities, CancellationToken token = default);
        /// <summary>
        /// Gönderilen Listeyi bulk halinde asenkron olarak veri tabanından siler
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(List<T> entities, CancellationToken token = default);
        /// <summary>
        /// Gönderilen Listeyi bulk halinde asenkron olarak veri tabanından siler
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(Expression<Func<T, bool>> filter = null, CancellationToken token = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken token = default);
        Task<double> SumAsync(Expression<Func<T, double>> filter = null, CancellationToken token = default);
        Task<double> MaxAsync(Expression<Func<T, double>> filter = null, CancellationToken token = default);
        Task<double> MinAsync(Expression<Func<T, double>> filter = null, CancellationToken token = default);
        Task<double> AverageAsync(Expression<Func<T, double>> filter = null, CancellationToken token = default);

        #endregion

        #region UnitofWork
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken token = default);
        #endregion
    }
}

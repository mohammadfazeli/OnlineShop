using OnlineShop.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Common.Enum;

namespace OnlineShop.DataLayer.Repository
{
    public interface IRepository<TEntity>
    {

        Task<CreateStatus> CreateAsync(TEntity entity, bool saveNow = true);
        Task<UpdateStatus> UpdateAsync(TEntity entity, bool saveNow = true);
        Task<DeleteStatus> DeleteAsync(TEntity entity, bool saveNow = true);
        Task<TEntity> GetAsync(int code);
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> GetNoTrackingAsync(Guid id);
        Task<TEntity> GetNoTrackingAsync(int code);

        CreateStatus Create(TEntity entity, bool saveNow = true);
        UpdateStatus Update(TEntity entity, bool saveNow = true);
        DeleteStatus Delete(TEntity entity, bool saveNow = true);
        TEntity Get(int code);
        TEntity Get(Guid id);
        TEntity GetNoTracking(Guid id);
        TEntity GetNoTracking(int code);
        IQueryable<TEntity> GetAll();



    }
}

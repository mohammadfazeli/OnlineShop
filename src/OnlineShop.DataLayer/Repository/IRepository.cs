using OnlineShop.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.DataLayer.Repository
{
    public interface IRepository<TEntity>
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();

        Task<CreateStatusvm> CreateAsync(TEntity entity, bool saveNow = true);

        Task<UpdateStatusvm> UpdateAsync(TEntity entity, bool saveNow = true);

        Task<DeleteStatusvm> RemoveAsync(TEntity entity, bool saveNow = true);

        //Task<TEntity> GetAsync(int code);
        Task<TEntity> GetAsync(Guid id);

        Task<TEntity> GetNoTrackingAsync(Guid id);

        //Task<TEntity> GetNoTrackingAsync(int code);

        Task<CreateStatusvm> CreateRangeAsync(List<TEntity> entity, bool saveNow = true);

        CreateStatusvm Create(TEntity entity, bool saveNow = true);

        UpdateStatusvm Update(TEntity entity, bool saveNow = true);

        DeleteStatusvm Remove(TEntity entity, bool saveNow = true);

        //TEntity Get(int code);
        TEntity Get(Guid id);

        TEntity GetNoTracking(Guid id);

        //TEntity GetNoTracking(int code);
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAllNoTracking();
    }
}
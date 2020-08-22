using Microsoft.EntityFrameworkCore;
using OnlineShop.DataLayer.Context;
using OnlineShop.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Common.Enum;
using OnlineShop.Common.ViewModel;

namespace OnlineShop.DataLayer.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork _uow;
        protected readonly DbSet<TEntity> _entity;

        public Repository(IUnitOfWork uow)
        {
            _uow = uow;
            _entity = uow.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entity.Where(row => !row.IsDeleted);
        }

        public IQueryable<TEntity> GetAllNoTracking()
        {
            return _entity.AsNoTracking().Where(row => !row.IsDeleted);
        }

        public virtual async Task<CreateStatusvm> CreateAsync(TEntity entity, bool saveNow = true)
        {
            await _entity.AddAsync(entity);
            if (saveNow)
                await _uow.SaveChangesAsync(true);
            return new CreateStatusvm() { CreateStatus = CreateStatus.Successfully, Valid = true, RetrunId = entity.Id };
        }

        public virtual async Task<UpdateStatusvm> UpdateAsync(TEntity entity, bool saveNow = true)
        {
            _entity.Update(entity);
            if (saveNow)
                await _uow.SaveChangesAsync(true);
            return new UpdateStatusvm() { UpdateStatus = UpdateStatus.Successfully, Valid = true, RetrunId = entity.Id };
        }

        public virtual async Task<DeleteStatusvm> DeleteAsync(TEntity entity, bool saveNow = true)
        {
            _entity.Remove(entity: entity);
            if (saveNow)
                await _uow.SaveChangesAsync(true);
            return new DeleteStatusvm() { DeleteStatus = DeleteStatus.Successfully, Valid = true, RetrunId = entity.Id };
        }

        //public virtual async Task<TEntity> GetAsync(int code)
        //{
        //    return await _entity.FirstOrDefaultAsync(s => s.Code == code && !s.IsDeleted && !s.InActive);
        //}
        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            return await _entity.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public virtual async Task<TEntity> GetNoTrackingAsync(Guid id)
        {
            return await _entity.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        //public virtual async Task<TEntity> GetNoTrackingAsync(int code)
        //{
        //    return await _entity.AsNoTracking().FirstOrDefaultAsync(s => s.Code == code && !s.InActive && !s.IsDeleted);
        //}

        public virtual CreateStatusvm Create(TEntity entity, bool saveNow = true)
        {
            _entity.Add(entity);
            if (saveNow)
                _uow.SaveChanges(true);
            return new CreateStatusvm() { CreateStatus = CreateStatus.Successfully, Valid = true, RetrunId = entity.Id };
        }

        public virtual UpdateStatusvm Update(TEntity entity, bool saveNow = true)
        {
            _entity.Update(entity);
            if (saveNow)
                _uow.SaveChanges(true);
            return new UpdateStatusvm() { UpdateStatus = UpdateStatus.Successfully, Valid = true, RetrunId = entity.Id };
        }

        public virtual DeleteStatusvm Delete(TEntity entity, bool saveNow = true)
        {
            //var objectEntity = Get(entity.Id);
            //if (objectEntity is null) return new DeleteStatusvm() { DeleteStatus = DeleteStatus.NotExists, Valid = false, RetrunId = entity.Id };
            _entity.Remove(entity: entity);
            if (saveNow)
                _uow.SaveChanges(true);
            return new DeleteStatusvm() { DeleteStatus = DeleteStatus.Successfully, Valid = true, RetrunId = entity.Id };
        }

        public virtual TEntity Get(Guid id)
        {
            return _entity.FirstOrDefault(s => s.Id == id && !s.IsDeleted);
        }

        //public virtual TEntity Get(int code)
        //{
        //    return _entity.FirstOrDefault(s => s.Code == code && !s.IsDeleted && !s.InActive);
        //}
        public virtual TEntity GetNoTracking(Guid id)
        {
            return _entity.AsNoTracking().FirstOrDefault(s => s.Id == id && !s.IsDeleted);
        }

        //public virtual TEntity GetNoTracking(int code)
        //{
        //    return _entity.AsNoTracking().FirstOrDefault(s => s.Code == code && !s.InActive && !s.InActive);
        //}

        public int SaveChanges()
        {
            return _uow.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _uow.SaveChangesAsync(true);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using OnlineShop.DataLayer.Context;
using OnlineShop.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Common.Enum;

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
            return _entity.Where(row => !row.IsDeleted).OrderByDescending(x => x.CreateOn);
        }

        public virtual async Task<CreateStatus> CreateAsync(TEntity entity, bool saveNow = true)
        {
            await _entity.AddAsync(entity);
            if (saveNow)
                await _uow.SaveChangesAsync(true);
            return CreateStatus.Successfully;
        }

        public virtual async Task<UpdateStatus> UpdateAsync(TEntity entity, bool saveNow = true)
        {
            _entity.Update(entity);
            if (saveNow)
                await _uow.SaveChangesAsync(true);
            return UpdateStatus.Successfully;
        }

        public virtual async Task<DeleteStatus> DeleteAsync(TEntity entity, bool saveNow = true)
        {
            _entity.Remove(entity: entity);
            if (saveNow)
                await _uow.SaveChangesAsync(true);
            return DeleteStatus.Successfully;
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

        public virtual CreateStatus Create(TEntity entity, bool saveNow = true)
        {
            _entity.Add(entity);
            if (saveNow)
                _uow.SaveChanges(true);
            return CreateStatus.Successfully;
        }

        public virtual UpdateStatus Update(TEntity entity, bool saveNow = true)
        {
            _entity.Update(entity);
            if (saveNow)
                _uow.SaveChanges(true);
            return UpdateStatus.Successfully;
        }

        public virtual DeleteStatus Delete(TEntity entity, bool saveNow = true)
        {
            var objectEntity = Get(entity.Id);
            if (objectEntity is null) return DeleteStatus.NotExists;
            _entity.Remove(entity: objectEntity);
            if (saveNow)
                _uow.SaveChanges(true);
            return DeleteStatus.Successfully;
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
    }
}
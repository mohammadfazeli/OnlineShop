using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities;
using OnlineShop.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Contracts
{
    public interface IEntityService<TEntity, TDto>
    {
        IQueryable<TEntity> GetAll();

        TEntity Get(Guid id);
        Task<TEntity> GetAsync(Guid id);

        bool Add(TDto dto);
        Task<bool> AddAsync(TDto dto);

        bool Update(TDto dto);
        Task<bool> UpdateAsync(TDto dto);

        bool Delete(Guid id);
        Task<bool> DeleteAsync(Guid id);
    }

    public class EntityService<TEntity, TDto> : IEntityService<TEntity, TDto>
         where TEntity : BaseEntity
         where TDto : BaseDto

    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IRepository<TEntity> _repository;

        public EntityService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity Get(Guid id)
        {
            return _repository.Get(id);
        }

        public virtual Task<TEntity> GetAsync(Guid id)
        {
            return _repository.GetAsync(id);

        }


        public virtual bool Add(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _repository.Create(entity);
            return true;
        }

        public virtual async Task<bool> AddAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.CreateAsync(entity);
            return true;
        }

        public virtual bool Update(TDto dto)
        {
            var objectEntity = _repository.GetNoTracking(dto.Id);/*  Get(dto.Id);*/
            if (objectEntity is null) return false;

            _unitOfWork.Entry(objectEntity).State = EntityState.Modified;
            objectEntity = _mapper.Map<TDto, TEntity>(dto, objectEntity);
            _unitOfWork.SaveChanges();
            return true;
        }

        public virtual async Task<bool> UpdateAsync(TDto dto)
        {
            var objectEntity = await GetAsync(dto.Id);
            if (objectEntity is null) return false;
            _mapper.Map(dto, objectEntity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public virtual bool Delete(Guid id)
        {
            var entity = _repository.Get(id);
            if (entity == null) return false;
            _repository.Delete(entity);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = _repository.Get(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

    }
}
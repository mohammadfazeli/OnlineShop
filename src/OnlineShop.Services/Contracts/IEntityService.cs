using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities;
using OnlineShop.ViewModels;

namespace OnlineShop.Services.Contracts
{
    public interface IEntityService<TEntity, TDto>
    {
        IQueryable<TEntity> GetAll();

        TEntity Get(Guid id);
        Task<TEntity> GetAsync(Guid id);

        TEntity Get(int code);
        Task<TEntity> GetAsync(int code);

        bool Add(TDto dto);
        Task<bool> AddAsync(TDto dto);

        bool Update(TDto dto);
        Task<bool> UpdateAsync(TDto dto);

        bool Delete(TDto dto);
        Task<bool> DeleteAsync(TDto dto);
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
            return _repository.GetAll().OrderByDescending(row => row.Code);
        }

        public virtual TEntity Get(Guid id)
        {
            return _repository.Get(id);
        }

        public virtual Task<TEntity> GetAsync(Guid id)
        {
            return _repository.GetAsync(id);

        }

        public virtual TEntity Get(int code)
        {
            return _repository.Get(code);
        }

        public virtual Task<TEntity> GetAsync(int code)
        {
            return _repository.GetAsync(code);

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
            var objectEntity = Get(dto.Id);
            if (objectEntity is null) return false;
            objectEntity = _mapper.Map<TDto, TEntity>(dto);
            //_mapper.Map(dto, objectEntity);

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

        public virtual bool Delete(TDto dto)
        {
            var entity = _repository.Get(dto.Id);
            if (entity == null) return false;
            _repository.Delete(entity);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(TDto dto)
        {
            var entity = _repository.Get(dto.Id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

    }
}
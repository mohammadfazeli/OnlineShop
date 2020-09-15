using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Utilities;
using OnlineShop.Common.ViewModel;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities;
using OnlineShop.Services.Contracts;
using OnlineShop.ViewModels;
using OnlineShop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services
{
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

        #region Get

        public virtual TEntity Get(Guid id) => _repository.Get(id);

        public virtual async Task<TEntity> GetAsync(Guid id) => await _repository.GetAsync(id);

        public virtual TEntity GetNoTracking(Guid id) => _repository.GetNoTracking(id);

        public virtual async Task<TEntity> GetNoTrackingAsync(Guid id) => await _repository.GetNoTrackingAsync(id);

        public virtual IQueryable<TEntity> GetAll() => _repository.GetAll();

        public virtual IQueryable<TEntity> GetAllNoTracking() => _repository.GetAllNoTracking();

        public virtual SelectList GetSelectList(Guid? id = null, string dataValueField = "Id", string dataTextField = "Name")
        {
            return new SelectList(GetAllNoTracking().Where(x => !x.InActive), dataValueField, dataTextField, selectedValue: id.GuidIsValid() ? id.ToString() : null);
        }

        public virtual DropDownViewModel GetDropDown(Guid? id = null, string dataValueField = "Id", string dataTextField = "Name")
        {
            var dd = new DropDownViewModel()
            {
                id = id,
                SelectList = GetSelectList(id, dataValueField, dataTextField),
                CurrentValues = id == null ? null : new List<string>() { id.ToString() },
            };
            return dd;
        }

        #endregion Get

        #region CUD

        public virtual CreateStatusvm Add(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            return _repository.Create(entity);
        }

        public virtual async Task<CreateStatusvm> AddAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            return await _repository.CreateAsync(entity);
        }

        public virtual UpdateStatusvm Update(TDto dto)
        {
            var objectEntity = _repository.GetNoTracking(dto.Id);/*  Get(dto.Id);*/
            if (objectEntity is null) return new UpdateStatusvm() { Valid = false, UpdateStatus = UpdateStatus.NotExists };

            _unitOfWork.Entry(objectEntity).State = EntityState.Modified;
            objectEntity = _mapper.Map<TDto, TEntity>(dto, objectEntity);
            _unitOfWork.SaveChanges();
            return new UpdateStatusvm() { RetrunId = dto.Id, Valid = true, UpdateStatus = UpdateStatus.Successfully };
        }

        public virtual async Task<UpdateStatusvm> UpdateAsync(TDto dto)
        {
            var objectEntity = await GetAsync(dto.Id);
            if (objectEntity is null) return new UpdateStatusvm() { Valid = false, UpdateStatus = UpdateStatus.NotExists };
            _mapper.Map(dto, objectEntity);
            await _unitOfWork.SaveChangesAsync();
            return new UpdateStatusvm() { RetrunId = dto.Id, Valid = true, UpdateStatus = UpdateStatus.Successfully };
        }

        public virtual DeleteStatusvm Delete(Guid id)
        {
            var entity = _repository.Get(id);
            if (entity == null) return new DeleteStatusvm() { DeleteStatus = DeleteStatus.NotExists, Valid = false, RetrunId = entity.Id };
            return _repository.Delete(entity);
        }

        public virtual async Task<DeleteStatusvm> DeleteAsync(Guid id)
        {
            var entity = _repository.Get(id);
            if (entity == null) return new DeleteStatusvm() { DeleteStatus = DeleteStatus.NotExists, Valid = false, RetrunId = entity.Id };
            return await _repository.DeleteAsync(entity);
        }

        #endregion CUD
    }
}
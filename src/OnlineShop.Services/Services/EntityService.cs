﻿using AutoMapper;
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
using System;
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

        public virtual IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IQueryable<TEntity> GetAllNoTracking()
        {
            return _repository.GetAllNoTracking();
        }

        public virtual TEntity Get(Guid id)
        {
            return _repository.Get(id);
        }

        public virtual Task<TEntity> GetAsync(Guid id)
        {
            return _repository.GetAsync(id);
        }

        public virtual SelectList GetSelectList(Guid? id = null, string dataValueField = "Id", string dataTextField = "Name")
        {
            return new SelectList(GetAllNoTracking().Where(x => !x.InActive), dataValueField, dataTextField, selectedValue: id.GuidIsValid() ? id.ToString() : null);
        }

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
    }
}
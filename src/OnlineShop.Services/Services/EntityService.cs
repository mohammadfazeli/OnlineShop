using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Common.Enums;
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
    public class EntityService<TEntity, TDto>:IEntityService<TEntity,TDto>
          where TEntity : BaseEntity
          where TDto : BaseDto

    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IRepository<TEntity> _repository;

        public EntityService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
        }

        #region Get

        public virtual TEntity Get(Guid id)
        {
            return _repository.Get(id);
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public virtual TEntity GetNoTracking(Guid id)
        {
            return _repository.GetNoTracking(id);
        }

        public virtual async Task<TEntity> GetNoTrackingAsync(Guid id)
        {
            return await _repository.GetNoTrackingAsync(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IQueryable<TEntity> GetAllNoTracking()
        {
            return _repository.GetAllNoTracking();
        }

        public virtual SelectList GetSelectList(Guid? id = null,string dataValueField = "Id",string dataTextField = "Name")
        {
            return new SelectList(GetAllNoTracking().Where(x => !x.InActive),dataValueField,dataTextField,selectedValue: id.GuidIsValid() ? id.ToString() : null);
        }

        public virtual DropDownViewModel GetDropDown(Guid? id = null,string dataValueField = "Id",string dataTextField = "Name")
        {
            var dd = new DropDownViewModel()
            {
                id = id,
                SelectList = GetSelectList(id,dataValueField,dataTextField),
                CurrentValues = id == null ? null : new List<string>() { id.ToString() },
            };
            return dd;
        }

        public virtual CheckBoxListViewModel GetCheckBoxList(string CheckBoxName,string name)
        {
            var ck = new CheckBoxListViewModel()
            {
                Name = name,
                CheckBoxName = CheckBoxName,
                Items = GetSelectList(),
            };
            return ck;
        }

        #endregion Get

        #region CUD

        public virtual CreateStatusvm Add(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var result = _repository.Create(entity);
            return result;
        }

        public virtual async Task<CreateStatusvm> AddAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var result = await _repository.CreateAsync(entity);
            return result;
        }

        public virtual UpdateStatusvm Update(TDto dto)
        {
            var objectEntity = _repository.GetNoTracking(dto.Id);/*  Get(dto.Id);*/
            if(objectEntity is null) return new UpdateStatusvm() { Valid = false,UpdateStatus = UpdateStatus.NotExists,Message = Resource.Resource.UpdateNotExists };

            _unitOfWork.Entry(objectEntity).State = EntityState.Modified;
            objectEntity = _mapper.Map<TDto,TEntity>(dto,objectEntity);
            _unitOfWork.SaveChanges();
            return new UpdateStatusvm() { RetrunId = dto.Id,Valid = true,UpdateStatus = UpdateStatus.Successfully,Message = Resource.Resource.UpdateSuccess };
        }

        public virtual async Task<UpdateStatusvm> UpdateAsync(TDto dto)
        {
            var objectEntity = await GetAsync(dto.Id);
            if(objectEntity is null) return new UpdateStatusvm() { Valid = false,UpdateStatus = UpdateStatus.NotExists,Message = Resource.Resource.UpdateNotExists };
            _mapper.Map(dto,objectEntity);
            await _unitOfWork.SaveChangesAsync();
            return new UpdateStatusvm() { RetrunId = dto.Id,Valid = true,UpdateStatus = UpdateStatus.Successfully,Message = Resource.Resource.UpdateSuccess };
        }

        public virtual DeleteStatusvm Remove(Guid id)
        {
            var entity = _repository.Get(id);
            if(entity == null) return new DeleteStatusvm() { DeleteStatus = DeleteStatus.NotExists,Message = Resource.Resource.DeleteNotExists,Valid = false,RetrunId = entity.Id };
            var result = _repository.Remove(entity);
            return result;
        }

        public virtual async Task<DeleteStatusvm> RemoveAsync(Guid id)
        {
            var entity = _repository.Get(id);
            if(entity == null) return new DeleteStatusvm() { DeleteStatus = DeleteStatus.NotExists,Message = Resource.Resource.DeleteNotExists,Valid = false,RetrunId = entity.Id };
            var result = await _repository.RemoveAsync(entity);
            return result;
        }

        public virtual DeleteStatusvm Delete(Guid id)
        {
            var entity = _repository.Get(id);
            if(entity == null) return new DeleteStatusvm() { DeleteStatus = DeleteStatus.NotExists,Message = Resource.Resource.DeleteNotExists,Valid = false,RetrunId = entity.Id };
            _unitOfWork.Entry(entity).State = EntityState.Modified;
            entity.IsDeleted = true;
            _unitOfWork.SaveChanges();
            return new DeleteStatusvm() { DeleteStatus = DeleteStatus.Successfully,Message = Resource.Resource.DeleteSuccessfully,Valid = true,RetrunId = entity.Id };
        }

        public virtual async Task<DeleteStatusvm> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);

            if(entity == null) return new DeleteStatusvm() { DeleteStatus = DeleteStatus.NotExists,Message = Resource.Resource.DeleteNotExists,Valid = false,RetrunId = entity.Id };
            _unitOfWork.Entry(entity).State = EntityState.Modified;
            entity.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return new DeleteStatusvm() { DeleteStatus = DeleteStatus.Successfully,Message = Resource.Resource.DeleteSuccessfully,Valid = true,RetrunId = entity.Id };
        }

        #endregion CUD
    }
}
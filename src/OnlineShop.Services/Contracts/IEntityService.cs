using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Common.ViewModel;
using OnlineShop.ViewModels.Base;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineShop.Services.Contracts
{
    public interface IEntityService<TEntity, TDto>
    {
        TEntity Get(Guid id);

        Task<TEntity> GetAsync(Guid id);

        TEntity GetNoTracking(Guid id);

        Task<TEntity> GetNoTrackingAsync(Guid id);

        IQueryable<TEntity> GetAll();

        IQueryable<TListDto> GetListDto<TListDto>(Expression<Func<TEntity,bool>> predicate = null);

        IQueryable<TListDto> CastToListDto<TListDto>(IQueryable<TEntity> items);

        IQueryable<TEntity> GetAllNoTracking();

        IQueryable<TEntity> GetAllNoTracking(Expression<Func<TEntity,bool>> predicate = null);

        SelectList GetSelectList(Guid? id = null,string dataValueField = "Id",string dataTextField = "Name",Expression<Func<TEntity,bool>> predicate = null);

        DropDownViewModel GetDropDown(Guid? id = null,string dataValueField = "Id",string dataTextField = "Name",Expression<Func<TEntity,bool>> predicate = null);

        CheckBoxListViewModel GetCheckBoxList(string CheckBoxName,string name);

        CreateStatusvm Add(TDto dto);

        Task<CreateStatusvm> AddAsync(TDto dto);

        UpdateStatusvm Update(TDto dto);

        Task<UpdateStatusvm> UpdateAsync(TDto dto);

        DeleteStatusvm Delete(Guid id);

        Task<DeleteStatusvm> DeleteAsync(Guid id);
    }
}
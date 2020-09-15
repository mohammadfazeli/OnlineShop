using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Common.ViewModel;
using OnlineShop.ViewModels.Base;
using System;
using System.Linq;
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

        IQueryable<TEntity> GetAllNoTracking();

        SelectList GetSelectList(Guid? id = null, string dataValueField = "Id", string dataTextField = "Name");

        DropDownViewModel GetDropDown(Guid? id = null, string dataValueField = "Id", string dataTextField = "Name");

        CreateStatusvm Add(TDto dto);

        Task<CreateStatusvm> AddAsync(TDto dto);

        UpdateStatusvm Update(TDto dto);

        Task<UpdateStatusvm> UpdateAsync(TDto dto);

        DeleteStatusvm Delete(Guid id);

        Task<DeleteStatusvm> DeleteAsync(Guid id);
    }
}
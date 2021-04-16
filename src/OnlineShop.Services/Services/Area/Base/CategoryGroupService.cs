using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.categories;
using OnlineShop.ViewModels.Area.Base.categories.CategoryGroup;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
    public class CategoryGroupService:EntityService<CategoryGroup,CategoryGroupDto>, ICategoryGroupService
    {
        protected readonly DbSet<Category> _repositoryCategory;
        protected readonly DbSet<CategoryGroup> _repositoryCategoryGroup;

        public CategoryGroupService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<CategoryGroup> repository
            ) : base(unitOfWork,mapper,repository)
        {
            _repositoryCategory = unitOfWork.Set<Category>();
            _repositoryCategoryGroup = unitOfWork.Set<CategoryGroup>();
        }

        public List<CategoryGeneralDto> GetCategoryGeneral()
        {
            var x = _repositoryCategoryGroup.Where(x => !x.IsDeleted && !x.InActive);
            var CategoryGeneralDto = _repositoryCategoryGroup.AsEnumerable().Where(x => !x.IsDeleted && !x.InActive)
                .Select(s => new CategoryGeneralDto()
                {
                    id = s.Id,
                    Name = s.Name,
                    SubCategories = s.Categories.Count > 0 ? GetCategoryDetail(s.Id).ToList() : new List<CategoryDetailDto>()
                }).ToList();

            return CategoryGeneralDto;
        }

        private List<CategoryDetailDto> GetCategoryDetail(Guid categoryGroupId)
        {
            return _repositoryCategory.AsEnumerable().Where(x => !x.IsDeleted && !x.InActive &&
                  x.CategoryGroupId == categoryGroupId && x.ParentCategoryId == null)
                   .Select(s => new CategoryDetailDto()
                   {
                       id = s.Id,
                       Name = s.Name,
                       SubCategories = s.SubCategories.Count > 0 ? GetSubCategoryDetail(s.Id).ToList() : new List<CategoryDetailDto>()
                   }).ToList();
        }

        private List<CategoryDetailDto> GetSubCategoryDetail(Guid parentCategoryId)
        {
            return _repositoryCategory.AsEnumerable().Where(x => !x.IsDeleted && !x.InActive && x.ParentCategoryId == parentCategoryId)

                   .Select(s => new CategoryDetailDto()
                   {
                       id = s.Id,
                       Name = s.Name,
                       SubCategories = s.SubCategories.Count > 0 ? GetSubCategoryDetail(s.Id) : new List<CategoryDetailDto>()
                   }).ToList();
        }
    }
}
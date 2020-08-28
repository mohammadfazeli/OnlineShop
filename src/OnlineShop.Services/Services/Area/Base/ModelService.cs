using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Colors;
using OnlineShop.ViewModels.Area.Base.Models;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ModelService : EntityService<Model, ModelDto>, IModelService
    {
        public ModelService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Model> repository) : base(unitOfWork, mapper, repository)
        {
        }
    }
}
using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Colors;

namespace OnlineShop.Services.Services
{
    public class ColorService : EntityService<Color, ColorstDto>, IColorService
    {
        public ColorService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Color> repository) : base(unitOfWork, mapper, repository)
        {
        }
    }
}
﻿using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Entities.Entities.Area.Base.Colors;
using OnlineShop.Services.Contracts;
using OnlineShop.Services.Contracts.Area.Base;

namespace OnlineShop.Services.Services
{
    public class ColorService : EntityService<Color, ColorDto>, IColorService
    {
        public ColorService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Color> repository) : base(unitOfWork, mapper, repository)
        {
        }
    }
}
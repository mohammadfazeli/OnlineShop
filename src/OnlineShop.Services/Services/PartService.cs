using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts;
using OnlineShop.ViewModels.Area.Base;

namespace OnlineShop.Services.Services
{
    public class PartService : EntityService<Part, PartDto>, IPartService
    {
        public PartService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Part> repository) : base(unitOfWork, mapper, repository)
        {
        }


        //public override bool Update(PartDto dto)
        //{
        //    var part = _repository.Get(dto.Id);
        //    part.Name = dto.Name;
        //    part.Title = dto.Title;
        //    _unitOfWork.SaveChanges(true);
        //    return true;
        //}
    }
}

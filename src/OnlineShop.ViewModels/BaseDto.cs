using System;

namespace OnlineShop.ViewModels
{
    public class BaseDto
    {
        public BaseDto()
        {

            Id = Guid.NewGuid();
            //CreateOn = DateTime.Now;
        }


        public Guid Id { get; set; }
        public bool InActive { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedByBrowserName { get; set; }
        public string ModifiedByBrowserName { get; set; }
        public string CreatedByIp { get; set; }
        public string ModifiedByIp { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? ModifiedByUserId { get; set; }
        public string Description { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }



        //public DateTime CreateOn { get; set; }


        //public TEntity ToEntity()
        //{
        //    return _mapper.Map<TEntity>(CastToDerivedClass(this));
        //}

        //public TEntity ToEntity(TEntity entity)
        //{
        //    return _mapper.Map(CastToDerivedClass(this), entity);
        //}

        //public TDto FromEntity(TEntity model)
        //{
        //    //return Mapper.Map<TDto>(model);
        //    return _mapper.Map<TDto>(model);
        //}

        //protected TDto CastToDerivedClass(BaseDto<TDto, TEntity> baseInstance)
        //{
        //    return _mapper.Map<TDto>(baseInstance);
        //}

        //public void CreateMappings(Profile profile)
        //{
        //    var mappingExpression = profile.CreateMap<TDto, TEntity>();

        //    var dtoType = typeof(TDto);
        //    var entityType = typeof(TEntity);
        //    //Ignore any property of source (like Post.Author) that dose not contains in destination 
        //    foreach (var property in entityType.GetProperties())
        //    {
        //        if (dtoType.GetProperty(property.Name) == null)
        //            mappingExpression.ForMember(property.Name, opt => opt.Ignore());
        //    }

        //    CustomMappings(mappingExpression.ReverseMap());
        //}

        //public virtual void CustomMappings(IMappingExpression<TEntity, TDto> mapping)
        //{
        //}

    }
}

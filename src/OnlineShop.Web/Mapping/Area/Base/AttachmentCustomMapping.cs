using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.Attachments;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class AttachmentCustomMapping : IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Attachment, AttachmentDto>()
                .ReverseMap();

            profile.CreateMap<Attachment, AttachmentListDto>()
                .ForMember(dist => dist.imageUrl,
                opt => opt.MapFrom(s => $"/Images/Products/{s.Id}▲{s.RelateId}{s.ExtentionFile}"))
               .ReverseMap();
        }
    }
}
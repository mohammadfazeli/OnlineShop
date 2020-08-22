using Microsoft.AspNetCore.Http;
using OnlineShop.Common.ViewModel;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.Attachments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IAttachmentService : IEntityService<Attachment, AttachmentDto>
    {
        List<Attachment> GetByRelatedId(Guid relatedId);

        List<string> GetPhotoUrl(Guid relatedId);

        Task<CreateStatusvm> AddList(Guid relatedId, List<IFormFile> files);
    }
}
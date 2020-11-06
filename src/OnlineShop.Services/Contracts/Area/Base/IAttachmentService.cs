using Microsoft.AspNetCore.Http;
using OnlineShop.Common.ViewModel;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IAttachmentService : IEntityService<Attachment, AttachmentDto>
    {
        List<Attachment> GetByRelatedId(Guid relatedId);

        List<string> GetPhotoUrl(Guid relatedId);

        IQueryable<AttachmentListDto> GetList(Guid RelatedId);

        Task<CreateStatusvm> AddList(Guid relatedId, IFormFileCollection files);

        Task<DeleteStatusvm> RemoveAll(Guid relatedId);

        Task<DeleteStatusvm> RemoveImage(Guid id, Guid relateId);
    }
}
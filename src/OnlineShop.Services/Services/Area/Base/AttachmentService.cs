using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using OnlineShop.Common.Enum;
using OnlineShop.Common.ViewModel;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Attachments;
using OnlineShop.ViewModels.Identity.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services.Area.Base
{
    public class AttachmentService : EntityService<Attachment, AttachmentDto>, IAttachmentService
    {
        private readonly IOptionsSnapshot<SiteSettings> _siteSettings;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AttachmentService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Attachment> repository,
             IHttpContextAccessor contextAccessor,
            IWebHostEnvironment hostingEnvironment,
            IOptionsSnapshot<SiteSettings> siteSettings
            ) : base(unitOfWork, mapper, repository)
        {
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(_contextAccessor));
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(_hostingEnvironment));
            _siteSettings = siteSettings ?? throw new ArgumentNullException(nameof(_siteSettings));
        }

        public async Task<CreateStatusvm> AddList(Guid relatedId, IFormFileCollection files)
        {
            foreach (var file in files)
            {
                await AddAsync(new AttachmentDto()
                {
                    File = file,
                    RelateId = relatedId,
                    Type = AttachmentType.Image,
                    Name = file.FileName,
                    ExtentionFile = Path.GetExtension(file.FileName)
                });
            }
            return new CreateStatusvm() { Valid = true, CreateStatus = CreateStatus.Successfully };
        }

        public override async Task<CreateStatusvm> AddAsync(AttachmentDto dto)
        {
            var photoFile = dto.File;
            if (photoFile?.Length > 0)
            {
                var entity = _mapper.Map<Attachment>(dto);
                if ((await _repository.CreateAsync(entity, false)).CreateStatus != CreateStatus.Successfully)
                    new CreateStatusvm() { Valid = false, CreateStatus = CreateStatus.Fail };

                var imageOptions = _siteSettings.Value.UserAvatarImageOptions;
                //if (!photoFile.IsValidImageFile(maxWidth: imageOptions.MaxWidth, maxHeight: imageOptions.MaxHeight))
                //{
                //    this.ModelState.AddModelError("",
                //        $"حداکثر اندازه تصویر قابل ارسال {imageOptions.MaxHeight} در {imageOptions.MaxWidth} پیکسل است");
                //    model.PhotoFileName = user.PhotoFileName;
                //    return false;
                //}

                var uploadsRootFolder = GetImageFolderPath();
                var photoFileName = $"{entity.Id}▲{dto.RelateId}{Path.GetExtension(photoFile.FileName)}";
                var filePath = Path.Combine(uploadsRootFolder, photoFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photoFile.CopyToAsync(fileStream);
                }
                await _repository.SaveChangesAsync();
                return new CreateStatusvm() { Valid = true, CreateStatus = CreateStatus.Successfully };
            }
            return new CreateStatusvm() { Valid = false, CreateStatus = CreateStatus.Fail };
        }

        public List<Attachment> GetByRelatedId(Guid relatedId)
        {
            return GetAllNoTracking().Where(row => row.RelateId == relatedId).ToList();
        }

        public string GetImageFolderPath()
        {
            var ProductImagesFolder = _siteSettings.Value.ProductImagesFolder;
            var uploadsRootFolder = Path.Combine(_hostingEnvironment.WebRootPath, ProductImagesFolder);
            if (!Directory.Exists(uploadsRootFolder))
            {
                Directory.CreateDirectory(uploadsRootFolder);
            }
            return uploadsRootFolder;
        }

        public List<string> GetPhotoUrl(Guid relatedId)
        {
            var files = GetByRelatedId(relatedId);
            List<string> items = new List<string>();
            if (files == null) return items;

            foreach (var file in files)
            {
                switch (file.Type)
                {
                    case AttachmentType.Image:

                        items.Add($"/{_siteSettings.Value.ProductImagesFolder}/{file.Id}▲{relatedId}{file.ExtentionFile}");
                        break;

                    case AttachmentType.File:
                        break;
                }
            }
            return items;
        }

        public async Task<DeleteStatusvm> RemoveAll(Guid relatedId)
        {
            var files = GetByRelatedId(relatedId);
            if (files == null) return new DeleteStatusvm() { Valid = true, DeleteStatus = DeleteStatus.NotExists };

            var ProductImagesFolder = _siteSettings.Value.ProductImagesFolder;
            var uploadsRootFolder = Path.Combine(_hostingEnvironment.WebRootPath, ProductImagesFolder);

            foreach (var file in files)
            {
                var fileName = $"{file.Id}▲{file.RelateId}{file.ExtentionFile}";
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    await this.DeleteAsync(file.Id);
                }
            }
            return new DeleteStatusvm() { DeleteStatus = DeleteStatus.Successfully, Valid = true };
        }
    }
}
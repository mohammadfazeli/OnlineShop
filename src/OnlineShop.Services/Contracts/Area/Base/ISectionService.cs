using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.Section;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface ISectionService:IEntityService<Section,SectionDto>
    {
        Task<List<SectionDetailListDro>> GetSections();
    }
}
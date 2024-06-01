using RentACarProject.Colors.Dtos;
using RentACarProject.Entities.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RentACarProject.Colors
{
    public class ColorAppService : CrudAppService<Color, ColorDto, int, PagedAndSortedResultRequestDto, CreatedColorDto, UpdatedColorDto>, IColorAppService
    {
        public ColorAppService(IRepository<Color, int> repository) : base(repository)
        {
        }

        public override Task<ColorDto> CreateAsync(CreatedColorDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task<ColorDto> UpdateAsync(int id, UpdatedColorDto input)
        {
            return base.UpdateAsync(id, input);
        }

        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }

        public override Task<ColorDto> GetAsync(int id)
        {
            return base.GetAsync(id);
        }

        public override Task<PagedResultDto<ColorDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }
    }
}

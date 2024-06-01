using RentACarProject.Brands.Dtos;
using RentACarProject.Entities.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RentACarProject.Brands
{
    public class BrandAppService : CrudAppService<Brand, BrandDto, int, PagedAndSortedResultRequestDto, CreatedBrandDto, UpdatedBrandDto>, IBrandAppService
    {
        public BrandAppService(IRepository<Brand, int> repository) : base(repository)
        {
        }

        public override Task<BrandDto> CreateAsync(CreatedBrandDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task<BrandDto> UpdateAsync(int id, UpdatedBrandDto input)
        {
            return base.UpdateAsync(id, input);
        }

        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }

        public override Task<BrandDto> GetAsync(int id)
        {
            return base.GetAsync(id);
        }

        public override Task<PagedResultDto<BrandDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }
    }
}

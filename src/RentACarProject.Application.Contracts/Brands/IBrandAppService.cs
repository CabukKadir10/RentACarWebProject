using RentACarProject.Brands.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace RentACarProject.Brands
{
    public interface IBrandAppService : ICrudAppService<BrandDto, int, PagedAndSortedResultRequestDto, CreatedBrandDto, UpdatedBrandDto>, ITransientDependency
    {
    }
}

using RentACarProject.Dtos.Brand;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace RentACarProject.Brands
{
    public interface IBrandAppServices : ICrudAppService<BrandDto, int, PagedAndSortedResultRequestDto, BrandCreateDto, BrandUpdateDto>, ITransientDependency
    {
    }
}

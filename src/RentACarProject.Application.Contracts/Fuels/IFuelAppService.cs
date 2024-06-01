using RentACarProject.Fuels.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace RentACarProject.Fuels
{
    public interface IFuelAppService : ICrudAppService<FuelDto, int, PagedAndSortedResultRequestDto, CreatedFuelDto, UpdatedFuelDto>, ITransientDependency
    {
    }
}

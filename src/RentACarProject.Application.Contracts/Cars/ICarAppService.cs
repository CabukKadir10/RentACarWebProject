using RentACarProject.Cars.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace RentACarProject.Cars
{
    public interface ICarAppService : ICrudAppService<CarDto, int, PagedAndSortedResultRequestDto, CreatedCarDto, UpdatedCarDto>, ITransientDependency
    {
    }
}

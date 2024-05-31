using RentACarProject.Dtos.Cars;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace RentACarProject.Cars
{
    public interface ICarAppService : ICrudAppService<CarDto, int, PagedAndSortedResultRequestDto, CarCreateDto, CarUpdateDto>, ITransientDependency
    {
    }
}

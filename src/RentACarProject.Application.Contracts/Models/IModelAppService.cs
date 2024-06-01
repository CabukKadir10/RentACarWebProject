using RentACarProject.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace RentACarProject.Models
{
    public interface IModelAppService : ICrudAppService<ModelDto, int, PagedAndSortedResultRequestDto, CreatedModelDto, UpdatedModelDto>, ITransientDependency
    {
    }
}

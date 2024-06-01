using RentACarProject.Colors.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace RentACarProject.Colors
{
    public interface IColorAppService : ICrudAppService<ColorDto, int, PagedAndSortedResultRequestDto, CreatedColorDto, UpdatedColorDto>, ITransientDependency
    {
    }
}

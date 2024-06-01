using RentACarProject.Transmissions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace RentACarProject.Transmissions
{
    public interface ITransmissionAppService : ICrudAppService<TransmissionDto, int, PagedAndSortedResultRequestDto, CreatedTransmissionDto, UpdatedTransmissionDto>, ITransientDependency
    {
    }
}

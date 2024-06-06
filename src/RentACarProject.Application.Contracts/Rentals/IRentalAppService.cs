using RentACarProject.Rentals.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace RentACarProject.Rentals
{
    public interface IRentalAppService : ICrudAppService<RentalDto, int, PagedAndSortedResultRequestDto, CreatedRentalDto, UpdatedRentalDto>, ITransientDependency
    {
    }
}

using RentACarProject.Entities.Fuels;
using RentACarProject.Fuels.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RentACarProject.Fuels
{
    public class FuelAppService : CrudAppService<Fuel, FuelDto, int, PagedAndSortedResultRequestDto, CreatedFuelDto, UpdatedFuelDto>, IFuelAppService
    {
        public FuelAppService(IRepository<Fuel, int> repository) : base(repository)
        {
        }

        public override Task<FuelDto> CreateAsync(CreatedFuelDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task<FuelDto> UpdateAsync(int id, UpdatedFuelDto input)
        {
            return base.UpdateAsync(id, input);
        }

        public override Task<FuelDto> GetAsync(int id)
        {
            return base.GetAsync(id);
        }

        public override Task<PagedResultDto<FuelDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }

        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
    }
}

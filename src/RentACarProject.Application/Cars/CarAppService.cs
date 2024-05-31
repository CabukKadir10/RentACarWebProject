using RentACarProject.Dtos.Cars;
using RentACarProject.Entities.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RentACarProject.Cars
{
    public class CarAppService : CrudAppService<Car, CarDto, int, PagedAndSortedResultRequestDto, CarCreateDto, CarUpdateDto>, ICarAppService
    {
        public CarAppService(IRepository<Car, int> repository) : base(repository)
        {
        }

        public override Task<CarDto> CreateAsync(CarCreateDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task<CarDto> UpdateAsync(int id, CarUpdateDto input)
        {
            return base.UpdateAsync(id, input);
        }

        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }

        public override Task<PagedResultDto<CarDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }

        public override Task<CarDto> GetAsync(int id)
        {
            return base.GetAsync(id);
        }
    }
}

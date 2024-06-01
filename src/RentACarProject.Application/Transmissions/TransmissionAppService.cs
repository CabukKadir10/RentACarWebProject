using RentACarProject.Entities.Transmissions;
using RentACarProject.Transmissions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RentACarProject.Transmissions
{
    public class TransmissionAppService : CrudAppService<Transmission, TransmissionDto, int, PagedAndSortedResultRequestDto, CreatedTransmissionDto, UpdatedTransmissionDto>, ITransmissionAppService
    {
        public TransmissionAppService(IRepository<Transmission, int> repository) : base(repository)
        {
        }

        public override Task<TransmissionDto> CreateAsync(CreatedTransmissionDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task<TransmissionDto> UpdateAsync(int id, UpdatedTransmissionDto input)
        {
            return base.UpdateAsync(id, input);
        }

        public override Task<TransmissionDto> GetAsync(int id)
        {
            return base.GetAsync(id);
        }

        public override Task<PagedResultDto<TransmissionDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }

        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
    }
}

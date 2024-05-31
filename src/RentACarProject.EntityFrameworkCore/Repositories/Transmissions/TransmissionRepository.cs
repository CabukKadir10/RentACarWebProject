using RentACarProject.Entities.Transmissions;
using RentACarProject.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace RentACarProject.Repositories.Transmissions
{
    public class TransmissionRepository : EfCoreRepository<RentACarProjectDbContext, Transmission, int>, ITransmissionRepository
    {
        public TransmissionRepository(IDbContextProvider<RentACarProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

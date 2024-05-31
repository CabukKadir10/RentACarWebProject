using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace RentACarProject.Entities.Transmissions
{
    public interface ITransmissionRepository : IRepository<Transmission, int>, ITransientDependency
    {
    }
}

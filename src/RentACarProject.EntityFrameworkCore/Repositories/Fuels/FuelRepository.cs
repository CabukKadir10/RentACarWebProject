using RentACarProject.Entities.Cars;
using RentACarProject.Entities.Fuels;
using RentACarProject.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace RentACarProject.Repositories.Fuels
{
    public class FuelRepository : EfCoreRepository<RentACarProjectDbContext, Fuel, int>, IFuelRepository
    {
        public FuelRepository(IDbContextProvider<RentACarProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

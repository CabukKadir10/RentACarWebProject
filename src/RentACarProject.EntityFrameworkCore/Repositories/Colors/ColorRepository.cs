using RentACarProject.Entities.Cars;
using RentACarProject.Entities.Colors;
using RentACarProject.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace RentACarProject.Repositories.Colors
{
    public class ColorRepository : EfCoreRepository<RentACarProjectDbContext, Color, int>, IColorRepository
    {
        public ColorRepository(IDbContextProvider<RentACarProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

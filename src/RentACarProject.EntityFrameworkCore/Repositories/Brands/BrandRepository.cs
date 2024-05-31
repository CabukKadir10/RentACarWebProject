using RentACarProject.Entities.Brands;
using RentACarProject.Entities.Cars;
using RentACarProject.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace RentACarProject.Repositories.Brands
{
    public class BrandRepository : EfCoreRepository<RentACarProjectDbContext, Brand, int>, IBrandRepository
    {
        public BrandRepository(IDbContextProvider<RentACarProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

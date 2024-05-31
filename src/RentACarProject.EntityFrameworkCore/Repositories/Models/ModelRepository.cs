using RentACarProject.Entities.Cars;
using RentACarProject.Entities.Models;
using RentACarProject.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace RentACarProject.Repositories.Models
{
    public class ModelRepository : EfCoreRepository<RentACarProjectDbContext, Model, int>, IModelRepository
    {
        public ModelRepository(IDbContextProvider<RentACarProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace RentACarProject.Entities.Brands
{
    public interface IBrandRepository : IRepository<Brand, int>, ITransientDependency//normalde bu kısma gerek yoktur sanki Irepository interface de var ama emin olmak için bıraktım ilerde patlama olmasın diye
    {
    }
}

using RentACarProject.Entities.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace RentACarProject.Entities.Colors
{
    public class Color : Entity<int>
    {
        public Color()
        {
            Cars = new HashSet<Car>();
        }

        public Color(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        // Properties
        public string Name { get; set; }

        // Navigation Properties
        public virtual ICollection<Car> Cars { get; set; }
    }
}

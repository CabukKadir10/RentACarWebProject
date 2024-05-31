using RentACarProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace RentACarProject.Entities.Fuels
{
    public class Fuel : Entity<int>
    {
        public Fuel()
        {
            Models = new HashSet<Model>();
        }

        public Fuel(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
        // Properties
        public string Name { get; set; }
        // Navigation Properties
        public virtual ICollection<Model> Models { get; set; }
    }
}

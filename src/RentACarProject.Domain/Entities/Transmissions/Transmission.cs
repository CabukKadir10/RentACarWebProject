using RentACarProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace RentACarProject.Entities.Transmissions
{
    public class Transmission : Entity<int>
    {
        public Transmission()
        {
            Models = new HashSet<Model>();
        }

        public Transmission(int id, string name) : this()
        {
            Name = name;
            Id = id;
        }

        // Properties
        public string Name { get; set; }
        // Navigation Properties
        public virtual ICollection<Model> Models { get; set; }
    }
}

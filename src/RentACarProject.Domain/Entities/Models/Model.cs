using RentACarProject.Entities.Brands;
using RentACarProject.Entities.Cars;
using RentACarProject.Entities.Fuels;
using RentACarProject.Entities.Transmissions;
using RentACarProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace RentACarProject.Entities.Models
{
    public class Model : Entity<int>
    {
        public Model()
        {
            Cars = new HashSet<Car>();
        }

        public Model(int id, string name, double dailyPrice, int transmissionId, int fuelId, int brandId, string imageUrl)
        {
            Id = id;
            Name = name;
            DailyPrice = dailyPrice;
            TransmissionId = transmissionId;
            FuelId = fuelId;
            BrandId = brandId;
            ImageUrl = imageUrl;
        }
        // Properties
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public int BrandId { get; set; }
        public string ImageUrl { get; set; }
        // Navigation properties
        public virtual Brand Brand { get; set; }
        public virtual Fuel Fuel { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}

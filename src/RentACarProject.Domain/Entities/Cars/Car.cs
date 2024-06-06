using RentACarProject.Entities.Colors;
using RentACarProject.Entities.Models;
using RentACarProject.Entities.RentAls;
using RentACarProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace RentACarProject.Entities.Cars
{
    public class Car : Entity<int>
    {
        public Car()
        {
            Rentals = new HashSet<Rental>();
        }

        public Car(int id, int modelId, string plate, short modelYear, int colorId, CarState carState) : this()
        {
            Id = id;
            ModelId = modelId;
            Plate = plate;
            ModelYear = modelYear;
            ColorId = colorId;
            CarState = carState;
        }

        // Properties
        public int ModelId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public int ColorId { get; set; }
        public CarState CarState { get; set; }

        // Navigation Properties
        public virtual Color Color { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}

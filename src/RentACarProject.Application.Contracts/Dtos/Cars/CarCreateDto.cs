using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarProject.Dtos.Cars
{
    public class CarCreateDto
    {
        public string Plate { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public bool State { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
    }
}

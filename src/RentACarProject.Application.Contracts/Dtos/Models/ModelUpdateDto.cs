using RentACarProject.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarProject.Dtos.Models
{
    public class ModelUpdateDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int ModelYear { get; set; }
        public Fuel Fuel { get; set; }
    }
}

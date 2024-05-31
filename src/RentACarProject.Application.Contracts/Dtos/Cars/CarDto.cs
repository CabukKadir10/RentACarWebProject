using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace RentACarProject.Dtos.Cars
{
    public class CarDto : EntityDto<int>
    {
        public string Plate { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public bool State { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
    }
}

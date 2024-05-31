using RentACarProject.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace RentACarProject.Dtos.Models
{
    public class ModelDto : EntityDto<int>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int ModelYear { get; set; }
        public Fuel Fuel { get; set; }
    }
}

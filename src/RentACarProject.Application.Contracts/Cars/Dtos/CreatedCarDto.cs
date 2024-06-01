using RentACarProject.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace RentACarProject.Cars.Dtos
{
    public class CreatedCarDto : EntityDto
    {
        public int ModelId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public int ColorId { get; set; }
        public CarState CarState { get; set; }
    }
}

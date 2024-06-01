using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace RentACarProject.Models.Dtos
{
    public class UpdatedModelDto : EntityDto
    {
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public int BrandId { get; set; }
        public string ImageUrl { get; set; }
    }
}

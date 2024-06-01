using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace RentACarProject.Fuels.Dtos
{
    public class CreatedFuelDto : EntityDto
    {
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace RentACarProject.Colors.Dtos
{
    public class CreatedColorDto : EntityDto
    {
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace RentACarProject.Dtos.Brand
{
    public class BrandDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}

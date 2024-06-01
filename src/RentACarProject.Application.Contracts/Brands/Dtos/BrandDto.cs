using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace RentACarProject.Brands.Dtos
{
    public class BrandDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}

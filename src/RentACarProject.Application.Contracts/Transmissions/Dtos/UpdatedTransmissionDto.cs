﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace RentACarProject.Transmissions.Dtos
{
    public class UpdatedTransmissionDto : EntityDto
    {
        public string Name { get; set; }
    }
}

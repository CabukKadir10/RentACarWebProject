﻿using RentACarProject.Entities.Models;
using RentACarProject.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RentACarProject.Models
{
    public class ModelAppService : CrudAppService<Model, ModelDto, int, PagedAndSortedResultRequestDto, CreatedModelDto, UpdatedModelDto>, IModelAppService
    {
        public ModelAppService(IRepository<Model, int> repository) : base(repository)
        {
        }

        public override Task<ModelDto> CreateAsync(CreatedModelDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task<ModelDto> UpdateAsync(int id, UpdatedModelDto input)
        {
            return base.UpdateAsync(id, input);
        }

        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }

        public override Task<PagedResultDto<ModelDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }

        public override Task<ModelDto> GetAsync(int id)
        {
            return base.GetAsync(id);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Cars;
using RentACarProject.Models;
using RentACarProject.Models.Dtos;
using RentACarProject.Permissions;
using System.Threading.Tasks;

namespace RentACarProject.Web.Pages.Model
{
    [Authorize(RentACarProjectPermissions.Model.Update)]
    public class UpdateModel : PageModel
    {
        private readonly ModelAppService _modelAppService;

        public UpdateModel(ModelAppService modelAppService)
        {
            _modelAppService = modelAppService;
        }

        [BindProperty]
        public UpdatedModelDto UpdatedModelDto { get; set; }

        [BindProperty]
        public int Id { get; set; }

        public async Task OnGet(int id)
        {
            UpdatedModelDto = new UpdatedModelDto();
            var modelDto = await _modelAppService.GetAsync(id);
            Id = modelDto.Id;
            UpdatedModelDto.Name = modelDto.Name;
            UpdatedModelDto.BrandId = modelDto.BrandId;
            UpdatedModelDto.FuelId = modelDto.FuelId;
            UpdatedModelDto.DailyPrice = modelDto.DailyPrice;
            UpdatedModelDto.TransmissionId = modelDto.TransmissionId;
            UpdatedModelDto.ImageUrl = modelDto.ImageUrl;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var modelResult = await _modelAppService.UpdateAsync(Id, UpdatedModelDto);

            return new JsonResult(modelResult);
        }
    }
}

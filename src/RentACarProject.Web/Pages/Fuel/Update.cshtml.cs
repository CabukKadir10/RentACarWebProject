using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Fuels;
using RentACarProject.Fuels.Dtos;
using RentACarProject.Permissions;
using System.Threading.Tasks;

namespace RentACarProject.Web.Pages.Fuel
{
    [Authorize(RentACarProjectPermissions.Fuel.Update)]
    public class UpdateModel : PageModel
    {
        private readonly FuelAppService _fuelAppService;

        public UpdateModel(FuelAppService fuelAppService)
        {
            _fuelAppService = fuelAppService;
        }

        [BindProperty]
        public UpdatedFuelDto UpdatedFuelDto { get; set; }
        [BindProperty]
        public int Id { get; set; }

        public async Task OnGet(int id)
        {
            UpdatedFuelDto = new UpdatedFuelDto();
            var fuelDto = await _fuelAppService.GetAsync(id);
            Id = fuelDto.Id;
            UpdatedFuelDto.Name = fuelDto.Name;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var fuelResult = await _fuelAppService.UpdateAsync(Id, UpdatedFuelDto);

            return new JsonResult(fuelResult);
        }
    }
}

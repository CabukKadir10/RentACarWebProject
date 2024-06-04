using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Fuels;
using RentACarProject.Fuels.Dtos;
using RentACarProject.Permissions;
using System.Threading.Tasks;

namespace RentACarProject.Web.Pages.Fuel
{
    [Authorize(RentACarProjectPermissions.Fuel.Create)]
    public class AddModel : PageModel
    {
        private readonly FuelAppService _fuelAppService;

        public AddModel(FuelAppService fuelAppService)
        {
            _fuelAppService = fuelAppService;
        }

        [BindProperty]
        public CreatedFuelDto CreatedFuelDto { get; set; }

        public void OnGet()
        {
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            var fuelResult = await _fuelAppService.CreateAsync(CreatedFuelDto);
            return new JsonResult(fuelResult);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Cars;
using RentACarProject.Cars.Dtos;
using RentACarProject.Permissions;
using System.Threading.Tasks;

namespace RentACarProject.Web.Pages.Cars
{
    [Authorize(RentACarProjectPermissions.Car.Update)]
    public class UpdateModel : PageModel
    {
        private readonly CarAppService _carAppService;

        public UpdateModel(CarAppService carAppService)
        {
            _carAppService = carAppService;
        }

        [BindProperty]
        public UpdatedCarDto UpdatedCarDto { get; set; }

        [BindProperty]
        public int Id { get; set; }

        public async Task OnGet(int id)
        {
            UpdatedCarDto = new UpdatedCarDto();
            var carDto = await _carAppService.GetAsync(id);
            Id = carDto.Id;
            UpdatedCarDto.CarState = carDto.CarState;
            UpdatedCarDto.Plate = carDto.Plate;
            UpdatedCarDto.ColorId = carDto.ColorId;
            UpdatedCarDto.ModelId = carDto.ModelId;
            UpdatedCarDto.ModelYear = carDto.ModelYear;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var CarResult = await _carAppService.UpdateAsync(Id, UpdatedCarDto);

            return new JsonResult(CarResult);
        }
    }
}

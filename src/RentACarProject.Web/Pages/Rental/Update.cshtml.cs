using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Models;
using RentACarProject.Permissions;
using RentACarProject.Rentals;
using RentACarProject.Rentals.Dtos;
using System.Threading.Tasks;

namespace RentACarProject.Web.Pages.Rental
{
    [Authorize(RentACarProjectPermissions.Rental.Update)]
    public class UpdateModel : PageModel
    {
        private readonly RentalAppService _rentalAppService;

        public UpdateModel(RentalAppService rentalAppService)
        {
            _rentalAppService = rentalAppService;
        }

        [BindProperty]
        public UpdatedRentalDto UpdatedRentalDto { get; set; }

        [BindProperty]
        public int Id { get; set; }

        public async Task OnGet(int id)
        {
            UpdatedRentalDto = new UpdatedRentalDto();
            var rentalDto = await _rentalAppService.GetAsync(id);
            Id = rentalDto.Id;
            UpdatedRentalDto.CarId = rentalDto.CarId;
            UpdatedRentalDto.RentDate = rentalDto.RentDate;
            UpdatedRentalDto.ReturnDate = rentalDto.ReturnDate;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var rentalResult = await _rentalAppService.UpdateAsync(Id, UpdatedRentalDto);

            return new JsonResult(rentalResult);
        }
    }
}

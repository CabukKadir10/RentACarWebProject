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
    [Authorize(RentACarProjectPermissions.Rental.Create)]
    public class AddModel : PageModel
    {
        private readonly RentalAppService _rentalAppService;

        public AddModel(RentalAppService rentalAppService)
        {
            _rentalAppService = rentalAppService;
        }

        [BindProperty]
        public CreatedRentalDto CreatedRentalDto { get; set; }
        public void OnGet()
        {
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            var rentalResult = await _rentalAppService.CreateAsync(CreatedRentalDto);
            return new JsonResult(rentalResult);
        }
    }
}

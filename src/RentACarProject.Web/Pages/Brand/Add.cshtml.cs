using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Brands;
using RentACarProject.Brands.Dtos;
using RentACarProject.Cars;
using RentACarProject.Permissions;
using System.Threading.Tasks;

namespace RentACarProject.Web.Pages.Brand
{
    [Authorize(RentACarProjectPermissions.Brand.Create)]
    public class AddModel : PageModel
    {
        private readonly BrandAppService _brandAppService;

        public AddModel(BrandAppService brandAppService)
        {
            _brandAppService = brandAppService;
        }

        [BindProperty]
        public CreatedBrandDto CreatedBrandDto { get; set; }

        public void OnGet()
        {
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            var brandResult = await _brandAppService.CreateAsync(CreatedBrandDto);
            return new JsonResult(brandResult);
        }
    }
}

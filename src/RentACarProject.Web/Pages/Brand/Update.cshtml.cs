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
    [Authorize(RentACarProjectPermissions.Brand.Update)]
    public class UpdateModel : PageModel
    {
        private readonly BrandAppService _brandAppService;

        public UpdateModel(BrandAppService brandAppService)
        {
            _brandAppService = brandAppService;
        }

        [BindProperty]
        public UpdatedBrandDto UpdatedBrandDto { get; set; }
        [BindProperty]
        public int Id { get; set; }

        public async Task OnGet(int id)
        {
            UpdatedBrandDto = new UpdatedBrandDto();
            var brandDto = await _brandAppService.GetAsync(id);
            Id = brandDto.Id;
            UpdatedBrandDto.Name = brandDto.Name;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var brandResult = await _brandAppService.UpdateAsync(Id, UpdatedBrandDto);

            return new JsonResult(brandResult);
        }
    }
}

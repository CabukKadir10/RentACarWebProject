using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Colors;
using RentACarProject.Colors.Dtos;
using RentACarProject.Permissions;
using System.Threading.Tasks;

namespace RentACarProject.Web.Pages.Color
{
    [Authorize(RentACarProjectPermissions.Color.Create)]
    public class AddModel : PageModel
    {
        private readonly ColorAppService _colorAppService;

        public AddModel(ColorAppService colorAppService)
        {
            _colorAppService = colorAppService;
        }

        [BindProperty]
        public CreatedColorDto CreatedColorDto { get; set; }

        public void OnGet()
        {
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            var colorResult = await _colorAppService.CreateAsync(CreatedColorDto);
            return new JsonResult(colorResult);
        }
    }
}

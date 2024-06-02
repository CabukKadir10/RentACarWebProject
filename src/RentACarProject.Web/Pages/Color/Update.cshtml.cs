using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Cars;
using RentACarProject.Colors;
using RentACarProject.Colors.Dtos;
using RentACarProject.Permissions;
using System.Threading.Tasks;

namespace RentACarProject.Web.Pages.Color
{
    [Authorize(RentACarProjectPermissions.Color.Update)]
    public class UpdateModel : PageModel
    {
        private readonly ColorAppService _colorAppService;

        public UpdateModel(ColorAppService colorAppService)
        {
            _colorAppService = colorAppService;
        }
        [BindProperty]
        public UpdatedColorDto UpdatedColorDto { get; set; }
        [BindProperty]
        public int Id { get; set; }

        public async Task OnGet(int id)
        {
            UpdatedColorDto = new UpdatedColorDto();
            var tagDto = await _colorAppService.GetAsync(id);
            Id = tagDto.Id;
            UpdatedColorDto.Name = tagDto.Name;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var tagResult = await _colorAppService.UpdateAsync(Id, UpdatedColorDto);

            return new JsonResult(tagResult);
        }
    }
}

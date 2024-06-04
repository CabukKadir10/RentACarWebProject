using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Models;
using RentACarProject.Models.Dtos;
using RentACarProject.Permissions;
using System.Threading.Tasks;

namespace RentACarProject.Web.Pages.Model
{
    [Authorize(RentACarProjectPermissions.Model.Create)]
    public class AddModel : PageModel
    {
        private readonly ModelAppService _modelAppService;

        public AddModel(ModelAppService modelAppService)
        {
            _modelAppService = modelAppService;
        }

        [BindProperty]
        public CreatedModelDto CreatedModelDto { get; set; }
        public void OnGet()
        {
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            var modelResult = await _modelAppService.CreateAsync(CreatedModelDto);
            return new JsonResult(modelResult);
        }
    }
}

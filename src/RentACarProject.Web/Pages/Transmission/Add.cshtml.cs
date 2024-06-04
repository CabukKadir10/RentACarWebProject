using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Permissions;
using RentACarProject.Transmissions;
using RentACarProject.Transmissions.Dtos;
using System.Threading.Tasks;

namespace RentACarProject.Web.Pages.Transmission
{
    [Authorize(RentACarProjectPermissions.Transmission.Create)]
    public class AddModel : PageModel
    {
        private readonly TransmissionAppService _transmissionAppService;

        public AddModel(TransmissionAppService transmissionAppService)
        {
            _transmissionAppService = transmissionAppService;
        }

        [BindProperty]
        public CreatedTransmissionDto CreatedTransmissionDto { get; set; }

        public void OnGet()
        {
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            var transmissionResult = await _transmissionAppService.CreateAsync(CreatedTransmissionDto);
            return new JsonResult(transmissionResult);
        }
    }
}

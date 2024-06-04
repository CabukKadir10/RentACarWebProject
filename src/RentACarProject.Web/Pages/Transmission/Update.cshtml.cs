using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Permissions;
using RentACarProject.Transmissions;
using RentACarProject.Transmissions.Dtos;
using System.Threading.Tasks;

namespace RentACarProject.Web.Pages.Transmission
{
    [Authorize(RentACarProjectPermissions.Transmission.Update)]
    public class UpdateModel : PageModel
    {
        private readonly TransmissionAppService _transmissionAppService;

        public UpdateModel(TransmissionAppService transmissionAppService)
        {
            _transmissionAppService = transmissionAppService;
        }

        [BindProperty]
        public UpdatedTransmissionDto UpdatedTransmissionDto { get; set; }
        [BindProperty]
        public int Id { get; set; }

        public async Task OnGet(int id)
        {
            UpdatedTransmissionDto = new UpdatedTransmissionDto();
            var transmissionDto = await _transmissionAppService.GetAsync(id);
            Id = transmissionDto.Id;
            UpdatedTransmissionDto.Name = transmissionDto.Name;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var transmissionResult = await _transmissionAppService.UpdateAsync(Id, UpdatedTransmissionDto);

            return new JsonResult(transmissionResult);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Permissions;

namespace RentACarProject.Web.Pages.Transmission
{
    [Authorize(RentACarProjectPermissions.Transmission.List)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

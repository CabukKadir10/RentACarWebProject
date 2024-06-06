using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Permissions;

namespace RentACarProject.Web.Pages.Rental
{
    [Authorize(RentACarProjectPermissions.Rental.List)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

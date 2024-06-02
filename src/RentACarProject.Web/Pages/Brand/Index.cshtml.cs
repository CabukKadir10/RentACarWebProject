using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Permissions;

namespace RentACarProject.Web.Pages.Brand
{
    [Authorize(RentACarProjectPermissions.Brand.List)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

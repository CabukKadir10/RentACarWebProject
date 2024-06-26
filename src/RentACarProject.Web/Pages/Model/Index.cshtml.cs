using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarProject.Permissions;

namespace RentACarProject.Web.Pages.Model
{
    [Authorize(RentACarProjectPermissions.Model.List)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

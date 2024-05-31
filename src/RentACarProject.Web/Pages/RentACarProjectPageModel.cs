using RentACarProject.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace RentACarProject.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class RentACarProjectPageModel : AbpPageModel
{
    protected RentACarProjectPageModel()
    {
        LocalizationResourceType = typeof(RentACarProjectResource);
    }
}

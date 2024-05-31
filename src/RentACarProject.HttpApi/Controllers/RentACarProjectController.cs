using RentACarProject.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace RentACarProject.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class RentACarProjectController : AbpControllerBase
{
    protected RentACarProjectController()
    {
        LocalizationResource = typeof(RentACarProjectResource);
    }
}

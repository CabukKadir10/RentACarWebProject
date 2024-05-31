using System;
using System.Collections.Generic;
using System.Text;
using RentACarProject.Localization;
using Volo.Abp.Application.Services;

namespace RentACarProject;

/* Inherit your application services from this class.
 */
public abstract class RentACarProjectAppService : ApplicationService
{
    protected RentACarProjectAppService()
    {
        LocalizationResource = typeof(RentACarProjectResource);
    }
}

using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace RentACarProject.Web;

[Dependency(ReplaceServices = true)]
public class RentACarProjectBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "RentACarProject";
}

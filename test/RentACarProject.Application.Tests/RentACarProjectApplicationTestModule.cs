using Volo.Abp.Modularity;

namespace RentACarProject;

[DependsOn(
    typeof(RentACarProjectApplicationModule),
    typeof(RentACarProjectDomainTestModule)
)]
public class RentACarProjectApplicationTestModule : AbpModule
{

}

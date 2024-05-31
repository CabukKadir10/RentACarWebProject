using Volo.Abp.Modularity;

namespace RentACarProject;

[DependsOn(
    typeof(RentACarProjectDomainModule),
    typeof(RentACarProjectTestBaseModule)
)]
public class RentACarProjectDomainTestModule : AbpModule
{

}

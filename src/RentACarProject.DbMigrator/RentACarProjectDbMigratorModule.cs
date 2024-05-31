using RentACarProject.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace RentACarProject.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(RentACarProjectEntityFrameworkCoreModule),
    typeof(RentACarProjectApplicationContractsModule)
    )]
public class RentACarProjectDbMigratorModule : AbpModule
{
}

using Volo.Abp.Modularity;

namespace RentACarProject;

public abstract class RentACarProjectApplicationTestBase<TStartupModule> : RentACarProjectTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

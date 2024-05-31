using Volo.Abp.Modularity;

namespace RentACarProject;

/* Inherit from this class for your domain layer tests. */
public abstract class RentACarProjectDomainTestBase<TStartupModule> : RentACarProjectTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

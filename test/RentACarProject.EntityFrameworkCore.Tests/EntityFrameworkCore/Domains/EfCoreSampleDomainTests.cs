using RentACarProject.Samples;
using Xunit;

namespace RentACarProject.EntityFrameworkCore.Domains;

[Collection(RentACarProjectTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<RentACarProjectEntityFrameworkCoreTestModule>
{

}

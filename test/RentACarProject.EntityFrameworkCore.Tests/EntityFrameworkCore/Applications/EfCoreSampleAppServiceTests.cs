using RentACarProject.Samples;
using Xunit;

namespace RentACarProject.EntityFrameworkCore.Applications;

[Collection(RentACarProjectTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<RentACarProjectEntityFrameworkCoreTestModule>
{

}

using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace RentACarProject.Pages;

public class Index_Tests : RentACarProjectWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

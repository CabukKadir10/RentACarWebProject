using Microsoft.AspNetCore.Builder;
using RentACarProject;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<RentACarProjectWebTestModule>();

public partial class Program
{
}

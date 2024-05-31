using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace RentACarProject.Data;

/* This is used if database provider does't define
 * IRentACarProjectDbSchemaMigrator implementation.
 */
public class NullRentACarProjectDbSchemaMigrator : IRentACarProjectDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

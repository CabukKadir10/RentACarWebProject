using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentACarProject.Data;
using Volo.Abp.DependencyInjection;

namespace RentACarProject.EntityFrameworkCore;

public class EntityFrameworkCoreRentACarProjectDbSchemaMigrator
    : IRentACarProjectDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreRentACarProjectDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the RentACarProjectDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<RentACarProjectDbContext>()
            .Database
            .MigrateAsync();
    }
}

using System.Threading.Tasks;

namespace RentACarProject.Data;

public interface IRentACarProjectDbSchemaMigrator
{
    Task MigrateAsync();
}

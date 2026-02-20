using Microsoft.EntityFrameworkCore;
using RestWithASPNET10Gerhard.Model.Context;

namespace RestWithASPNET10Gerhard.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["MSSQLServerConnection:MSSQLServerConnectionString"];

        if (string.IsNullOrEmpty(connectionString))
            throw new Exception("Connection string for MSSQL Server is not configured.");

        services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connectionString));
    }
}

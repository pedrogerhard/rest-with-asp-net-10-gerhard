using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace RestWithASPNET10Gerhard.Configurations;

public static class EvolveConfig
{
    public static IServiceCollection AddEvolveConfiguration(
                this IServiceCollection services,
                IConfiguration configuration,
                IWebHostEnvironment environment)
    {

        if (environment.IsDevelopment())
        {
            var connectionString = configuration["MSSQLServerConnection:MSSQLServerConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Connection string for MSSQL Server is not configured.");
            try
            {
                using var evolveConnection = new SqlConnection(connectionString);

                var evolve = new Evolve(
                        evolveConnection,
                        msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error ocurred while migrating the database.");
                throw;
            }
        }

        return services;
    }

}


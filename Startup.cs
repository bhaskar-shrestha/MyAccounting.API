using Microsoft.EntityFrameworkCore;
using MyAccounting.Api.DataAccess;

namespace MyAccounting.Api
{
    public static class Startup
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<AccountingContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("AccountingConnection")));

            services.AddControllersWithViews();
        }

        public static void CreateDbIfNotExists(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AccountingContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Redgate.WebHost.LightingTalk.Data;

namespace Redgate.WebHost.LightingTalk.IntegrationTests.Utility
{
    public class CustomWebApplicationFactory: WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<ItemContext>));

                services.Remove(descriptor);
                
                services.AddDbContext<ItemContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDb");
                });
                
                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();

                var itemContext = scope.ServiceProvider.GetRequiredService<ItemContext>();
                itemContext.Database.EnsureCreated();
                try
                {
                    InMemoryDatabaseHelper.InitializeDb(itemContext);
                }
                catch
                {
                    
                }
            });
        }
    }
}
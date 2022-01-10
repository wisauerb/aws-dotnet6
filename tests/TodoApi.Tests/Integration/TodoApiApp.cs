using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace TodoApi.Tests.Integration;

// c.f. https://dotnetthoughts.net/dotnet-minimal-api-integration-testing/

class TodoApiApp : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        // var root = new InMemoryDatabaseRoot();

        // builder.ConfigureServices(services =>
        // {
        //     services.RemoveAll(typeof(DbContextOptions<NotesDbContext>));
        //     services.AddDbContext<NotesDbContext>(options =>
        //         options.UseInMemoryDatabase("Testing", root));
        // });

        return base.CreateHost(builder);
    }
}

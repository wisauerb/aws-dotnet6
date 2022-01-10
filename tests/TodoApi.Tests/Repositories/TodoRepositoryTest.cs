using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using TodoApi.Repositories;
using Xunit;

namespace TodoApi.Tests.Repositories;

public class TodoRepositoryTest
{
    // [Fact]
    [Fact(Skip="for manual test during dev")]
    public void TestGetTodo()
    {
        var builder = new ConfigurationBuilder();

        var currDir = Directory.GetCurrentDirectory();
        var json = "appsettings.Development.json";

        var configuration = builder.SetBasePath(currDir).AddJsonFile(json).Build();
        var connString = configuration.GetConnectionString("DefaultConnection");

        var logger = Mock.Of<ILogger<TodoRepository>>();
        var connection = new SqlConnection(connString);
        var repo = new TodoRepository(logger, connection);

        var item = repo.GetTodo(1);

        Assert.Equal("Foo", item.Name);
    }
}

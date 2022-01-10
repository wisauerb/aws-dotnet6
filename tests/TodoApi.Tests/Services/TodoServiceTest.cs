using Moq;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Services;
using Xunit;

namespace TodoApi.Tests.Services;

public class TodoServiceTest
{
    [Fact]
    public void TestService()
    {
        // Given
        var repo = new Mock<ITodoRepository>();
        var service = new TodoService(repo.Object);

        // When
        repo.Setup(_ => _.GetTodo(1))
            .Returns(new TodoItem(1, "Foo", false));

        // Then
        var actual = service.GetTodo(1);

        var expected = new TodoItem(1, "Foo", false);
        Assert.Equal(expected, actual);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TodoApi.Controllers;
using TodoApi.Models;
using TodoApi.Services;
using Xunit;

namespace TodoApi.Tests.Controllers;

// c.f. https://docs.microsoft.com/ja-jp/aspnet/core/mvc/controllers/testing?view=aspnetcore-6.0

public class TodoControllerTest
{
    [Fact]
    public void TestName()
    {
        // Given
        var logger = Mock.Of<ILogger<TodoController>>();

        var service = new Mock<ITodoService>();
        service.Setup(_ => _.GetTodo(1)).Returns(new TodoItem(1, "Foo", false));

        var controller = new TodoController(logger, service.Object);

        // When
        var result = controller.Get(1);

        // Then
        var actionResult = Assert.IsType<ActionResult<TodoItem>>(result);
        var returnValue = Assert.IsType<TodoItem>(actionResult.Value);

        var expected = new TodoItem(1, "Foo", false);
        Assert.Equal(expected, returnValue);

        // Test NotFound
        var result2 = controller.Get(100);

        // Then
        var actionResult2 = Assert.IsType<ActionResult<TodoItem>>(result2);
        Assert.IsType<NotFoundResult>(actionResult2.Result);
    }
}

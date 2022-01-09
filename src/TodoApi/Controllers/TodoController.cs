using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> _logger;
    private readonly ITodoService _service;

    public TodoController(ILogger<TodoController> logger, ITodoService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet(Name = "GetTodo")]
    public IEnumerable<TodoItem> Get()
    {
        return _service.GetTodos();
    }

    [HttpGet("{id}", Name = "GetTodoById")]
    public TodoItem Get(int id)
    {
        return _service.GetTodo(id);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<TodoItem> Post(TodoItem todoItem)
    {
        var newItem = _service.AddTodo(todoItem);

        return CreatedAtAction("Get", new { Id = newItem.Id }, newItem);
    }
}

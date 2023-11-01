using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

// c.f. Microsoft scaffolding controller
// https://www.qes.co.jp/media/Microservices/a48

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

        var lista = new List<TodoItem>()
        {
            new TodoItem(20000, "Goku", true),
            new TodoItem(19000, "Vegeta", true),
            new TodoItem(22000, "Trunks", true),
            new TodoItem(1000, "Krillin", true),
            new TodoItem(10000, "Pan", true)
        };

        return lista;
        //return _service.GetTodos();
    }

    [HttpGet("{id}", Name = "GetTodoById")]
    public ActionResult<TodoItem> Get(int id)
    {
        var item = _service.GetTodo(id);

        if (item == null)
            return NotFound();

        return item;
    }

    [HttpPost]
    public ActionResult<TodoItem> Post(TodoItem todoItem)
    {
        var newItem = _service.AddTodo(todoItem);

        return CreatedAtAction("Get", new { Id = newItem.Id }, newItem);
    }

    [HttpPut("{id}")]
    public ActionResult<TodoItem> Put(int id, TodoItem todoItem)
    {
        if (id != todoItem.Id)
            return BadRequest();

        var affectedRows = _service.UpdateTodo(todoItem);

        if (affectedRows == 0)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult<TodoItem> Delete(int id)
    {
        var todoItem = _service.GetTodo(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        _service.DeleteTodo(todoItem);
        return todoItem;
    }
}

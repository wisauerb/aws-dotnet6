using System.Data;
using Dapper;
using TodoApi.Models;

namespace TodoApi.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly ILogger<TodoRepository> _logger;
    private readonly IDbConnection _conn;

    public TodoRepository(ILogger<TodoRepository> logger, IDbConnection conn)
    {
        _logger = logger;
        _conn = conn;
    }

    public IEnumerable<TodoItem> GetTodos()
    {
        return _conn.GetList<TodoItem>();
    }

    public TodoItem GetTodo(int id)
    {
        return _conn.Get<TodoItem>(id);
    }

    public TodoItem AddTodo(TodoItem todoItem)
    {
        var newId = _conn.Insert<TodoItem>(todoItem);

        if (newId == null)
            throw new ArgumentException($"Error AddTodo {todoItem}");

        return todoItem with { Id = newId.GetValueOrDefault() };
    }

    public int UpdateTodo(TodoItem todoItem)
    {
        var affectedRows = _conn.Update<TodoItem>(todoItem);

        if (affectedRows == 0){
            _logger.LogWarning($"UpdateTodo not updated {todoItem}");
        }

        return affectedRows;
    }

    public void DeleteTodo(TodoItem todoItem)
    {
        _conn.Delete<TodoItem>(todoItem);
    }
}

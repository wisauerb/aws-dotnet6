using System.Data;
using Dapper;
using TodoApi.Models;

namespace TodoApi.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly IDbConnection _conn;

    public TodoRepository(IDbConnection conn)
    {
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
}

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
        var sql = "SELECT * FROM TodoItem";
        return _conn.Query<TodoItem>(sql);
    }
}

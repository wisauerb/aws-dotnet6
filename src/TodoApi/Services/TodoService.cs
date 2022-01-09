using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repo;

    public TodoService(ITodoRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<TodoItem> GetTodos()
    {
        return _repo.GetTodos();
    }

    public TodoItem GetTodo(int id)
    {
        return _repo.GetTodo(id);
    }
}

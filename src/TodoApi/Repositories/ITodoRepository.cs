using TodoApi.Models;

namespace TodoApi.Repositories;

public interface ITodoRepository
{
    IEnumerable<TodoItem> GetTodos();
    TodoItem GetTodo(int id);
    TodoItem AddTodo(TodoItem todoItem);
}

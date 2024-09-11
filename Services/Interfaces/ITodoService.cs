using TodoApp.Models;

namespace TodoApp.Services.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetTodosAsync();
        Task AddTodoAsync(TodoItem item);
    }
}
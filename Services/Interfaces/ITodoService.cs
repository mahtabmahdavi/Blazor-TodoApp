using TodoApp.Models;

namespace TodoApp.Services.Interfaces
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetTodoItemsAsync();
        Task AddTodoItemAsync(TodoItem item);
        Task DeleteTodoItemAsync(TodoItem item);
        Task UpdateTodoItemAsync(TodoItem item);
    }
}
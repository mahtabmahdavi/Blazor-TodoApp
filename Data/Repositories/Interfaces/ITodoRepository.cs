using TodoApp.Models;

namespace TodoApp.Data.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem?> GetById(int id);
        Task AddAsync(TodoItem item);
        Task DeleteAsync(int id);
        Task UpdateAsync(TodoItem item);
    }
}
using TodoApp.Data.Repositories.Interfaces;
using TodoApp.Models;
using TodoApp.Services.Interfaces;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TodoItem>> GetTodoItemsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddTodoItemAsync(TodoItem item)
        {
            await _repository.AddAsync(item);
        }
    }
}

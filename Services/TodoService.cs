using TodoApp.Data.Repositories;
using TodoApp.Models;
using TodoApp.Services.Interfaces;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoRepository _repository;

        public TodoService(TodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoItem>> GetTodosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddTodoAsync(TodoItem item)
        {
            await _repository.AddAsync(item);
        }
    }
}

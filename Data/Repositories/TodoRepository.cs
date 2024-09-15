using Microsoft.EntityFrameworkCore;
using TodoApp.Data.Repositories.Interfaces;
using TodoApp.Models;

namespace TodoApp.Data.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;

        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.AsNoTracking().ToListAsync();
        }

        public async Task<TodoItem> GetById(int id)
        {
            var result = await _context.TodoItems.AsNoTracking()
                .Where(i => i.Id == id)
                .FirstAsync();

            if (result == null)
                throw new Exception($"The task with id = {id} doesn't exist!");
            return result;
        }

        public async Task AddAsync(TodoItem item)
        {
            _context.Attach(item);
            _context.Entry(item).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = new TodoItem { Id = id };

            if (item != null)
            {
                _context.Attach(item);
                _context.Entry(item).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TodoItem item)
        {
            _context.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

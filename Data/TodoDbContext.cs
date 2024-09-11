﻿using Microsoft.EntityFrameworkCore;

namespace TodoApp.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }
        
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}

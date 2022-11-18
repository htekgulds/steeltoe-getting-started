using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Domain
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }
    }
}
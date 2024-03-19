using TaskTodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskTodoApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TaskTodo> TaskTodos { get; set; }

    }
}

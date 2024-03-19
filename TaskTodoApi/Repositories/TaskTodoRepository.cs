using TaskTodoApi.Data;
using TaskTodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskTodoApi.Repositories;

public class TaskTodoRepository
{
    private readonly DataContext _dataContext;

    public TaskTodoRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<TaskTodo>> GetAllTasks ()
    {
        return await _dataContext.TaskTodos.ToListAsync();
    }
    public async Task<TaskTodo> GetTaskById(int id)
    {
        return await _dataContext.TaskTodos.FindAsync(id);
    }

    public async Task CreateTask(TaskTodo task)
    {
        _dataContext.TaskTodos.Add(task);
        await SaveChangesAsync();
    }

    public async Task UpdateTask(int id, TaskTodo UpdatedTaskTodo)
    {
        var existingTask = await _dataContext.TaskTodos.FindAsync(id);

        if (existingTask != null)
        {
            existingTask.Department = UpdatedTaskTodo.Department;
            existingTask.Title = UpdatedTaskTodo.Title;
            existingTask.Description = UpdatedTaskTodo.Description;
            existingTask.Deadline = UpdatedTaskTodo.Deadline;

            await SaveChangesAsync();
        }

    }

    public async Task DeleteTask(int id)
    {
        var task = await _dataContext.TaskTodos.FindAsync(id);
        if (task != null)
        {
            _dataContext.TaskTodos.Remove(task);
            await SaveChangesAsync();
        }
        
    }

    private async Task SaveChangesAsync()
    {
        await _dataContext.SaveChangesAsync();
    }
}

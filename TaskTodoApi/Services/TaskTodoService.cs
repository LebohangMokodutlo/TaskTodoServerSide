using TaskTodoApi.Models;
using TaskTodoApi.Repositories;
using TaskTodoApi.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TaskTodoApi.Services
{
    public class TaskTodoService
    {
    private readonly TaskTodoRepository _repository;

        public TaskTodoService(TaskTodoRepository taskTodoRepository)
        {
            _repository = taskTodoRepository;
        }
        public async Task<List<TaskTodo>> GetAllTasks()
        {
            return await _repository.GetAllTasks();
        }

        public async Task<TaskTodo> GetTaskById(int id)
        {
            return await _repository.GetTaskById(id);
        }

        public async Task CreateTaskTodo(TaskTodoDto taskDto)
        {
            var task = MapDtoToModel(taskDto);
            await _repository.CreateTask(task);
        }

        public async Task<TaskTodo> UpdateTaskTodo(int id, TaskTodoDto updatedTaskDto)
        {
            var existingTask = await _repository.GetTaskById(id);
            if(existingTask == null)
            {
                throw new Exception();
            }

            existingTask.Department = updatedTaskDto.Department;
            existingTask.Title = updatedTaskDto.Title;
            existingTask.Description = updatedTaskDto.Description;
            existingTask.Deadline = updatedTaskDto.Deadline;

            await _repository.UpdateTask(id, existingTask);

            return existingTask;
        }

        public async Task DeleteTask(int id)
        {
            await _repository.DeleteTask(id);
        }

       private TaskTodo MapDtoToModel(TaskTodoDto dto)
            {
            return new TaskTodo
            {
                Department = dto.Department,
                Title = dto.Title,
                Description = dto.Description,
                Deadline = dto.Deadline,
            };
          }
    }
}

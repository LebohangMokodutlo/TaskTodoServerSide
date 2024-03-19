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

        public async Task CreateTaskTodo(CreateTaskTodoDto createTaskDto)
        {
            var task = MapCreateTaskTodoDtoToModel(createTaskDto);
            await _repository.CreateTask(task);
        }

        public async Task<TaskTodo> UpdateTaskTodo(int id, UpdateTaskTodoDto updatedTaskTodoDto)
        {
            var existingTask = await _repository.GetTaskById(id);
            if (existingTask == null)
            {
                throw new Exception("Task not found"); // Better to provide a more informative exception message
            }

            // Use mapping method to update existing task
            MapUpdateTaskTodoDtoToModel(updatedTaskTodoDto, existingTask);

            await _repository.UpdateTask(id, existingTask);

            return existingTask;
        }

        public async Task DeleteTask(int id)
        {
            await _repository.DeleteTask(id);
        }

        private void MapUpdateTaskTodoDtoToModel(UpdateTaskTodoDto dto, TaskTodo existingTask)
        {
            existingTask.Department = dto.Department;
            existingTask.Title = dto.Title;
            existingTask.Description = dto.Description;
            existingTask.Deadline = dto.Deadline;
        }


        private TaskTodo MapCreateTaskTodoDtoToModel(CreateTaskTodoDto dto)
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

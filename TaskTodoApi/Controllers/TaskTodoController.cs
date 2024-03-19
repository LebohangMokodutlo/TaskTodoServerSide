using TaskTodoApi.Services;
using Microsoft.AspNetCore.Mvc;
using TaskTodoApi.Dtos;
using TaskTodoApi.Models;

namespace TaskTodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTodoController : ControllerBase
    {

        private readonly TaskTodoService _taskTodoService;

        public TaskTodoController(TaskTodoService taskTodoService)
        {
            _taskTodoService = taskTodoService;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllTasksTodo()
        {

            var tasks = await _taskTodoService.GetAllTasks();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTaskTodoById(int id)
        {
            var task = await _taskTodoService.GetTaskById(id);
            if (task == null)
            {
                return BadRequest("Task with id " + id + " was not found");

            }
            return Ok(task);
        }

        [HttpPost]

        public async Task<ActionResult<List<TaskTodo>>> CreateTaskTodo(TaskTodoDto taskTodoDto)
        {
            await _taskTodoService.CreateTaskTodo(taskTodoDto);
            return Ok(await _taskTodoService.GetAllTasks());
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<List<TaskTodo>>> UpdateTaskTodo(int id, [FromBody] TaskTodoDto taskTodoDto)
        {
            var updatedTask = await _taskTodoService.GetTaskById(id);
            if (updatedTask == null)
            {
                return BadRequest("Task with" + id + "does not exist");

            }

            await _taskTodoService.UpdateTaskTodo(id, taskTodoDto);
            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TaskTodo>>> DeleteTask(int id)
        {
            var task = await _taskTodoService.GetTaskById(id);
            if (task == null)
            {
                return BadRequest("Task with " + id + "could not be deleted, because it does not exist");
            }
            await _taskTodoService.DeleteTask(id);
            return Ok(await _taskTodoService.GetAllTasks());
        }
    }
}

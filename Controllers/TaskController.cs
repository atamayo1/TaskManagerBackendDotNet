// Controllers/TaskController.cs
using Microsoft.AspNetCore.Mvc;
using TaskManagerBackendDotNet.Models;
using TaskManagerBackendDotNet.Repositories;
using Task = TaskManagerBackendDotNet.Models.Task;

namespace TaskManagerBackendDotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskRepository _taskRepository;

        public TaskController(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Task), 201)]
        public IActionResult AddTask(string title, string description, bool isCompleted)
        {
            var task = new Task
            {
                Title = title,
                Description = description,
                IsCompleted = isCompleted
            };
            _taskRepository.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Task), 200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTask(int id, string title, string description, bool isCompleted)
        {
            var existingTask = _taskRepository.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound();
            }

            existingTask.Title = title;
            existingTask.Description = description;
            existingTask.IsCompleted = isCompleted;

            _taskRepository.UpdateTask(existingTask);

            return Ok(existingTask);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var existingTask = _taskRepository.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound();
            }

            _taskRepository.DeleteTask(id);

            return NoContent();
        }
    }
}

// Repositories/TaskRepository.cs
using System.Collections.Generic;
using System.Linq;
using TaskManagerBackendDotNet.Models;
using Task = TaskManagerBackendDotNet.Models.Task;

namespace TaskManagerBackendDotNet.Repositories
{
    public class TaskRepository
    {
        private readonly List<Task> _tasks;
        private int _nextTaskId = 1;

        public TaskRepository()
        {
            _tasks = new List<Task>();
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _tasks;
        }

        public Task GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(task => task.Id == id);
        }

        public void AddTask(Task task)
        {
            task.Id = _nextTaskId++;
            _tasks.Add(task);
        }

        public void UpdateTask(Task updatedTask)
        {
            var existingTask = _tasks.FirstOrDefault(task => task.Id == updatedTask.Id);
            if (existingTask != null)
            {
                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.IsCompleted = updatedTask.IsCompleted;
            }
        }

        public void DeleteTask(int id)
        {
            var taskToRemove = _tasks.FirstOrDefault(task => task.Id == id);
            if (taskToRemove != null)
            {
                _tasks.Remove(taskToRemove);
            }
        }
    }
}

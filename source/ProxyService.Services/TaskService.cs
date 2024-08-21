using ProxyService.Application.DTOs;
using ProxyService.Domain.Interfaces;
using ProxyService.Services.Common;
using ProxyService.Services.Contracts;
using Task = ProxyService.Domain.Entities.Task;

namespace ProxyService.Services
{
	[Service]
	public class TaskService : ITaskService
	{
		private readonly ITaskRepository _repository;

		public TaskService(ITaskRepository repository)
		{
			_repository = repository;
		}

		public Task GetById(int id)
		{
			var task = _repository.GetById(id);
			if (task == null)
			{
				throw new Exception("Task not found.");
			}
			return task;
		}

		public Task CreateTask(TaskDto taskDto)
		{
			var task = new Task { Title = taskDto.Title, Description = taskDto.Description, IsComplete = taskDto.IsComplete };
			_repository.Add(task);
			return task;
		}

		public Task UpdateTask(int id, TaskDto taskDto)
		{
			var task = _repository.GetById(id);
			if (task == null)
			{
				throw new Exception("Task not found.");
			}
			task.Title = taskDto.Title;
			task.Description = taskDto.Description;
			task.IsComplete = taskDto.IsComplete;
			_repository.Update(task);
			return task;
		}

		public void DeleteTask(int id)
		{
			var task = _repository.GetById(id);
			if (task == null)
			{
				throw new Exception("Task not found.");
			}
			_repository.Delete(task);
		}
	}
}
namespace ProxyService.Services.Contracts
{
	using Application.DTOs;
	using Common;
	using Task = Domain.Entities.Task;

	[ServiceContract]
	public interface ITaskService
	{
		Task CreateTask(TaskDto taskDto);

		void DeleteTask(int id);

		Task GetById(int id);

		Task UpdateTask(int id, TaskDto taskDto);
	}
}
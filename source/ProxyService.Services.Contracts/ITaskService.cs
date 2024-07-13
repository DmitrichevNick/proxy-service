namespace ProxyService.Services.Contracts;

using ProxyService.Application.DTOs;
using ProxyService.Services.Common;
using Task = ProxyService.Domain.Entities.Task;

[ServiceContract]
public interface ITaskService
{
    Task CreateTask(TaskDto taskDto);
    void DeleteTask(int id);
    Task GetById(int id);
    Task UpdateTask(int id, TaskDto taskDto);
}
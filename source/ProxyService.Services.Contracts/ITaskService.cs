namespace ProxyService.Services.Contracts;
using Task = ProxyService.Domain.Entities.Task;
public interface ITaskService
{
    Task GetById(int id);
    void Add(Task task);
    void Update(Task task);
    void Delete(Task task);
}
using ProxyService.Services.Common;
using Task = ProxyService.Domain.Entities.Task;

namespace ProxyService.Domain.Interfaces
{
    [ServiceContract]
    public interface ITaskRepository
    {
        Task GetById(int id);
        void Add(Task task);
        void Update(Task task);
        void Delete(Task task);
    }
}

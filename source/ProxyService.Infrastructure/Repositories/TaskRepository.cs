using ProxyService.Domain.Interfaces;
using ProxyService.Services.Common;
using Task = ProxyService.Domain.Entities.Task;

namespace ProxyService.Infrastructure.Repositories
{
    [Service]
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task GetById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public void Add(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Update(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void Delete(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProxyService.Application.DTOs;
using ProxyService.Application.Services;
using ProxyService.Services.Contracts;
using ProxyService.Services.Proxies;
using Task = ProxyService.Domain.Entities.Task;

namespace ProxyService.Web.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        private readonly IServiceProvider _serviceProvider;

        public TaskController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _service = serviceProvider.GetService<ITaskService>();
        }

        [HttpGet("get-tasks")]
        public ActionResult<IList<Task>> GetTasks()
        {
           
            return Ok(new List<Task>{new Task(),new Task()});
        }

        [HttpGet]
        public ActionResult<Task> GetById(int id)
        {
            var task = _service.GetById(id, 1);
            if (task == null)
            {
                //return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<Task> Create(TaskDto request)
        {
            var proxyManager = new ProxyService.Services.Proxies.ProxyManager(new ProxyInvoker(_serviceProvider));
            var proxy = proxyManager.CreateProxy<ITaskService>();
            proxy.CreateTask(request);
            //var taskDto = new TaskDto { Title = request.Title, Description = request.Description, IsComplete = request.IsComplete };
            //var task = _service.CreateTask(taskDto);
            return CreatedAtAction(nameof(GetById), new { id = 1}, null);
        }

        [HttpPut("{id}")]
        public ActionResult<Task> Update(int id, Task request)
        {
            var taskDto = new TaskDto { Title = request.Title, Description = request.Description, IsComplete = request.IsComplete };
            var task = _service.UpdateTask(id, taskDto);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeleteTask(id);
            return NoContent();
        }
    }
}

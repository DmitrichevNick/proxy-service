using Microsoft.Extensions.DependencyInjection;
using ProxyService.Domain.Interfaces;
using ProxyService.Infrastructure.Repositories;
using System.ComponentModel.Design;

namespace ProxyService.Infrastructure.Tests.UnitTests
{
    public class TaskRepositoryUnitTests
    {
        private readonly IServiceProvider _serviceProvider;
        public TaskRepositoryUnitTests() {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<ApplicationDbContext>();
            serviceCollection.AddScoped(typeof(ITaskRepository), typeof(TaskRepository));

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        [Fact]
        public void Test1()
        {
            var rep = _serviceProvider.GetService<ITaskRepository>();

            Assert.NotNull(rep);
        }
    }
}
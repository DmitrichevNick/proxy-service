using ProxyService.Domain.Entities;
using Task = ProxyService.Domain.Entities.Task;
namespace ProxyService.Domain.Tests.UnitTests;

[TestClass]
public class TaskUnitTests
{
    [TestMethod]
    public void CanCreateTask()
    {
        var task = new Task();

        Assert.IsNotNull(task);
    }
}
using ProxyService.Services.Contracts;

namespace ProxyService.Services.Proxies;

public interface IProxyService : IProxyInvoker
{

}

public class ProxyService : IProxyService
{
    private readonly IServiceProvider _serviceProvider;
    public ProxyService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    private object _target;
    public IProxyInvokeResult InvokeMember(IProxyInvokeContext proxyInvokeContext)
    {
        if (_target == null)
        {
            _target = _serviceProvider.GetService(proxyInvokeContext.Target);
        }

        var res = _target.GetType().GetMethod(proxyInvokeContext.MemberName).Invoke(_target, proxyInvokeContext.Parameters.Cast<object?>().ToArray());

        return new ProxyInvokeResult { Success = true, Result = res};
    }
}

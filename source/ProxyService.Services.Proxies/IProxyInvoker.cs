namespace ProxyService.Services.Proxies
{
    public interface IProxyInvoker
    {
        IProxyInvokeResult InvokeMember(IProxyInvokeContext proxyInvokeContext);
    }
}
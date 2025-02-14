namespace ProxyService.Services.Proxies
{
    /// <summary>
    ///     Default invoker without implementation
    /// </summary>
    public class ProxyInvoker : IProxyInvoker
    {
        private IProxyService _proxyService;

        public ProxyInvoker(IServiceProvider serviceProvider)
        {
            _proxyService = serviceProvider.GetService(typeof(IProxyService)) as IProxyService;
        }

        /// <inheritdoc/>
        public IProxyInvokeResult InvokeMember(IProxyInvokeContext proxyInvokeContext)
        {
            return _proxyService.InvokeMember(proxyInvokeContext);
        }
    }
}
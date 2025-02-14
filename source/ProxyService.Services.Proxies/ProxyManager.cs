namespace ProxyService.Services.Proxies
{
    /// <summary>
    ///     Manager of proxies
    /// </summary>
    public class ProxyManager : IProxyManager
    {
        private readonly IProxyInvoker _proxyInvoker;

        /// <summary>
        ///     Constructor with <see cref="IProxyInvoker"/>
        /// </summary>
        /// <param name="proxyInvoker">Proxy invoker</param>
        public ProxyManager(IProxyInvoker proxyInvoker)
        {
            _proxyInvoker = proxyInvoker;
        }

        /// <inheritdoc/>
        public T? CreateProxy<T>() where T : class
        {
            return DynamicProxy.Create<T>(_proxyInvoker);
        }
    }
}
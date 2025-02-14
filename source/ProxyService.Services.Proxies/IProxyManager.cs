namespace ProxyService.Services.Proxies
{
    /// <summary>
    ///     Interface of managers of proxies
    /// </summary>
    public interface IProxyManager
    {
        /// <summary>
        ///     Creates proxy of type T
        /// </summary>
        /// <typeparam name="T">Target type</typeparam>
        /// <returns>Proxied object</returns>
        T? CreateProxy<T>() where T : class;
    }
}
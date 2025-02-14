namespace ProxyService.Services.Proxies
{
    public interface IProxyInvokeResult
    {
        bool Success { get; set; }
        object? Result { get; set; }
    }

    public class ProxyInvokeResult : IProxyInvokeResult
    {
        public bool Success { get; set; }
        public object? Result { get; set; }
    }
}
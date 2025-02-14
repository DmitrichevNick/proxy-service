using System.Collections;

namespace ProxyService.Services.Proxies
{
    public interface IProxyInvokeContext
    {
        Type Target { get; set; }
        string MemberName { get; set; }
        IEnumerable? Parameters { get; set; }
    }
}
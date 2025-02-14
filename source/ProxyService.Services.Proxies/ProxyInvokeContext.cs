using System.Collections;

namespace ProxyService.Services.Proxies
{
    public class ProxyInvokeContext : IProxyInvokeContext
    {
        public Type Target { get; set; }
        public string MemberName { get; set; }
        public IEnumerable? Parameters { get; set; }
    }
}
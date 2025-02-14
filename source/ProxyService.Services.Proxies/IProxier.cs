using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyService.Services.Proxies
{
    public interface IProxier<T>
    {
        public T Target { get; set; }
    }
}

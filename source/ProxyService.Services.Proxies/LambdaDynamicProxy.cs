using System.Reflection;

namespace ProxyService.Services.Proxies
{
    /// <summary>
    ///     DynamicProxy
    /// </summary>
    internal class DynamicProxy : DispatchProxy
    {
        private IProxyInvoker? _proxyInvoker;
        private Type _targetType;

        /// <summary>
        ///     Parameterless constructor
        /// </summary>
        public DynamicProxy()
        {
            // ignored
        }

        public static T? Create<T>(IProxyInvoker proxyInvoker) where T : class
        {
            var proxy = Create<T, DynamicProxy>() as DynamicProxy;
            if (proxy == null) throw new InvalidOperationException("Brand new created proxy cannot be null");

            proxy._proxyInvoker = proxyInvoker;
            proxy._targetType = typeof(T);

            return proxy as T;
        }

        /// <inheritdoc />
        protected override object? Invoke(MethodInfo targetMethod, object[] args)
        {
            if (_proxyInvoker == null)
                throw new InvalidOperationException("DynamicProxy should have instanced invoker.");

            var result = _proxyInvoker.InvokeMember(new ProxyInvokeContext
            {
                Target = _targetType,
                MemberName = targetMethod.Name,
                Parameters = args
            });

            return result.Result;
        }
    }
}
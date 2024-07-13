namespace ProxyService.Services.Proxies
{
    public abstract class BaseServiceProxy<TService>
    {
        private  TService? _service;
        public TService Service { get => _service ?? (_service = (TService)new object()); }
        protected BaseServiceProxy()
        {
            typeof(TService).GetMethods()
        }

        protected void Invoke()
        {

        }

        public static TService Create(IServiceProvider serviceProvider)
        {
            serviceProvider.GetService
        }
    }
}
using System.Diagnostics;
using System.Reflection;

namespace ProxyService.Services.Common
{
    public class ServicesCollector
    {
        public static IEnumerable<(Type, Type)> Collect()
        {
            var result = new List<(Type, Type)>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(assembly => assembly.GetTypes());
            var implementationTypes = types.Where(type => type.GetCustomAttribute(typeof(ServiceAttribute), true) != null);
            foreach (var implementationType in implementationTypes)
            {
                if (implementationType != null)
                {
                    var contracts = implementationType.GetInterfaces();
                    var contractType = contracts.FirstOrDefault(contract => contract.GetCustomAttribute(typeof(ServiceContractAttribute), true) != null);

                    if (contractType != null)
                        yield return (contractType, implementationType);
                }
            }
        }
    }
}
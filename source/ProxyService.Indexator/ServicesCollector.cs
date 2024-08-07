using System.Diagnostics;
using System.Reflection;
using ProxyService.Services.Common;

namespace ProxyService.Indexator
{
	public class ServicesCollector
	{
		public static IEnumerable<(Type, Type)> Collect(IEnumerable<Type> types)
		{
			var services = GetServices(types);
			var contracts = GetServicesContracts(services);

			foreach (var service in services)
			{
				var contract = GetServicesContract(service);
				if (contract != null)
					yield return (contract, service);
			}
		}

		private static IEnumerable<Type> GetServicesContracts(IEnumerable<Type> types)
		{
			foreach (var type in types)
			{
				var interfaces = type.GetInterfaces();
				var contract = interfaces.FirstOrDefault(
					interfaceType => interfaceType.GetCustomAttribute(typeof(ServiceContractAttribute), true) != null);

				if (contract != null)
					yield return contract;
			}
		}

		private static Type GetServicesContract(Type type)
		{
			var interfaces = type.GetInterfaces();
			var contract = interfaces.FirstOrDefault(
				interfaceType => interfaceType.GetCustomAttribute(typeof(ServiceContractAttribute), true) != null);

			if (contract != null)
				return contract;

			return null;
		}

		private static IEnumerable<Type> GetServices(IEnumerable<Type> types)
		{
			return types.Where(type => type.GetCustomAttribute(typeof(ServiceAttribute), true) != null);
		}

		private static Type GetImplementationByContract(IEnumerable<Type> types, Type contract)
		{
			return types.FirstOrDefault(type => type.GetInterface(type.Name) != null);
		}
	}
}
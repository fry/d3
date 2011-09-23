using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.ProtocolBuffers;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace d3.Network {
	public class ServiceRegistry<T> {
		ConcurrentDictionary<uint, Type> services = new ConcurrentDictionary<uint, Type>();

		public void RegisterService(string name, Type implementation) {
			Debug.Assert(implementation.GetInterfaces().Contains(typeof(IService)));

			var hash = Util.GetServiceHash(name);

			Debug.Assert(services.TryAdd(hash, implementation), String.Format("Service already registered: {0}/{1:X8}", name, hash));
		}

		public Type GetServiceType(uint hash) {
			Type service_type;
			if (!services.TryGetValue(hash, out service_type))
				throw new ArgumentException("No such service registered: 0x" + hash.ToString("X8"));
			return service_type;
		}

		public IService CreateBoundService(uint hash, T context) {
			var constructor = GetServiceType(hash).GetConstructor(new Type[] { typeof(T) });

			return constructor.Invoke(new object[] { context }) as IService;
		}

		public IService CreateStub(Type type, T context) {
			var cons = type.GetMethod("CreateStub");
			var stub = cons.Invoke(null, new object[] { context });
			return stub as IService;
		}
	}
}

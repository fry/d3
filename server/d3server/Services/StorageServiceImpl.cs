using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.storage;

namespace d3server.Services {
	public class StorageServiceImpl: StorageService {
		Client client;
		public StorageServiceImpl(Client client) {
			this.client = client;
		}

		public override void Execute(Google.ProtocolBuffers.IRpcController controller, ExecuteRequest request, Action<ExecuteResponse> done) {
			throw new NotImplementedException();
		}

		public override void OpenTable(Google.ProtocolBuffers.IRpcController controller, OpenTableRequest request, Action<OpenTableResponse> done) {
			throw new NotImplementedException();
		}

		public override void OpenColumn(Google.ProtocolBuffers.IRpcController controller, OpenColumnRequest request, Action<OpenColumnResponse> done) {
			throw new NotImplementedException();
		}
	}
}

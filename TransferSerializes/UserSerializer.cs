using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using DrxTransfer;
using DrxTransfer.IntegrationServicesClient;

namespace TransferSerializes
{
    [Export(typeof(SungeroSerializer))]
    public class UserSerializer : SungeroSerializer
    {
        public UserSerializer()
        {
            this.EntityName = "User";
            this.EntityType = "IUsers";
        }
        protected override IEnumerable<dynamic> Export()
        {
            return IntegrationServiceClient.Instance.For<IUsers>()
                .Filter(u => u.Status == "Active")
                .FindEntriesAsync()
                .Result;
        }
    }
}

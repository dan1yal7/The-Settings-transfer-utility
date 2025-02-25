using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using DrxTransfer;
using DrxTransfer.IntegrationServicesClient;

namespace TransferSerializes
{
    [Export(typeof(SungeroSerializer))]
    public class DocumentGroupSerializer : SungeroSerializer
    {
        public DocumentGroupSerializer()
        {
            this.EntityName = "DocumentGroup";
            this.EntityType = "IDocumentGroupBases";
        }
        protected override IEnumerable<dynamic> Export()
        {
            return IntegrationServiceClient.Instance.For<IDocumentGroupBases>()
                .Filter(dg => dg.Status == "Active")
                .FindEntriesAsync().Result;
        }

    }
}

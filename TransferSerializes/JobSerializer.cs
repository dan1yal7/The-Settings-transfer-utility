using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using DrxTransfer;
using DrxTransfer.IntegrationServicesClient;

namespace TransferSerializes
{
    [Export(typeof(SungeroSerializer))]
    public class JobSerializer : SungeroSerializer
    {
        public JobSerializer()
        {
            this.EntityName = "Job";
            this.EntityType = "IJobTitles";
        }

        protected override IEnumerable<dynamic> Export()
        {
            return IntegrationServiceClient.Instance.For<IJobTitles>()
                .Filter(j => j.Status == "Active")
                .Expand(j => j.Name)
                .Expand(j => j.Id)
                .FindEntriesAsync().Result;
        }
    }
}

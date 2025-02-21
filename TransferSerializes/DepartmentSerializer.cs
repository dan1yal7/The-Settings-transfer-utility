using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using DrxTransfer;
using DrxTransfer.IntegrationServicesClient;

namespace TransferSerializes
{
    [Export(typeof(SungeroSerializer))]
    public class DepartmentSerializer : SungeroSerializer
    {
        public DepartmentSerializer()
        {
            this.EntityName = "Department";
            this.EntityType = "IDepartments";
        }
        protected override IEnumerable<dynamic> Export()
        {
            return IntegrationServiceClient.Instance.For<IDepartments>()
                .Filter(d => d.Status == "Active")
                .Expand(d => d.HeadOffice)
                .Expand(d => d.Manager)
                .FindEntriesAsync()
                .Result;
        }
    }
}

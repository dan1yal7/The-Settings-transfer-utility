using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using DrxTransfer;
using DrxTransfer.IntegrationServicesClient;

namespace TransferSerializes
{
    [Export(typeof(SungeroSerializer))]
    public class EmployeeSerializer : SungeroSerializer
    {
        public EmployeeSerializer()
        {
            this.EntityName = "Employee";
            this.EntityType = "IEmployees";
        }
        protected override IEnumerable<dynamic> Export()
        {
            try
            {
                return IntegrationServiceClient.Instance.For<IEmployees>()
                    .Filter(e => e.Status == "Active")
                    .FindEntriesAsync()
                    .Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The problem is {ex}");
            }

            return base.Export();
        }
    }
}

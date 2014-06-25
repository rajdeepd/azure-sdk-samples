using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Subscriptions;
using Microsoft.WindowsAzure.Management.Models;

namespace AzureSDKSample
{
    class SubscriptionSample
    {
        public static void ListOperations()
        {
            ManagementClient client = Util.getManagementClient();

            var utcStart = new DateTime(2014, 04, 01, 0, 0, 0).ToUniversalTime();
            var utcEnd = new DateTime(2014, 06, 01, 0, 0, 0).ToUniversalTime();

            var operations = client.Subscriptions.ListOperations(
                new SubscriptionListOperationsParameters()
                {
                    StartTime = utcStart,
                    EndTime = utcEnd
                });

            foreach (var op in operations.SubscriptionOperations)
            {
                Console.WriteLine(string.Format("Operation name:{0}, Operation id:{1}",
                      op.OperationName, op.OperationId));
            }
            Console.WriteLine("---------------------------------------");
            Console.ReadKey();
        }
    }
}

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
    class HostedServicesSample
    {
        public static void ListHostedServices()
        {
            ComputeManagementClient client = Util.getComputeManagementClient();
            var hostedServices = client.HostedServices.List();
            foreach (var h in hostedServices)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Service Name:" + h.ServiceName);
                Console.WriteLine("Status:" + h.Properties.Status);
                Console.WriteLine("Location:" + h.Properties.Location);
            }
        }

    }
}

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
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Subscriptions;
using Microsoft.WindowsAzure.Management.Models;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace AzureSDKSample
{
    class CloudServicesSample
    {
       public static void CreateCloudService()
        {
            ComputeManagementClient client = Util.getComputeManagementClient();
            HostedServiceCreateParameters param = new HostedServiceCreateParameters();
            param.ServiceName = "rd-TestService";
            param.Location = "East Asia";
            OperationResponse response = client.HostedServices.Create(param);
            Console.WriteLine("Status Code : " + response.StatusCode);
        }

        public static void deleteCloudService()
        {
            String serviceName = "rd-TestService";
            ComputeManagementClient client = Util.getComputeManagementClient();

            OperationResponse response = client.HostedServices.Delete(serviceName);
            Console.WriteLine("Status Code : " + response.StatusCode);
        }

        public static void ListCloudServices()
        {
            ComputeManagementClient client = Util.getComputeManagementClient();
            HostedServiceListResponse response = client.HostedServices.List();
            foreach (var h in response.HostedServices)
            {
                Console.WriteLine(h.ServiceName);
            }
            Console.WriteLine("Status Code : " + response.StatusCode);
        }

    }
}

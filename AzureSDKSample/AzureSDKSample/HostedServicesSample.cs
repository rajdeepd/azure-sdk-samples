using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

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
                HostedServiceGetDetailedResponse response = client.HostedServices.GetDetailed(h.ServiceName);
                IEnumerator<HostedServiceGetDetailedResponse.Deployment> deployments =  response.Deployments.GetEnumerator();
                Console.WriteLine("Deployment Count:" + response.Deployments.Count());
                if(response.Deployments.Count() > 0)
                {
                    Console.WriteLine("Deployment Name:" + response.Deployments.ElementAt(0).Name);
                    var roles = response.Deployments.ElementAt(0).Roles;
                    foreach(var r in roles){
                        Console.WriteLine(r.RoleType);
                    }
                    Console.WriteLine("Roles:" + response.Deployments.ElementAt(0).Roles);
                }
            }
        }

        public static void ListDeploymentDetails()
        {
            ComputeManagementClient client = Util.getComputeManagementClient();
            var hostedServices = client.HostedServices.List();
            foreach (var h in hostedServices)
            {
                HostedServiceGetDetailedResponse response = client.HostedServices.GetDetailed(h.ServiceName);
                IEnumerator<HostedServiceGetDetailedResponse.Deployment> deployments = response.Deployments.GetEnumerator();
                if (response.Deployments.Count() > 0)
                {
                    var deployment =  response.Deployments.ElementAt(0);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Deployment Details:" + deployment.Name);
                    Console.WriteLine("  Name:" + deployment.Name);
                    Console.WriteLine("  Status:" + deployment.Status);
                    Console.WriteLine("  Uri:" + deployment.Uri);
                    Console.WriteLine("  VirtualNetworkName:" + deployment.VirtualNetworkName);
                    Console.WriteLine("  VirtualIPAddresses:" + deployment.VirtualIPAddresses);
                    Console.WriteLine("  UpgradeStatus:" + deployment.UpgradeStatus);
                }
            }
        }
    }
}

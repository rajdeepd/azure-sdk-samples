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
    class VirtualMachinesSample
    {
        public static void ListVMImages()
        {
            ComputeManagementClient client = Util.getComputeManagementClient();
            VirtualMachineVMImageListResponse images = client.VirtualMachineVMImages.List();
            Console.WriteLine("Status Code:" + images.StatusCode);
            if(images.VMImages.Count == 0)
            {
                Console.WriteLine("No images found");
            }
            else
            {
                foreach (var i in images)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Image:" + i.Name);
                }
            }
        }

        public static void ListVMs()
        {
            ComputeManagementClient client = Util.getComputeManagementClient();
            var hostedServices = client.HostedServices.List();
            foreach (var h in hostedServices)
            {
                HostedServiceGetDetailedResponse response = client.HostedServices.GetDetailed(h.ServiceName);
                IEnumerator<HostedServiceGetDetailedResponse.Deployment> deployments = response.Deployments.GetEnumerator();
                if (response.Deployments.Count() > 0)
                {
                    var roles = response.Deployments.ElementAt(0).Roles;
                    foreach (var r in roles)
                    {
                        if(r.RoleType.ToString().Equals("PersistentVMRole"))
                        {
                            Console.WriteLine("VM name:" + h.ServiceName);
                            Console.WriteLine("Status:" + h.Properties.Status);
                            Console.WriteLine("Role Type:" + r.RoleType);
                            Console.WriteLine("Location: " + h.Properties.Location);
                            Console.WriteLine("DateCreated: " + h.Properties.DateCreated);
                            Console.WriteLine("AvailabilitySetName: " + r.AvailabilitySetName);
                            var configSets = r.ConfigurationSets;
                            Console.WriteLine("No of ConfigurationSets: " + configSets.Count);
                            var dataVirtualHardDisks = r.DataVirtualHardDisks;
                            Console.WriteLine("DataVirtualHardDisks Count: " + dataVirtualHardDisks.Count);
                            Console.WriteLine("OSVersion: " + r.OSVersion);
                            Console.WriteLine("RoleSize: " + r.RoleSize);
                            Console.WriteLine("VMImageName: " + r.VMImageName);
                            Console.WriteLine("Uri: " + h.Uri);
                        }
                    }
                }
            }
        }
    }
}

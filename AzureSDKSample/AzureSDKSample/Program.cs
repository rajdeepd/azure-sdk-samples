using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Subscriptions;
using Microsoft.WindowsAzure.Management.Models;
using Microsoft.WindowsAzure.Management.Compute.Models;
using System.Configuration;
using AzureSDKSample;

namespace AzureSDKSample
{
    class Program
    {
        public static String CERT_PATH = @ConfigurationManager.AppSettings["certificatePath"];
        public static String SUBS_ID = ConfigurationManager.AppSettings["subscriptionId"];
        public static void Main(string[] args)
        {
            Program program = new Program();
            if (args.Length > 0)
            {
                int param = int.Parse(args[0]);
                Console.WriteLine("Param:" + param);
                switch (param)
                {
                    case 0:
                        SubscriptionSample.ListOperations();   
                        break;
                    case 1:
                        HostedServicesSample.ListHostedServices();
                        break;
                    case 2:
<<<<<<< HEAD
                        HostedServicesSample.ListDeploymentDetails();
                        break;
                    case 3:
                        CloudServicesSample.CreateCloudService();
                        break;
                    case 4:
                        CloudServicesSample.deleteCloudService();
                        break;
                    case 5:
                        CloudServicesSample.ListCloudServices();
                        break;
                    case 6:
                        VirtualMachinesSample.ListVMImages();
                        break;
                    case 7:
                        VirtualMachinesSample.ListVMs();
=======
                        CloudServicesSample.CreateCloudService();
                        break;
                    case 3:
                        CloudServicesSample.deleteCloudService();
                        break;
                    case 4:
                        CloudServicesSample.ListCloudServices();
>>>>>>> d6c0e9f3b822be453ac86312ba2e242b345b85c8
                        break;
                    default:
                        Console.WriteLine("Invalid value");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please pass command line argument");
            }
            Console.ReadKey();
           
        }
    }
}

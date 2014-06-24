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

namespace AzureManagementApplication
{
    class Program
    {
        public static String CERT_PATH = @ConfigurationManager.AppSettings["certificatePath"];
        public static String SUBS_ID = ConfigurationManager.AppSettings["subscriptionId"];
        static void Main(string[] args)
        {
            Program program = new Program();
            var creds = program.GetCredentials();
            if (args.Length > 0)
            {
                int param = int.Parse(args[0]);
                switch (param)
                {
                    case 0:
                        program.ListOperations(creds);
                        break;
                    case 1:
                        program.ListHostedServices(creds);
                        break;
                    case 2:
                        program.CreateCloudService();
                        break;
                    case 3:
                        program.deleteCloudService();
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

        private ManagementClient getManagementClient()
        {
            var creds = this.GetCredentials(); 
            ManagementClient client = CloudContext.Clients.CreateManagementClient(creds);
            return client;
        }

        private ComputeManagementClient getComputeManagementClient()
        {
            var creds = this.GetCredentials();
            ComputeManagementClient client = CloudContext.Clients.CreateComputeManagementClient(creds);
            return client;
        }

        private void ListHostedServices(CertificateCloudCredentials creds)
        {
            ComputeManagementClient client = CloudContext.Clients.CreateComputeManagementClient(creds);
            var hostedServices = client.HostedServices.List();
            foreach (var h in hostedServices)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Service Name:" + h.ServiceName);
                Console.WriteLine("Status:" + h.Properties.Status);
                Console.WriteLine("Location:" + h.Properties.Location);
            }
        }

        private void CreateCloudService()
        {
            ComputeManagementClient client = this.getComputeManagementClient();
            HostedServiceCreateParameters param = new HostedServiceCreateParameters();
            param.ServiceName = "rd-TestService";
            param.Location = "East Asia";
            OperationResponse response = client.HostedServices.Create(param);
            Console.WriteLine("Status Code : " + response.StatusCode);
        }

        private void deleteCloudService()
        {
            String serviceName = "rd-TestService";
            ComputeManagementClient client = this.getComputeManagementClient();

            OperationResponse response = client.HostedServices.Delete(serviceName);
            Console.WriteLine("Status Code : " + response.StatusCode);
        }

        private void ListOperations(CertificateCloudCredentials creds)
        {
            ManagementClient client = this.getManagementClient();

            var utcStart = new DateTime(2014, 04, 01, 0, 0, 0).ToUniversalTime();
            var utcEnd = new DateTime(2014, 06, 01, 0, 0, 0).ToUniversalTime();

            var operations = client.Subscriptions.ListOperations(
                new SubscriptionListOperationsParameters() { StartTime = utcStart, 
                    EndTime = utcEnd });

            foreach (var op in operations.SubscriptionOperations)
            {
                Console.WriteLine(string.Format("Operation name:{0}, Operation id:{1}",
                      op.OperationName, op.OperationId));
            }
            Console.WriteLine("---------------------------------------");
            Console.ReadKey();
        }
 
        CertificateCloudCredentials GetCredentials()
        {
            //Create a new instance of the X509 certificate
            X509Certificate2 cert = new X509Certificate2(
              Program.CERT_PATH);

            //Pass your subscription id and the certificate to the CertificateCloudCredentials class constructor
            CertificateCloudCredentials creds = new CertificateCloudCredentials(
              Program.SUBS_ID, cert);

            return creds;
        }
    }
}

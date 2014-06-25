using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure;
using System.Security.Cryptography.X509Certificates;

namespace AzureSDKSample
{
    class Util
    {
        public static ManagementClient getManagementClient()
        {
            var creds = GetCredentials();
            ManagementClient client = CloudContext.Clients.CreateManagementClient(creds);
            return client;
        }

        public static ComputeManagementClient getComputeManagementClient()
        {
            var creds = GetCredentials();
            ComputeManagementClient client = CloudContext.Clients.CreateComputeManagementClient(creds);
            return client;
        }


        public static CertificateCloudCredentials GetCredentials()
        {
            //Create a new instance of the X509 certificate
            X509Certificate2 cert = new X509Certificate2(
              Program.CERT_PATH);

            //Pass your subscription id and the certificate to the CertificateCloudCredentials 
            //class constructor
            CertificateCloudCredentials creds = new CertificateCloudCredentials(
              Program.SUBS_ID, cert);

            return creds;
        }
    }
}

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
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace AzureSDKSample
{
    class MobileServiceSample
    {
        static String AppUrl = "https://rd-mobileservice-1.azure-mobile.net/";
        static String AppKey = "";
        
        public async static void GetTable()
        {
            MobileServiceClient client = new MobileServiceClient(
                AppUrl,
                AppKey
            );
            IMobileServiceTable<TodoItem> table = client.GetTable<TodoItem>();
            Console.WriteLine("TableName:" + table.TableName);
            Task<List<TodoItem>> task = table.Where(todoItem => todoItem.Complete == false).ToListAsync();
            List<TodoItem> list = await task;
            foreach(TodoItem item in list)
            {
                Console.WriteLine(item.Text);
            }

        }
    }
    public class TodoItem
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }
}

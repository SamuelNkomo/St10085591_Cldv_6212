using AwehProductionsVaccineStatus;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;

namespace AwehProductionsVaccineStatusSend
{
    class Program
    {
        private static string queueConnectionString = "DefaultEndpointsProtocol=https;AccountName=st10085591;AccountKey=BE6SNaUqPh3dm+bHxZ35rADdzLSiS8EyabQARCQ5txkRfYwSnDjLNd0C+t+/hOm1KPMXnWSAGzTW+AStmU8sVA==;EndpointSuffix=core.windows.net";
        private static string queueName = "vaccinestatusqueue";

        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(queueConnectionString);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference(queueName);

            for (int i = 1; i < 5; i++)
            {
                VaccineInfo vaccineInfo = new VaccineInfo();
                CloudQueueMessage message = new CloudQueueMessage(vaccineInfo.ToString());
                queue.AddMessage(message);
            }

            Console.WriteLine("All messages sent");
            Console.ReadLine();
        }
    }
}

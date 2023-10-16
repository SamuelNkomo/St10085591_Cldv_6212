using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;

namespace AwehProductionsVaccineStatusReceive
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

            queue.FetchAttributes();
            int? messageCount = queue.ApproximateMessageCount;

            for (int i = 0; i < messageCount; i++)
            {
                CloudQueueMessage message = queue.GetMessage();
                Console.WriteLine("Received message: " + message.AsString);
                queue.DeleteMessage(message);
            }
            Console.ReadLine();
        }
    }
}
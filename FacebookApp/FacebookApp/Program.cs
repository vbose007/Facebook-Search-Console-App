using System;
using System.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FacebookApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var accessToken = ConfigurationManager.AppSettings.Get("DefaultAccessToken");
            var client = new FacebookClient();
            var service = new FacebookService(client);

            Console.Write("****************This application searches Facebook using the Graph API for users matching a given name ****************");
            Console.WriteLine("\n\n\n");
            Console.Write("Enter full/partial Facebook user name : ");
            var searchString  = Console.ReadLine();

            var searchTask = service.SearchAsync(accessToken, searchString);

            Task.WaitAll(searchTask);
            var searchResult = searchTask.Result;

            Console.WriteLine("\n*************** Search Result (Json Data)*************** ");
            Console.WriteLine(JsonConvert.SerializeObject(searchResult, Formatting.Indented));

            Console.Read();
        }
    }
}
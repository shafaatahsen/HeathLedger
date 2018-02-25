using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;




namespace WebApplication3
{
    public class Root
    {
        public List<Company> root { get; set; }
    }

    public class Company
    {
        public string companyID { get; set; }
        public HashSet<Asset> assets { get; set; }
    }

    public class Asset
    {
        public String assetID { get; set; }
        public HashSet<String> leasers { get; set; }
    }

  

    public class Program
    {
        public string Function(string name)
        {
            // Code for some functionality   
            string shafaat = "shafaat";
            return shafaat;
        }

        public static void Main(string[] args)
        {
           

            BuildWebHost(args).Run();

            

            Dictionary<String, HashSet<String>> companyIDtoAssets = new Dictionary<String, HashSet<String>>();
            Dictionary<String, HashSet<String>> assetIDtoLeasers = new Dictionary<String, HashSet<String>>();

            Root jsonResponse = JsonConvert.DeserializeObject<Root>("data.json");

            for (int i = 0; i < jsonResponse.root.Count; i++)
            {
                HashSet<String> assets = new HashSet<string>();

                for (int j = 0; j < jsonResponse.root.ElementAt<Company>(i).assets.Count; j++)
                {
                    assetIDtoLeasers.Add(jsonResponse.root.ElementAt<Company>(i).assets.ElementAt<Asset>(j).assetID,
                        jsonResponse.root.ElementAt<Company>(i).assets.ElementAt<Asset>(j).leasers);
                    assets.Add(jsonResponse.root.ElementAt<Company>(i).assets.ElementAt<Asset>(j).assetID);
                }
                companyIDtoAssets.Add(jsonResponse.root.ElementAt<Company>(i).companyID, assets);
            }

            for (int i = 0; i < companyIDtoAssets.Count; i++)
            {
                Console.WriteLine(companyIDtoAssets.ElementAt(i).Key);
                Console.WriteLine(companyIDtoAssets.ElementAt(i).Value);
            }



        }
        public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .Build();

    }
}
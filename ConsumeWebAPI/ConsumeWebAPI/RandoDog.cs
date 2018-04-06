using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ConsumeWebAPI
{
    class RandoDog
    {
        public string Rando()
        {
            string dogFile = "dog.jpg";
            string path = @"C:\Users\Jo\source\repos\ConsumeWebAPI\ConsumeWebAPI\bin\Debug\netcoreapp2.0";

            HttpWebRequest request = WebRequest.CreateHttp("https://dog.ceo/api/breeds/image/random");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();

            JObject o = JObject.Parse(data);

            string save = o["message"].ToString();

            WebClient dogpic = new WebClient();
            dogpic.DownloadFile(save, dogFile);
            Console.WriteLine("You're dog pic was saved as " + dogFile + " in directory ");
            string[] dirs = Directory.GetFiles(path, dogFile);
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);

                //Process.Start(dir+@"\"+dogFile);
            }



            return data;
        }

    }
}

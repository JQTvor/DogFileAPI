using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ConsumeWebAPI
{
    class SearchPic
    {

        public string DogSearchPic()
        {

            string path = @"C:\Users\Jo\source\repos\ConsumeWebAPI\ConsumeWebAPI\bin\Debug\netcoreapp2.0";

            Console.WriteLine("What breed would you like a picture of?");
            string breed = Console.ReadLine().ToLower();
            Console.WriteLine("and of what sub-breed?");
            string subbreed = Console.ReadLine().ToLower();

            HttpWebRequest request = WebRequest.CreateHttp("https://dog.ceo/api/breed/" + breed + "/" + subbreed + "/images/random");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            JObject o = JObject.Parse(data);
            string save = o["message"].ToString();
            string dogFile = "SpecialBreed.jpg";


            string status = o["status"].ToString();


            if (status == "error")
            {
                Console.WriteLine("None Found");
            }

            else
            {
                string[] dirs = Directory.GetFiles(path, dogFile);
                foreach (string dir in dirs)
                {

                    WebClient dogpic = new WebClient();
                    dogpic.DownloadFile(save, dogFile);
                    //Process.Start(dir + @"\" + dogFile);
                }

            }
                return data;
        }
    }
}

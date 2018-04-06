using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ConsumeWebAPI
{
    class Search
    {
        public string DogSearch()
        {

            Console.WriteLine("What sub breeds would you like to see?");
            string search = Console.ReadLine().ToLower();

            HttpWebRequest request = WebRequest.CreateHttp("https://dog.ceo/api/breed/" + search + "/list");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            JObject o = JObject.Parse(data);
            List<JToken> breeds = o["message"].ToList();
            string status = o["status"].ToString();


            if (status == "error")
            {
                Console.WriteLine("None Found");
            }

            else
            {
                foreach (object b in breeds)
                {
                    Console.WriteLine(b);
                }
            }

            return search;
        }
    }
}

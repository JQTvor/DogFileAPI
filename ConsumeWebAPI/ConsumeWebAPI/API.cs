using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ConsumeWebAPI
{
    class API
    {
        public string DogAPI()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://dog.ceo/api/breeds/list/all");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            JObject o = JObject.Parse(data);
            List<JToken> breeds = o["message"].ToList();


            foreach(object i in breeds)
            {
                Console.WriteLine(i);
            }


            return data;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace VierticaXmasGame.HttpHelpers
{
    public static class AzureHttpCaller<Y>
    {
        public static Y MakeAzureCall(object message, string endPoint)
        {
            using (var client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(message);
                string url = ConfigurationManager.AppSettings["AzureUrl"];
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync($@"{url}{endPoint}", data).Result;

                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                return JsonConvert.DeserializeObject<Y>(result);
            }
        }
    }
}

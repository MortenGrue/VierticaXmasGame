using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace VierticaXmasGame.Task2
{
    public class SendRescue
    {
        public Models.RescueResponseModel.RootObject rescueResponse;

        public void MakeHttpCall(Models.Credentials.RootObject creds, PosisionCalculator posisionCalculator)
        {
            using (var client = new HttpClient())
            {
                Models.SendRescue.RootObject sendRescueModel = new Models.SendRescue.RootObject
                {
                    id = creds.Id,
                    position = new Models.SendRescue.Position
                    {
                        lat = posisionCalculator.lat,
                        lon = posisionCalculator.lon
                    }
                };

                string json = JsonConvert.SerializeObject(sendRescueModel);

                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(@"https://vertica-xmas2019.azurewebsites.net/api/santarescue", data).Result;

                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);

                rescueResponse = JsonConvert.DeserializeObject<Models.RescueResponseModel.RootObject>(result);                
            }

        }
    }
}

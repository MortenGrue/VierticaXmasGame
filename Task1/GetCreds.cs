using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using VierticaXmasGame.Models;

namespace VierticaXmasGame.Task1
{
    public class GetCreds
    {
        public Models.Credentials.RootObject creds;

        public GetCreds()
        {
            MakeHttpCall();
        }

        public void MakeHttpCall()
        {
            using (var client = new HttpClient())
            {
                CreateAccount account = new CreateAccount();
                string json = JsonConvert.SerializeObject(account);

                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(@"https://vertica-xmas2019.azurewebsites.net/api/participate", data).Result;

                string result = response.Content.ReadAsStringAsync().Result;

                creds = JsonConvert.DeserializeObject<Models.Credentials.RootObject>(result);

                Console.WriteLine(result);
            }
        }
    }
}

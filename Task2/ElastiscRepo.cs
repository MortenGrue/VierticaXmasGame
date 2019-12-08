using Elasticsearch.Net;
using Nest;
using System.Configuration;

namespace VierticaXmasGame.Task2
{
    public class ElastiscRepo
    {
        public static Models.SantaLoc.Source Connect(Models.Credentials.RootObject creds)
        {
            string cloudeId = ConfigurationManager.AppSettings["ElasticCloudeId"];
            using (BasicAuthenticationCredentials auth = new BasicAuthenticationCredentials(creds.Credentials.Username, creds.Credentials.Password))
            using (ConnectionSettings connectionSettings = new ConnectionSettings(cloudeId, auth))
            {
                connectionSettings.DefaultIndex("santa-trackings");
                
                ElasticClient client = new ElasticClient(connectionSettings);
                GetResponse<Models.SantaLoc.Source> res = client.Get<Models.SantaLoc.Source>(creds.Id);

                return res.Source;
            }
        }
    }
}

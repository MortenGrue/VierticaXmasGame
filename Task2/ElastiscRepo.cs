using Elasticsearch.Net;
using Nest;

namespace VierticaXmasGame.Task2
{
    public class ElastiscRepo
    {
        public static Models.SantaLoc.Source Connect(Models.Credentials.RootObject creds)
        {
            using (ConnectionSettings connectionSettings = new ConnectionSettings("xmas2019:ZXUtY2VudHJhbC0xLmF3cy5jbG91ZC5lcy5pbyRlZWJjNmYyNzcxM2Q0NTE5OTcwZDc1Yzg2MDUwZTM2MyQyNDFmMzQ3OWNkNzg0ZTUyOTRkODk5OTViMjg0MjAyYg=="
                                                                                , new BasicAuthenticationCredentials(creds.Credentials.Username, creds.Credentials.Password))
                                                            .DefaultIndex("santa-trackings"))
            {

                ElasticClient client = new ElasticClient(connectionSettings);
                GetResponse<Models.SantaLoc.Source> res = client.Get<Models.SantaLoc.Source>(creds.Id);

                return res.Source;
            }
        }
    }
}

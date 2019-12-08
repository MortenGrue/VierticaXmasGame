using VierticaXmasGame.HttpHelpers;
using VierticaXmasGame.Models;

namespace VierticaXmasGame.Task1
{
    public class GetCreds
    {
        public Models.Credentials.RootObject creds;

        public GetCreds()
        {
            creds = AzureHttpCaller<Models.Credentials.RootObject>.MakeAzureCall(new CreateAccount(), "api/participate");
        }        
    }
}

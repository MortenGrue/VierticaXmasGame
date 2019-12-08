using VierticaXmasGame.HttpHelpers;

namespace VierticaXmasGame.Task2
{
    public class SendRescue
    {
        public Models.RescueResponseModel.RootObject rescueResponse;

        public void MakeHttpCall(Models.Credentials.RootObject creds, PosisionCalculator posisionCalculator)
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

            rescueResponse = AzureHttpCaller<Models.RescueResponseModel.RootObject>.MakeAzureCall(sendRescueModel, "api/santarescue"); 
        }
    }
}

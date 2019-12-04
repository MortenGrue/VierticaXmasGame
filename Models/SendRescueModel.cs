namespace VierticaXmasGame.Models.SendRescue
{
    public class Position
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class RootObject
    {
        public string id { get; set; }
        public Position position { get; set; }
    }
}

using System.Collections.Generic;

namespace VierticaXmasGame.Models.RescueResponseModel
{
    public class Center
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class Radius
    {
        public string unit { get; set; }
        public double value { get; set; }
    }

    public class Zone
    {
        public string reindeer { get; set; }
        public string countryCode { get; set; }
        public string cityName { get; set; }
        public Center center { get; set; }
        public Radius radius { get; set; }
    }

    public class RootObject
    {
        public List<Zone> zones { get; set; }
        public string token { get; set; }
    }
}

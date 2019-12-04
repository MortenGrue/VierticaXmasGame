using System.Collections.Generic;

namespace VierticaXmasGame.Models.SantaLoc
{
    public class CanePosition
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class SantaMovement
    {
        public string direction { get; set; }
        public double value { get; set; }
        public string unit { get; set; }
    }

    public class Source
    {
        public string id { get; set; }
        public CanePosition canePosition { get; set; }
        public List<SantaMovement> santaMovements { get; set; }
    }

    public class RootObject
    {
        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set; }
        public int _version { get; set; }
        public int _seq_no { get; set; }
        public int _primary_term { get; set; }
        public bool found { get; set; }
        public Source _source { get; set; }
    }
}

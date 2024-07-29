namespace OnTheBeach.Models
{
    public class Hotel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string arrival_date { get; set; }
        public uint price { get; set; }
        public string[] local_airports { get; set; }
        public int nights { get; set; }
    }

    public class RootHotels
    {
        public List<Hotel> hotels { get; set; }
    }

}

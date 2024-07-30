namespace OnTheBeach.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Arrival_Date { get; set; }
        public uint Price { get; set; }
        public string[] Local_Airports { get; set; }
        public int Nights { get; set; }
    }

    public class RootHotels
    {
        public List<Hotel> Hotels { get; set; }
    }

}

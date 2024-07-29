using System.Numerics;

namespace OnTheBeach.Models
{
    public class Flight
    {
        public int id { get; set; }
        public string airline { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public uint price { get; set; }
        public string departure_date { get; set; }
    }

    public class RootFlights
    {
        public List<Flight> flights { get; set; }
    }
}

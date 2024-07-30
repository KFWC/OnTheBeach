using System.Numerics;

namespace OnTheBeach.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Airline { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public uint Price { get; set; }
        public string Departure_Date { get; set; }
    }

    public class RootFlights
    {
        public List<Flight> Flights { get; set; }
    }
}

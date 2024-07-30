using OnTheBeach.Models;
using Newtonsoft.Json;

namespace OnTheBeach
{
    public class Flights
    {
        public List<Flight> FlightList { get; set; }

        public Flights()
        {
            FlightList = new List<Flight>();
            FlightList = LoadData();
        }

        public List<Flight> LoadData()
        {
            using StreamReader reader = new StreamReader("../../../Data/Flights.json");

            string json = reader.ReadToEnd();

            RootFlights? data = JsonConvert.DeserializeObject<RootFlights>(json);

            if (data != null)
            {
                FlightList = data.Flights;
            }
            return FlightList;
        }

        public List<Flight> Search(string[] from, string to, DateTime departureDate)
        {
            string departure = string.Format("{0}-{1}-{2}", departureDate.Year.ToString("d4"), departureDate.Month.ToString("d2"), departureDate.Day.ToString("d2"));

            List<Flight> suitableFlights = new List<Flight>();

            foreach (var flight in FlightList)
            {
                if (from.Contains(flight.From) && flight.To == to && flight.Departure_Date == departure)
                {
                    suitableFlights.Add(flight);
                }
            }

            return suitableFlights.OrderBy(o => o.Price).ToList();
        }

        public List<Flight> Search(string to, DateTime departureDate)
        {
            string departure = string.Format("{0}-{1}-{2}", departureDate.Year.ToString("d4"), departureDate.Month.ToString("d2"), departureDate.Day.ToString("d2"));

            List<Flight> suitableFlights = new List<Flight>();

            foreach (var flight in FlightList)
            {
                if (flight.To == to && flight.Departure_Date == departure)
                {
                    suitableFlights.Add(flight);
                }
            }

            return suitableFlights.OrderBy(o => o.Price).ToList();
        }
    }
}

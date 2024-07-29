using OnTheBeach.Models;
using Newtonsoft.Json;

namespace OnTheBeach
{
    public class Flights
    {
        public List<Flight> FlightList { get; set; } = [];

        public List<Flight> LoadData(string jsonData)
        {
            RootFlights? data = JsonConvert.DeserializeObject<RootFlights>(jsonData);

            if (data != null)
            {
                FlightList = data.flights;
            }
            return FlightList;
        }

        public List<Flight> LoadData()
        {
            using (StreamReader reader = new StreamReader("../../../Data/Flights.json"))
            {
                string json = reader.ReadToEnd();

                RootFlights? data  = JsonConvert.DeserializeObject<RootFlights>(json);

                if (data != null)
                {
                    FlightList = data.flights;
                }
                return FlightList;
            }
        }
    }
}

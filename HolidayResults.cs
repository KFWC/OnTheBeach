
using System.ComponentModel;
using OnTheBeach.Models;

namespace OnTheBeach
{
    public class HolidayResults
    {
        public Flights Flights { get; set; } = new();
        public Hotels Hotels { get; set; } = new();

        public List<Flight> LoadFlightData(string jsonData)
        {
            List<Flight> flights = Flights.LoadData(jsonData);

            return flights;
        }

        public List<Flight> LoadFlightData()
        { 
            List<Flight> flights = Flights.LoadData();

            return flights;
        }
        public List<Hotel> LoadHotelData(string jsonData)
        {
            List<Hotel> hotels = Hotels.LoadData(jsonData);

            return hotels;
        }

        public List<Hotel> LoadHotelData()
        {
            List<Hotel> hotels = Hotels.LoadData();

            return hotels;
        }
    }
}

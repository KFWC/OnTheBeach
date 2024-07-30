
using System.ComponentModel;
using OnTheBeach.Models;

namespace OnTheBeach
{
    public class HolidayResults
    {
        public Flights Flights { get; set; } = new();
        public Hotels Hotels { get; set; } = new();

        public List<Flight> LoadFlightData()
        {
            List<Flight> flights = Flights.LoadData();

            return flights;
        }

        public List<Hotel> LoadHotelData()
        {
            List<Hotel> hotels = Hotels.LoadData();

            return hotels;
        }

        public Holiday FindHoliday(string[] from, string to, DateTime departureDate, int duration)
        {
            List<Flight> flights = FindFlights(from, to, departureDate);
            uint totalPrice = 0;

            Flight? flight = flights.FirstOrDefault();
            if (flight != null)
            {
                totalPrice += flight.Price;
            }

            List<Hotel> hotels = FindHotels(to, departureDate, duration);

            Hotel? hotel = hotels.FirstOrDefault();
            if (hotel != null)
            {
                totalPrice += ((uint)(hotel.Price * hotel.Nights));
            }

            Holiday holiday = new()
            {
                Flight = flight,
                Hotel = hotel,
                Price = totalPrice
            };
            return holiday;
        }

        private List<Flight> FindFlights(string[] from, string to, DateTime departure)
        {
            return (from[0] == "") ? Flights.Search(to, departure) : Flights.Search(from, to, departure);
        }

        private List<Hotel> FindHotels(string airport, DateTime arrivalDate, int duration)
        {
            return Hotels.Search(airport, arrivalDate, duration);
        }
    }
}

using OnTheBeach.Models;
using Newtonsoft.Json;

namespace OnTheBeach
{
    public class Hotels
    {
        public List<Hotel> HotelList { get; set; }

        public Hotels()
        {
            HotelList = new List<Hotel>();
            HotelList = LoadData();
        }

        public List<Hotel> LoadData(string jsonData)
        {
            RootHotels? data = JsonConvert.DeserializeObject<RootHotels>(jsonData);

            if (data != null)
            {
                HotelList = data.hotels;
            }
            return HotelList;
        }

        public List<Hotel> LoadData()
        {
            using (StreamReader reader = new StreamReader("../../../Data/Hotels.json"))
            {
                string json = reader.ReadToEnd();

                RootHotels? data = JsonConvert.DeserializeObject<RootHotels>(json);

                if (data != null)
                {
                    HotelList = data.hotels;
                }
                return HotelList;
            }
        }

        public List<Hotel> Search(string airport, DateTime arrivalDate, int duration)
        {
            string arrival = string.Format("{0}-{1}-{2}", arrivalDate.Year.ToString("d4"), arrivalDate.Month.ToString("d2"), arrivalDate.Day.ToString("d2"));

            List<Hotel> suitableHotels = new List<Hotel>();

            foreach (var hotel in HotelList)
            {
                if (hotel.local_airports.Contains(airport) && hotel.arrival_date == arrival && hotel.nights == duration)
                {
                    suitableHotels.Add(hotel);
                }
            }

            return suitableHotels.OrderBy(o => o.price).ToList();
        }
    }
}
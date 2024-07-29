using OnTheBeach.Models;
using Newtonsoft.Json;

namespace OnTheBeach
{
    public class Hotels
    {
        public List<Hotel> HotelList { get; set; } = [];

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
    }
}
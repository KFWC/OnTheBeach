using NUnit.Framework;

namespace OnTheBeach.Tests
{
    [TestFixture]
    public class HolidayResultsTests
    {
        private HolidayResults holidayResults;

        [OneTimeSetUp]
        public void Setup()
        {
            holidayResults = new HolidayResults();
        }

        [Test]
        public void FlightLoadData_EmptyJson_ShouldReturnNull()
        {
            var result = holidayResults.LoadFlightData("");

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FlightLoadData_WithValidJson_ShouldReturnListFlights()
        {
            var result = holidayResults.LoadFlightData();

            var first = result.FirstOrDefault();
            var last = result.LastOrDefault();

            Assert.That(result, Is.Not.Null);
            Assert.That(first.id, Is.EqualTo(1));
            Assert.That(last.id, Is.EqualTo(12));
        }
        [Test]
        public void HotelLoadData_EmptyJson_ShouldReturnNull()
        {
            var result = holidayResults.LoadHotelData("");

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void HotelLoadData_WithValidJson_ShouldReturnListHotels()
        {
            var result = holidayResults.LoadHotelData();

            var first = result.FirstOrDefault();
            var last = result.LastOrDefault();

            Assert.That(result, Is.Not.Null);
            Assert.That(first.id, Is.EqualTo(1));
            Assert.That(last.id, Is.EqualTo(13));
        }

        [Test]
        public void CustomerOne_ShouldReturnFlightTwoAndHotelNine()
        {
            DateTime departure = new DateTime(2023, 7, 1);

            var flight = holidayResults.FindFlights(["MAN"], "AGP", departure).FirstOrDefault();
            var hotel = holidayResults.FindHotels("AGP", departure, 7).FirstOrDefault();

            Assert.That(flight, Is.Not.Null);
            Assert.That(flight.id, Is.EqualTo(2));
            Assert.That(hotel, Is.Not.Null);
            Assert.That(hotel.id, Is.EqualTo(9));
        }

        [Test]
        public void CustomerTwo_ShouldReturnFlightSixAndHotelFive()
        {
            DateTime departure = new DateTime(2023, 6, 15);

            var flight = holidayResults.FindFlights(["LCY", "LGW", "LHR", "LTN", "STN", "SEN"], "PMI", departure).FirstOrDefault();
            var hotel = holidayResults.FindHotels("PMI", departure, 10).FirstOrDefault();

            Assert.That(flight, Is.Not.Null);
            Assert.That(flight.id, Is.EqualTo(6));
            Assert.That(hotel, Is.Not.Null);
            Assert.That(hotel.id, Is.EqualTo(5));
        }
        [Test]
        public void CustomerThree_ShouldReturnFlightSevenAndHotelSix()
        {
            DateTime departure = new DateTime(2022, 11, 10);

            var flight = holidayResults.FindFlights([""], "LPA", departure).FirstOrDefault();
            var hotel = holidayResults.FindHotels("LPA", departure, 14).FirstOrDefault();

            Assert.That(flight, Is.Not.Null);
            Assert.That(flight.id, Is.EqualTo(7));
            Assert.That(hotel, Is.Not.Null);
            Assert.That(hotel.id, Is.EqualTo(6));
        }
    }
}

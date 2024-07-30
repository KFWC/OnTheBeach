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
        public void FlightLoadData_WithValidJson_ShouldReturnListFlights()
        {
            var result = holidayResults.LoadFlightData();

            var first = result.FirstOrDefault();
            var last = result.LastOrDefault();

            Assert.That(result, Is.Not.Null);
            Assert.That(first.Id, Is.EqualTo(1));
            Assert.That(last.Id, Is.EqualTo(12));
        }

        [Test]
        public void HotelLoadData_WithValidJson_ShouldReturnListHotels()
        {
            var result = holidayResults.LoadHotelData();

            var first = result.FirstOrDefault();
            var last = result.LastOrDefault();

            Assert.That(result, Is.Not.Null);
            Assert.That(first.Id, Is.EqualTo(1));
            Assert.That(last.Id, Is.EqualTo(13));
        }

        [Test]
        public void CustomerOne_ShouldReturnFlightTwoAndHotelNine()
        {
            DateTime departure = new DateTime(2023, 7, 1);

            var holiday = holidayResults.FindHoliday(["MAN"], "AGP", departure, 7);

            Assert.That(holiday, Is.Not.Null);
            Assert.That(holiday.Flight, Is.Not.Null);
            Assert.That(holiday.Flight.Id, Is.EqualTo(2));
            Assert.That(holiday.Hotel, Is.Not.Null);
            Assert.That(holiday.Hotel.Id, Is.EqualTo(9));
            Assert.That(holiday.Price, Is.EqualTo(328));
        }

        [Test]
        public void CustomerTwo_ShouldReturnFlightSixAndHotelFive()
        {
            DateTime departure = new DateTime(2023, 6, 15);

            var holiday = holidayResults.FindHoliday(["LCY", "LGW", "LHR", "LTN", "STN", "SEN"], "PMI", departure, 10);

            Assert.That(holiday, Is.Not.Null);
            Assert.That(holiday.Flight, Is.Not.Null);
            Assert.That(holiday.Flight.Id, Is.EqualTo(6));
            Assert.That(holiday.Hotel, Is.Not.Null);
            Assert.That(holiday.Hotel.Id, Is.EqualTo(5));
            Assert.That(holiday.Price, Is.EqualTo(135));

        }
        [Test]
        public void CustomerThree_ShouldReturnFlightSevenAndHotelSix()
        {
            DateTime departure = new DateTime(2022, 11, 10);

            var holiday = holidayResults.FindHoliday([""], "LPA", departure, 14);

            Assert.That(holiday, Is.Not.Null);
            Assert.That(holiday.Flight, Is.Not.Null);
            Assert.That(holiday.Flight.Id, Is.EqualTo(7));
            Assert.That(holiday.Hotel, Is.Not.Null);
            Assert.That(holiday.Hotel.Id, Is.EqualTo(6));
            Assert.That(holiday.Price, Is.EqualTo(200));

        }
    }
}

using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime FlightStartDate = new DateTime(2012, 12, 30);
        private DateTime FlightEndDate = new DateTime(2012, 12, 31);
        private readonly int miles = 500;
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(FlightStartDate, FlightEndDate, miles);
            Assert.IsNotNull(target);
        }
        [Test()]
        public void TestThatFlightHasCorrectPriceForOneDayFlight()
        {
            FlightEndDate = new DateTime(2012, 12, 31);
            var target = new Flight(FlightStartDate, FlightEndDate, miles);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectPriceForTwoDayFlight()
        {
            FlightEndDate = new DateTime(2013, 1, 1);
            var target = new Flight(FlightStartDate, FlightEndDate, miles);
            Assert.AreEqual(240, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDayFlight()
        {
            FlightEndDate = new DateTime(2013, 1, 9);
            var target = new Flight(FlightStartDate, FlightEndDate, miles);
            Assert.AreEqual(400, target.getBasePrice());
        }
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadDates()
        {
            new Flight(FlightStartDate, FlightEndDate, -300);
        }
        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadLength()
        {
            new Flight(FlightEndDate, FlightStartDate, miles);
        }

        [Test()]
        public void TestThatEqualsWorks()
        {
           Flight f= new Flight(FlightStartDate, FlightEndDate, miles);
           Flight f2 = new Flight(FlightStartDate, FlightEndDate, miles);
           Assert.True(f.Equals(f2));
        }
	}
}

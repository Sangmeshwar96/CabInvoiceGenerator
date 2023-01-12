using NUnit.Framework;
using CabInvoiceGenerator;
namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void GivenArrayOfRides_ShouldReturn()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }
        [Test]
        public void GivenUserIdWith5Rides_ShouldReturnTotalFare()
        {
            Ride[] rides =
            {
                new Ride(1.0, 1),
                new Ride(2.0, 2),
                new Ride(2.0, 2),
                new Ride(4.0, 4),
                new Ride(3.0, 3)
            };
            double expected = 132;
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(expected, summary.totalFare);
        }
        [Test]
        public void GivenUserIdWith5Rides_ShouldReturnEnhancedInvoiceSummary()
        {
            Ride[] rides =
            {
                new Ride(1.0, 1),
                new Ride(2.0, 2),
                new Ride(2.0, 2),
                new Ride(4.0, 4),
                new Ride(3.0, 3)
            };
            InvoiceSummary expected = new InvoiceSummary(5, 132);
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(summary, expected);
        }
        [Test]
        public void GivenUserId_ShouldReturnListOfRides()
        {
            Ride[] rides =
            {
                new Ride(1.0, 1),
                new Ride(2.0, 2),
                new Ride(2.0, 2),
                new Ride(4.0, 4),
                new Ride(3.0, 3)
            };
            string userId = "123";
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            invoiceGenerator.AddRides(userId, rides);
            Ride[] actual = invoiceGenerator.rideRepository.GetRides(userId);
            Assert.AreEqual(rides, actual);
        }
    }
}
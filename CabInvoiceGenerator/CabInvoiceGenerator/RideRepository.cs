using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        /// Dictionary to Store UserId and Rides int List.
        Dictionary<string, List<Ride>> userRides = null;
        /// Constructor to Create Dictionary.
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        /// Function to Add Ride List to Specified UserId.
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
                else
                {
                    this.userRides[userId] = rides.ToList();
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides Are Null");
            }
        }
        /// Function To Get Rides List As an Array for specified UserId. 
        public Ride[] GetRides(string userId)
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (Exception)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid UserID");
            }
        }
    }
}
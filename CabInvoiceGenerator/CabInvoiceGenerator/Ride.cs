using System;
using System.Collections.Generic;
using System.Text;
namespace CabInvoiceGenerator
{
    public class Ride
    {
        //Variables.
        public double distance;
        public int time;
        /// Parameter Constructor For Setting Data.
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
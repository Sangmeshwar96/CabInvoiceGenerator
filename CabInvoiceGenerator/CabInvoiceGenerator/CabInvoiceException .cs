using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class CabInvoiceException : Exception
    {
        /// Enum For Exception type.
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_USER_ID
        }
        ExceptionType type;
        /// Parameter Constructor For Setting Exception type And Throwing Exception.
        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }

}
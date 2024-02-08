using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class Payment
    {
        public int PId { get; set; }
        public int? Amount { get; set; }
        public DateTime? Date { get; set; }
        public int? PaId { get; set; }

        public virtual Passenger? Pa { get; set; }
    }
}

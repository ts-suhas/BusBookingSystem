using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class PassengerNonMember
    {
        public PassengerNonMember()
        {
            PassengerTickets = new HashSet<PassengerTicket>();
        }

        public int Nmid { get; set; }

        public virtual Passenger Nm { get; set; } = null!;
        public virtual ICollection<PassengerTicket> PassengerTickets { get; set; }
    }
}

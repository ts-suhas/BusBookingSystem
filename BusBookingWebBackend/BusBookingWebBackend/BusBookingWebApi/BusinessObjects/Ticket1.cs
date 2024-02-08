using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class Ticket1
    {
        public Ticket1()
        {
            PassengerTickets = new HashSet<PassengerTicket>();
        }

        public int TId { get; set; }
        public int Amount { get; set; }
        public int RId { get; set; }

        public virtual Route RIdNavigation { get; set; } = null!;
        public virtual ICollection<PassengerTicket> PassengerTickets { get; set; }
    }
}

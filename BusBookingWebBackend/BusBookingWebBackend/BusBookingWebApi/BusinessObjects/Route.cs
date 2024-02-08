using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class Route
    {
        public Route()
        {
            BusRoutes = new HashSet<BusRoute>();
            Ticket1s = new HashSet<Ticket1>();
            Tickets = new HashSet<Ticket>();
        }

        public int RId { get; set; }
        public string? Location { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<BusRoute> BusRoutes { get; set; }
        public virtual ICollection<Ticket1> Ticket1s { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}

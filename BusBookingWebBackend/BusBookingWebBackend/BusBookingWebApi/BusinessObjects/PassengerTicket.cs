using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class PassengerTicket
    {
        public int PtId { get; set; }
        public int PnId { get; set; }
        public int TId { get; set; }

        public virtual PassengerNonMember Pn { get; set; } = null!;
        public virtual Ticket1 TIdNavigation { get; set; } = null!;
    }
}

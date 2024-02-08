using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class PassengerMember
    {
        public int MId { get; set; }
        public DateTime? ExpDate { get; set; }
        public int? Cid { get; set; }

        public virtual Card? CidNavigation { get; set; }
        public virtual Passenger MIdNavigation { get; set; } = null!;
    }
}

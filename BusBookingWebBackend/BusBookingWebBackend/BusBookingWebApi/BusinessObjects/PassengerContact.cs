using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class PassengerContact
    {
        public int PaId { get; set; }
        public int? Contacts { get; set; }

        public virtual Passenger Pa { get; set; } = null!;
    }
}

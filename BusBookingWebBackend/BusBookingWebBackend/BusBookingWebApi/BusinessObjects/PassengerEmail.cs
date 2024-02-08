using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class PassengerEmail
    {
        public int PaId { get; set; }
        public string? Emails { get; set; }

        public virtual Passenger Pa { get; set; } = null!;
    }
    public partial class PassengerEmailDTO
    {
        public string? Emails { get; set; }

    }
}

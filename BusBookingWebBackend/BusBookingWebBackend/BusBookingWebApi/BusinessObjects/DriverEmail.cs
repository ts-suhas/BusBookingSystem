using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class DriverEmail
    {
        public int DId { get; set; }
        public string? Emails { get; set; }

        public virtual Driver DIdNavigation { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class DriverContact
    {
        public int DId { get; set; }
        public int? Contacts { get; set; }

        public virtual Driver DIdNavigation { get; set; } = null!;
    }
}

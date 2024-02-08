using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class DriverPartTime
    {
        public int Pid { get; set; }
        public int? NumHours { get; set; }
        public int? Rate { get; set; }

        public virtual Driver PidNavigation { get; set; } = null!;
    }
}

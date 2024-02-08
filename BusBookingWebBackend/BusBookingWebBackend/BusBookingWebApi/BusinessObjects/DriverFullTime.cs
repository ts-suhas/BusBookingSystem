using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class DriverFullTime
    {
        public int Fid { get; set; }
        public int? Salary { get; set; }
        public int? Bonus { get; set; }

        public virtual Driver FidNavigation { get; set; } = null!;
    }
}

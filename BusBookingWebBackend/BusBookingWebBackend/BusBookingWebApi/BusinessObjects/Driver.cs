using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class Driver
    {
        public Driver()
        {
            Lisences = new HashSet<Lisence>();
            BIds = new HashSet<Bu>();
        }

        public int DId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public virtual DriverContact DriverContact { get; set; } = null!;
        public virtual DriverEmail DriverEmail { get; set; } = null!;
        public virtual DriverFullTime DriverFullTime { get; set; } = null!;
        public virtual DriverPartTime DriverPartTime { get; set; } = null!;
        public virtual ICollection<Lisence> Lisences { get; set; }

        public virtual ICollection<Bu> BIds { get; set; }
    }
}

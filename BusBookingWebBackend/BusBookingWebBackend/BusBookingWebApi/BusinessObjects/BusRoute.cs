using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class BusRoute
    {
        public int BrId { get; set; }
        public int RId { get; set; }
        public int BId { get; set; }

        public virtual Bu BIdNavigation { get; set; } = null!;
        public virtual Route RIdNavigation { get; set; } = null!;
    }
}

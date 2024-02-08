using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class Fuel
    {
        public int FId { get; set; }
        public int? Liter { get; set; }
        public int? BId { get; set; }

        public virtual Bu? BIdNavigation { get; set; }
    }
}

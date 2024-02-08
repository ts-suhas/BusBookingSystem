using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class Lisence
    {
        public int LId { get; set; }
        public string? LType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? DId { get; set; }

        public virtual Driver? DIdNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class Bu
    {
        public Bu()
        {
            BusRoutes = new HashSet<BusRoute>();
            Fuels = new HashSet<Fuel>();
            DIds = new HashSet<Driver>();
        }

        public int BId { get; set; }
        public string? NoPlate { get; set; }
        public string? Color { get; set; }
        public string? Type { get; set; }

        public virtual ICollection<BusRoute> BusRoutes { get; set; }
        public virtual ICollection<Fuel> Fuels { get; set; }

        public virtual ICollection<Driver> DIds { get; set; }
    }

    public partial class BuDTO
    {

        public int BId { get; set; }
        public string? NoPlate { get; set; }
        public string? Color { get; set; }
        public string? Type { get; set; }
        public ICollection<Ticket>? Ticket { get; set; }
        public virtual ICollection<BusRoute>? BusRoutes { get; set; }
    }
}

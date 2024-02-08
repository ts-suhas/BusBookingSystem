using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class FuelChecker
    {
        public int BId { get; set; }
        public string? NoPlate { get; set; }
        public int? Liter { get; set; }
    }
}

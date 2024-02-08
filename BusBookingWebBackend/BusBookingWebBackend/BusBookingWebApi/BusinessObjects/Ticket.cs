using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class Ticket
    {
        public int Tid { get; set; }
        public int? TNum { get; set; }
        public DateTime? Date { get; set; }
        public int? Amount { get; set; }
        public int? RId { get; set; }
        public int? PId { get; set; }

        public virtual Passenger? PIdNavigation { get; set; }
        public virtual Route? RIdNavigation { get; set; }
    }

    public partial class TicketDTO
    {
        public int Tid { get; set; }
        public int? TNum { get; set; }
        public DateTime? Date { get; set; }
        public int? Amount { get; set; }
        public int? RId { get; set; }
        public int? PId { get; set; }
    }
    public partial class TicketResponseDTO
    {
        public int Tid { get; set; }
        public int? TNum { get; set; }
        public DateTime? Date { get; set; }
        public int? Amount { get; set; }
        public string Location { get; set; }
        public int? RId { get; set; }
        public int? PId { get; set; }
    }
}

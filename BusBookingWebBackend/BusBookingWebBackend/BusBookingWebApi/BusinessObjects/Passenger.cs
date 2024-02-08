using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class Passenger
    {
        public Passenger()
        {
            Payments = new HashSet<Payment>();
            Tickets = new HashSet<Ticket>();
        }

        public int PaId { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Password { get; set; }

        public virtual PassengerContact PassengerContact { get; set; } = null!;
        public virtual PassengerEmail PassengerEmail { get; set; } = null!;
        public virtual PassengerMember PassengerMember { get; set; } = null!;
        public virtual PassengerNonMember PassengerNonMember { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }


    public partial class PassengerDTO
    {

        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Password { get; set; }
        public bool IsMember { get; set; }
        public int cId { get; set; }
        public PassengerEmailDTO PassengerEmail { get; set; } = null!;

    }
}

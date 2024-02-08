using System;
using System.Collections.Generic;

namespace BusBookingWebApi.BusinessObjects
{
    public partial class Card
    {
        public Card()
        {
            PassengerMembers = new HashSet<PassengerMember>();
        }

        public int Cid { get; set; }
        public string? Type { get; set; }
        public int? Amount { get; set; }

        public virtual ICollection<PassengerMember> PassengerMembers { get; set; }
    }
}

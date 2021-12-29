using System;
using System.Collections.Generic;

namespace Hotel_Astitou_Backend.Model
{
    public partial class Booking
    {
        public int Id { get; set; }
        public DateTime DateOfArrival { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public int LodgerId { get; set; }
        public int ApartmentId { get; set; }

    }
}

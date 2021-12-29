using System;
using System.Collections.Generic;

namespace Hotel_Astitou_Backend.Model
{
    public partial class Apartment
    {
        public Apartment()
        {
            Booking = new HashSet<Booking>();
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Adress { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int RoomNumber { get; set; }
        public int TotalArea { get; set; }
        public int BedroomArea { get; set; }
        public int DiningArea { get; set; }
        public decimal RentPrice { get; set; }

        public IEnumerable<Booking> Booking { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
    }
}

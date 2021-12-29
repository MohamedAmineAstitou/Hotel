using System;
using System.Collections.Generic;

namespace Hotel_Astitou_Backend.Model
{
    public partial class Room
    {
        public int Id { get; set; }
        public int Surface { get; set; }
        public int Idapartment { get; set; }
        public int ApartementId { get; set; }

        public  Apartment Apartement { get; set; }
    }
}

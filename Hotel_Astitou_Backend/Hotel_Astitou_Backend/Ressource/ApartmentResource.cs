using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Ressource
{
    public class ApartmentResource
    {
        public int id { get; set; }
        public string Adress { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int RoomNumber { get; set; }
        public int TotalArea { get; set; }
        public int BedroomArea { get; set; }
        public int DiningArea { get; set; }
        public decimal RentPrice { get; set; }

    }
}

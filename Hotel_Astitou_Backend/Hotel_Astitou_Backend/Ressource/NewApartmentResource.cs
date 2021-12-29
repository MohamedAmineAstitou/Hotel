using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Ressource
{
    public class NewApartmentResource
    {
        public NewApartmentResource(string adress, string type, int floor, int roomNumber, int totalArea, int bedroomArea, int diningArea, decimal rentPrice)
        {
            Adress = adress;
            Type = type;
            Floor = floor;
            RoomNumber = roomNumber;
            TotalArea = totalArea;
            BedroomArea = bedroomArea;
            DiningArea = diningArea;
            RentPrice = rentPrice;
        }

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

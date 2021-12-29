using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Ressource
{
    public class NewBookingResource
    {
        public NewBookingResource(DateTime dateOfArrival, DateTime dateOfDeparture, int lodgerId, int apartmentId)
        {
            DateOfArrival = dateOfArrival;
            DateOfDeparture = dateOfDeparture;
            LodgerId = lodgerId;
            ApartmentId = apartmentId;
        }

        public DateTime DateOfArrival { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public int LodgerId { get; set; }
        public int ApartmentId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Ressource
{
    public class RoomResource
    {
        public int Id { get; set; }
        public int Surface { get; set; }
        public int Idapartment { get; set; }
        public int ApartementId { get; set; }
    }
}

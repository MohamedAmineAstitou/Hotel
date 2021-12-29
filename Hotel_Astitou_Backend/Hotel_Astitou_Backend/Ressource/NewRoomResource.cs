using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Ressource
{
    public class NewRoomResource
    {
        public NewRoomResource(int surface, int idapartment, int apartementId)
        {
            Surface = surface;
            Idapartment = idapartment;
            ApartementId = apartementId;
        }

        public int Surface { get; set; }
        public int Idapartment { get; set; }
        public int ApartementId { get; set; }
    }
}

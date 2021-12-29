using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domain.Services.Communication
{
    public class ApartmentResponse : BaseResponse<Apartment>
    {
        public ApartmentResponse(Apartment appartment) : base(appartment)
        {
        }

        public ApartmentResponse(string message) : base(message)
        {
        }
    }
}

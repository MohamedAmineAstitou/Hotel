using Hotel_Astitou_Backend.Domain.Services.Communication;
using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MantaxHotel.Domaine.Service.Communication
{
    public class LodgerResponse: BaseResponse<Lodger>
    {
        public LodgerResponse(Lodger lodger) : base(lodger)
        {
        }

        public LodgerResponse(string message) : base(message)
        {
        }
      
    }
}
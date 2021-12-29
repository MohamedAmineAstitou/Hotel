using Hotel_Astitou_Backend.Domain.Services.Communication;
using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MantaxHotel.Domaine.Service.Communication
{
    public class GuarantorResponse : BaseResponse <Guarantor>
    {
        public GuarantorResponse(Guarantor guarantor) : base(guarantor)
        {
        }

        public GuarantorResponse(string message) : base(message)
        {
        }
    }
}
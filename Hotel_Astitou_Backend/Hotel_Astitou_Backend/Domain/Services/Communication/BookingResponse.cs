using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domain.Services.Communication
{
    public class BookingResponse : BaseResponse <Booking>
    {
        public BookingResponse(Booking booking) : base(booking)
        {
        }

        public BookingResponse(string message) : base(message)
        {
        }
}
}

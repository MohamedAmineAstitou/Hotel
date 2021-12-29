using Hotel_Astitou_Backend.Model;
using MantaxHotel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MantaxHotel.Extension
{
    public static class StringTokenExtension
    {
        public static User AsToken(this string token)
        {
            return JWTProvider.DecryptJWT(token);
        }
    }
}
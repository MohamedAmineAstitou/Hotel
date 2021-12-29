using AutoMapper;
using Hotel_Astitou_Backend.Model;
using Hotel_Astitou_Backend.Ressource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Mapping
{
    public class ModelToResource : Profile
    {
        public ModelToResource()
        {
            CreateMap<User, UserResource>();
            CreateMap<User, AuthenticatedUserResource>();
            CreateMap<Apartment, ApartmentResource>();
            CreateMap<Room, RoomResource>();
            CreateMap<Booking, BookingResource>();
            CreateMap<Guarantor, GuarantorResource>();
            CreateMap<Lodger, LodgerResource>();
        }
    }
}

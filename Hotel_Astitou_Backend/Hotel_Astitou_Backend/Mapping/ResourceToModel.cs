using AutoMapper;
using Hotel_Astitou_Backend.Model;
using Hotel_Astitou_Backend.Ressource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Mapping
{
    public class ResourceToModel : Profile
    {
        public ResourceToModel()
        {
            CreateMap<NewUserResource, User>();
            CreateMap<NewRoomResource, Room>();
            CreateMap<NewLodgerResource, Lodger>();
            CreateMap<NewBookingResource, Booking>();
            CreateMap<NewGuarantorResource, Guarantor>();
            CreateMap<NewApartmentResource, Apartment>();
        }
    }
}

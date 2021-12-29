using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Ressource
{
    public class NewGuarantorResource
    {
        public NewGuarantorResource(string gender, string name, string firstname, string adress, string city, string country, string email, int postalCode, int phoneNumber, int lodgerId)
        {
            Gender = gender;
            Name = name;
            Firstname = firstname;
            Adress = adress;
            City = city;
            Country = country;
            Email = email;
            PostalCode = postalCode;
            PhoneNumber = phoneNumber;
            LodgerId = lodgerId;
        }

        public string Gender { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public int PostalCode { get; set; }
        public int PhoneNumber { get; set; }
        public int LodgerId { get; set; }
    }
}

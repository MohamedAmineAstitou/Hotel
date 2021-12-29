using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Ressource
{
    public class NewLodgerResource
    {
        public NewLodgerResource(string name, string firstname, string gender, string civility, string adress, string city, string country, string email, int postalCode, int phoneNumber, DateTime birthday, string birthplace, string nationalRegister)
        {
            Name = name;
            Firstname = firstname;
            Gender = gender;
            Civility = civility;
            Adress = adress;
            City = city;
            Country = country;
            Email = email;
            PostalCode = postalCode;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
            Birthplace = birthplace;
            NationalRegister = nationalRegister;
        }

        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Gender { get; set; }
        public string Civility { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public int PostalCode { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Birthplace { get; set; }
        public string NationalRegister { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Hotel_Astitou_Backend.Model
{
    public partial class Guarantor
    {
        public int Id { get; set; }
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

        public  Lodger Lodger { get; set; }
    }
}

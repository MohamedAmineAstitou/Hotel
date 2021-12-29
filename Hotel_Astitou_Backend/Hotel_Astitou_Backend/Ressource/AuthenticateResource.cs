using System.ComponentModel.DataAnnotations;

namespace Hotel_Astitou_Backend.Ressource
{
    public class AuthenticateResource
    {
        [Required] public string username { get; set; }

        [Required] public string password { get; set; }
    }
}

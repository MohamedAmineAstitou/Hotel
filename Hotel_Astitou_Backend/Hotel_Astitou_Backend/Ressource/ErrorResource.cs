using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Ressource
{
    public class ErrorResource
    {
        public ErrorResource(List<string> messages)
        {
            Messages = messages ?? new List<string>();
        }

        public ErrorResource(string message)
        {
            Messages = new List<string>();

            if (!string.IsNullOrWhiteSpace(message))
                Messages.Add(message);
        }

        [Required] public bool Success => false;

        [Required] public List<string> Messages { get; }
    }
}

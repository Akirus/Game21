using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ComTypes;

namespace Game21.Data.Models
{
    public class Player
    {
        public string ID { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual Stats PlayerStats { get; set; }
    }
}
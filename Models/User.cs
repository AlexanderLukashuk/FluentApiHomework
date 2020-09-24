using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class User : Entity
    {
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Profile Profile { get; set; }
        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }
    }
}
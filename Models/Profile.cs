using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Profile
    {
        [Column("Имя")]
        public string Name { get; set; }
        [Column("Возраст")]
        public int Age { get; set; }
        public User User { get; set; }
    }
}
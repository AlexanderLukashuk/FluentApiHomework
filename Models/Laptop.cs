using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Laptop : Entity
    {
        [Column("Название")]
        public string Name { get; set; }
        [Column("Модель")]
        public string Model { get; set; }
        [Column("Производитель")]
        public string Manufacturer { get; set; }
        //public string CPU { get; set; }
        //public string RAM { get; set; }
        //public string GraphicsCard { get; set; }
        //public string HDD { get; set; }
        //public double Screen { get; set; }
        //public string OS { get; set; }
        //public double Weight { get; set; }
        //public int Like { get; set; }
        //public List<string> Comments { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
    }
}
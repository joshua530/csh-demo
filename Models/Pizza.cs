using System;
using System.ComponentModel.DataAnnotations;

namespace Pizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public PizzaSize Size { get; set; }

        [Range(0.01, 9999.99)]
        public bool IsGlutenFree { get; set; }
        public decimal Price { get; set; }
    }
}

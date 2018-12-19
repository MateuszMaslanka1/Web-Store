using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ShoppingDetailscs
    {
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        public string surname { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string country { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }
        [Required(ErrorMessage = "Street is required")]
        public string street { get; set; }
        [Required(ErrorMessage = "Zip is required")]
        public string zip { get; set; }
    }
}

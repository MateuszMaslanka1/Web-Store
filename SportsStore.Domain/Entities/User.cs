using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę użytkownika.")]
        public string login { get; set; }
        [Required(ErrorMessage = "Proszę podać hasło.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}

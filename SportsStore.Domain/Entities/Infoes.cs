using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Domain.Entities
{
    public class Infoes
    {
        [Key]
        public int InfoID { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}

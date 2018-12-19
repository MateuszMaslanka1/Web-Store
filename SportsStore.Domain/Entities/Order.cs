using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdUser { get; set; }
        public string Guid { get; set; }
        public DateTime Data { get; set; }
    }
}

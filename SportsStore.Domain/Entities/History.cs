using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class History
    {
        public int Id { get; set; }
        public int IdProducts { get; set; }
    }
}

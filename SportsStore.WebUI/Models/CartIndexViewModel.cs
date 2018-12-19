using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SportsStore.Domain.Entities;
namespace SportsStore.WebUI.Models
{        
       public class CartIndexViewModel
       {
            public Card Card { get; set; }
            //public string discount { get; set; } 
            public string Code { get; set; }
            public string ReturnUrl { get; set; }        
       }
}

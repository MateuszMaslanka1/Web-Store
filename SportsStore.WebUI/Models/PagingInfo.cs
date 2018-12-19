using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; } // liczba przedmiotów w bazie
        public int ItemsPerPage { get; set; } // liczba strona na stronie internetowej
        public int CurrentPage { get; set; } // numer akutualnie wyświetlanej strony

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}
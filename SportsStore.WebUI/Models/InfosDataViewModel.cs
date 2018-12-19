using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Models
{
    public class InfosDataViewModel : IEnumerable<string>
    {
        //public IEnumerable<Infoes> Infoes { get; set; }
        //public InfoDataHtml InfoDataHtml { get; set; }
        public IEnumerable<string> ProductsCategory;
        public IEnumerator<string> GetEnumerator()
        {
            return ProductsCategory.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ProductsCategory.GetEnumerator();
        }
    }

}
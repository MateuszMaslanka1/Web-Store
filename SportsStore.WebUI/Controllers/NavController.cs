using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;


namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;
        public NavController(IProductRepository repo)
        {
            this.repository = repo;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            InfosDataViewModel model = new InfosDataViewModel()
            {
                ProductsCategory = repository.Products.Select(x => x.Category).OrderBy(x => x).Distinct()
            };
            return PartialView(model);
        }                                                                                                       
    }
}
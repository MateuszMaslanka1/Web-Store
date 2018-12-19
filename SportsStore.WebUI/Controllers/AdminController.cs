using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        //[HttpPost]
        public ViewResult Create(Product product)
        {
            if (product.Name != null)
            {
                repository.AddProduct(product);
            }
            return View();
        }

        public ActionResult Menage()
        {
            return View(repository.Orders);
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            repository.AddHistory(productId);
            Product deletedProduct = repository.DeleteProduct(productId);
            
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Index()
        {
            int quantity = repository.Histories.Count();
            ViewBag.Totalquantity = quantity;
            return View(repository.Products);
        }

    }
}
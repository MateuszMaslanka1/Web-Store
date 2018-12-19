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
    [Authorize]
    public class ProductController : Controller
    {
        private IProductRepository repository;
        private IInfoRepository repoinfo;
        public int PageSize = 10;
        public int pageitem = 1;
        public ProductController(IProductRepository productRepository, IInfoRepository infoRepository)
        {
            this.repository = productRepository;
            this.repoinfo = infoRepository;
        }

        //public ViewResult DataInfo(int page = 1)
        //{
        //    InfosDataViewModel model = new InfosDataViewModel
        //    {
        //        Infoes = repoinfo.Infoes.Skip((page - 1) * pageitem).Take(pageitem),
        //        InfoDataHtml = new InfoDataHtml
        //        {
        //            Curentpage = page,
        //            Countpage = repoinfo.Infoes.Count()
        //        }            
        //    };
        //    return View(model);
        //}      
        public ViewResult List(string sort, string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products.Where(p => category == null || p.Category == category).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count():
                    repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            //ProductsListViewModel model = new ProductsListViewModel();
            //PagingInfo paginginfo = new PagingInfo();
            if (sort == "Price")
            {
                 model.Products = repository.Products.OrderBy(p => p.Price);
            }

            if (sort == "PriceDesc")
            {
                model.Products = repository.Products.OrderByDescending(p => p.Price);               
            }
            //paginginfo.CurrentPage = page;

            //paginginfo.TotalItems = category == null ? repository.Products.Count() :
            //repository.Products.Where(e => e.Category == category).Count();
            //model.CurrentCategory = category;

            return View(model);
        //return View(repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize));
    }
    }
}
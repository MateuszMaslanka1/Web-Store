using System;
using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private IProductRepository repository;

        public CartController (IProductRepository repo)
        {
            repository = repo;
        }
       
        public RedirectToRouteResult AddToCart(Card cart, int productId  ,string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult Rabate(Card cart,  string returnUrl, string Code)
        {   
            if(Code == "promo")
            {
                cart.Rebate();
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Checkout(Card cart, ShoppingDetailscs shoppingdetailscs)
        {
            ShoppingDetailscs details = shoppingdetailscs;
            object SessionUserID = Session["Id"];

            if (details.name != null)
            {
                cart.AddToMenageOrder(int.Parse(SessionUserID.ToString()));
                cart.SendEmialWithOrder(details);                
                return View("ThanksForOrder");
            }
            return View();
        }

        public RedirectToRouteResult RemoveFromCart(Card cart, int productId, string returnUrl)
        {          
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
               cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Card cart)
        {
            return PartialView(cart);
        }

        //private Card GetCart()
        //{
        //    Card cart = (Card)Session["Card"];
        //    if (cart == null)
        //    {
        //        cart = new Card();
        //        Session["Card"] = cart;
        //    }
        //    return cart;
        //}

        public ViewResult Index(Card cart, string returnUrl)
        {
           //CartIndexViewModel pom = new CartIndexViewModel();
           return View(new CartIndexViewModel {Card = cart, ReturnUrl = returnUrl});
          // return View(new CartIndexViewModel { Card = GetCart(),ReturnUrl = returnUrl,discount = Discount});   
          // return View(pom.Card = GetCart(), pom.ReturnUrl = returnUrl, pom.discount = Discount);
        }
    }
}
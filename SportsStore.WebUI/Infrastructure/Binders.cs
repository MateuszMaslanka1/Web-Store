using System.Web.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Card";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // pobranie obiektu Cart z sesji
            Card cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Card)controllerContext.HttpContext.Session[sessionKey];
            }
            // utworzenie obiektu Cart, jeżeli nie został znaleziony w danych sesji
            if (cart == null)
            {
                cart = new Card();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            // zwróć koszyk
            return cart;
        }
    }
}
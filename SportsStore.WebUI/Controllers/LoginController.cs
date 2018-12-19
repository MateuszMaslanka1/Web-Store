using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System.Linq;
using SportsStore.WebUI.Infrastructure.Abstract;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private IProductRepository repository;
        private IAuthProvider authProvider;

        public LoginController(IProductRepository repo, IAuthProvider auth)
        {
            repository = repo;
            authProvider = auth;
        }  
    
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Panel(string login, string password, string returnUrl)
        {
           User LoginUser = repository.Users.FirstOrDefault(x => x.login == login);
           User PasswordUser = repository.Users.FirstOrDefault(x => x.password == password);

           CheckPassword check = new CheckPassword(LoginUser.login, LoginUser.Id);
           check.UserSession();

            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(LoginUser.login, PasswordUser.password))
                {
                    return Redirect(returnUrl ?? Url.Action("List", "Product"));
                }
                else
                {
                    ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub niepoprawne hasło.");
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }     
        }

        [Authorize]
        public ActionResult logout()
        {
            authProvider.Logout();
            Session.Abandon();
            return View("Index");
        }

        public ActionResult UserDashBoard()
        {
            if (Session["Id"] != null)
            {
                var pom = Session["Id"];
                return RedirectToAction("List", "Product");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace SportsStore.WebUI.Models
{
    public class CheckPassword
    {
        private string Login;
        private int Id;

        public CheckPassword(string login, int id)
        {
            Login = login;
            Id = id;
        }

        public void UserSession()
        {
            HttpContext.Current.Session["Login"] = Login;
            HttpContext.Current.Session["Id"] = Id;
        }
    }
}
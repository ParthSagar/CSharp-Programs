using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebApplication4.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult ShowDefault()
        {
            return View();
        }
    }
}
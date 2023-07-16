﻿using CasgemPortfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Casgem_Portfolio.Controllers
{
    public class LoginController : Controller
    {
        CasgemPortfolioEntities4 db = new CasgemPortfolioEntities4();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin admin)
        {
            var values = db.TblAdmin.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["usertravel"] = values.Username.ToString();
                return RedirectToAction("Index", "WhoAmI");
            }
            else
            {
                return View();
            }


        }
    }
}
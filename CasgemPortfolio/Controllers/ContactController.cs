using CasgemPortfolio.Models.Entities;
using System.Web.Mvc;


namespace CasgemPortfolio.Controllers
{
    public class ContactController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index(TblMessage p)
        {
            db.TblMessage.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Portfolio");
        }
    }
}
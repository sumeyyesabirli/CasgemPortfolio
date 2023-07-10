using CasgemPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CasgemPortfolio.Models.Entities;


namespace CasgemPortfolio.Controllers
{
    public class ServiceController : Controller
    {           
      
        // GET: Service
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblService.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Service()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();
            return RedirectToAction("İndex");
        }

        public ActionResult DeleteService(int id)
        {
            var value = db.TblService.Find(id);
            db.TblService.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateService(int id)
        {
            var value = db.TblService.Find(id);
            return View(value);
        }

    }
    
}
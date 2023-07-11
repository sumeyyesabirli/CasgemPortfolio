using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CasgemPortfolio.Models.Entities;

namespace CasgemPortfolio.Controllers
{
    public class PortfolioController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            return View();
        }
        
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar() 
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            ViewBag.featureTitle = db.TblFeature.Select(x =>
               x.FeatureTitle).FirstOrDefault();
            ViewBag.featureDescription = db.TblFeature.Select(x =>
            x.FeatureDescription).FirstOrDefault();
            ViewBag.featureImageURL = db.TblFeature.Select(x =>
            x.FeatureImageURL).FirstOrDefault();
            return PartialView();
        }
    }
}
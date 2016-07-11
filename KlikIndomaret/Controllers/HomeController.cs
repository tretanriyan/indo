using KlikIndomaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlikIndomaret.Controllers
{
    public class HomeController : Controller
    {
        KlikIndoEntitiesConstring DBContek;
        public HomeController()
        {
            DBContek = new KlikIndoEntitiesConstring();
        }
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult GetRegion()
        {
            var tblStore = DBContek.Regions;
            var result = (from s in tblStore
                          select new
                          {
                              id = s.KodeDC,
                              //name = s.KodeDC + " " + s.RegionName
                              name = "Cabang: " + s.RegionName
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetStores(string KodeDcX)
        {
            var tblStore = DBContek.Stores.Where(x => x.KodeDC == KodeDcX);
            var result = (from s in tblStore
                          select new
                          {
                              id = s.StoreKode,
                              //name = s.StoreKode + " " + s.StoreName
                              name = "Toko: " + s.StoreName
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Downloadpdf() {

            return new Rotativa.UrlAsPdf("http://www.codeproject.com/")
            {
                //tr {page-break-inside: avoid;}
                FileName = "urltest.pdf",
            };
        }
	}
}
using Tamplate_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Tamplate_1.Controllers
{
    public class portfolioController : Controller
    {
        //
        // GET: /portfolio/

        ShaddadDbEntities db = new ShaddadDbEntities();
        public ActionResult Index(string SearchTrim="",int page=1)
        {




            var C_Section_Content = db.C_Section_Content.Include(c => c.C_Images).Include(c => c.C_Images1).Include(c => c.C_Images2).Include(c => c.C_Images3).Include(c => c.C_Images4).Include(c => c.C_Images5).Include(c => c.C_Images6).Include(c => c.C_Images7).Include(c => c.C_Section_Table).Where(c => c.C_So_Search_Trim_2 == SearchTrim & c.C_Section_Table.C_Section_Name == "portfolio").OrderByDescending(c=>c.Id);

            ViewBag.searchtrim = SearchTrim;


            if (Request.IsAjaxRequest())
            {
                return PartialView("PortfolioPged", C_Section_Content.ToPagedList(page, 3));
            }
            return View(C_Section_Content.ToPagedList(page, 3));

        }


       
        


    }
}

using Tamplate_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Postal;
using System.Web.Mvc;
using System.Web.UI;
 

namespace Tamplate_1.Controllers
{
    public class FooterController : Controller
    {
        //
        // GET: /Menus/
        private ShaddadDbEntities db = new ShaddadDbEntities();
        //[OutputCache(Duration = 360)]
        public ActionResult Index()
        {
             AllTables AllTables = new AllTables();
            try{ 
          
            AllTables.C_Section_Table = (from o in db.C_Section_Table select o).ToList();
            AllTables.C_Section_Content = (from o in db.C_Section_Content.Include(r => r.C_Images) select o).ToList();
               }
            catch(Exception ex)
              {
                  ViewBag.error = ex.Message;
                  return View("error");

              }

         return PartialView(AllTables);
           
        }
            
        }

    }


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
using Tamplate_1.Filters;
 

namespace Tamplate_1.Controllers
{
   [Log]
    public class HomeController : Controller
    {

       
        ShaddadDbEntities db = new ShaddadDbEntities();
     //[OutputCache(Duration=3600,VaryByHeader="X-Requsted-With",Location=OutputCacheLocation.Server)]
        public ActionResult Index()
        {
           
            //get map location serial and pot it in viewbag for contact section
            string maplocation = (from a in db.C_Section_Content
                                  where a.C_Section_Table.C_Section_Name== "Contact" 
                                  select a.C_Url_4).First();
            
            if (maplocation!=null)
            {
                ViewBag.maplocation = maplocation;
            }
            else
            {
                ViewBag.maplocation = "";
            }
           
           
          //alltables model has the sections table and section content table join the images table
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

            return View(AllTables);
           
        }

        //send email action 
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Send(AllTables model)
        {
            string _mail = model.Email;
            string _fname = model.First_Name;
            string _lname = model.Last_Name;
            string _subject = model.Subject;

            dynamic email = new Email("MyMail");
            email.To = "egyptioncoder@gmail.com";
            email.from = _mail;
            email.subject = "website email from :" + _fname;
            email.Body=_subject;
            email.CustMail = _mail;
           email.firstname = _fname;
            email.lastname = _lname;
            email.Send();
            return RedirectToAction("Index");
 
        }


  
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult error()
        {
            ViewBag.Message = "oops there is an error";
            
            return View();
        }
    }
}

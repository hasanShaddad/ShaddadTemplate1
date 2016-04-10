using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tamplate_1.Filters;
using Tamplate_1.Models;

namespace Tamplate_1.Controllers
{
    [Log]
    [Authorize(Roles = "Admin")]//صلاحية الدخول للمطورين فقط
    public class SectionsController : Controller
    {
        private ShaddadDbEntities db = new ShaddadDbEntities();

        //
        // GET: /Admin/
        
        public ActionResult Index()
        {
            var c_section_table = db.C_Section_Table.Include(c => c.C_Section_Content);
            return View(c_section_table.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            C_Section_Table c_section_table = db.C_Section_Table.Find(id);
            if (c_section_table == null)
            {
                return HttpNotFound();
            }
            return View(c_section_table);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.C_Section_Content, "Id", "C_Txt_1");
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(C_Section_Table c_section_table)
        {
            if (ModelState.IsValid)
            {
                db.C_Section_Table.Add(c_section_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.C_Section_Content, "Id", "C_Txt_1", c_section_table.Id);
            return View(c_section_table);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            C_Section_Table c_section_table = db.C_Section_Table.Find(id);
            if (c_section_table == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.C_Section_Content, "Id", "C_Txt_1", c_section_table.Id);
            return View(c_section_table);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(C_Section_Table c_section_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c_section_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.C_Section_Content, "Id", "C_Txt_1", c_section_table.Id);
            return View(c_section_table);
        }
        // GET: /Admin/Theme

        //public ActionResult Theme(string MyTheme)
        //{
        //    C_Section_Table c_section_table = db.C_Section_Table.Find(7);
        //    if (c_section_table == null || MyTheme == null || MyTheme == "")
        //    {
        //        return HttpNotFound();
        //    }
        //    c_section_table.C_Main_Txt_5 = MyTheme + ".css";
        //    ViewBag.Id = new SelectList(db.C_Section_Content, "Id", "C_Txt_1", c_section_table.Id);
        //    return View(c_section_table);
        //}

        // POST: /Admin/Theme

        [HttpPost]
        
        public ActionResult Theme(FormCollection collection)
        {
            string MyTheme = collection.Get("MyTheme");
            C_Section_Table c_section_table = db.C_Section_Table.Find(7);
            c_section_table.C_Main_Txt_5 = MyTheme + ".";
            if (MyTheme != null)
            {
                db.Entry(c_section_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.C_Section_Content, "Id", "C_Txt_1", c_section_table.Id);
            return View(c_section_table);
        }

        //
        // GET: /showhide

        public ActionResult ShowHide(int id = 0)
        {
            ShowHideMeth(id);
            return RedirectToAction( "index");
        }


       
      
        public void ShowHideMeth(int id = 0)
        {
            C_Section_Table c_section_table = db.C_Section_Table.Find(id);
            
                db.Entry(c_section_table).State = EntityState.Modified;
                if (c_section_table.C_Display == "block") { 
                c_section_table.C_Display = "none";
                }
                else
                {
                    c_section_table.C_Display = "block";
                }
                db.SaveChanges();
                
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            C_Section_Table c_section_table = db.C_Section_Table.Find(id);
            if (c_section_table == null)
            {
                return HttpNotFound();
            }
            return View(c_section_table);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            C_Section_Table c_section_table = db.C_Section_Table.Find(id);
            db.C_Section_Table.Remove(c_section_table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                db.Dispose();
                base.Dispose(disposing);
            }
            catch (Exception)
            {

                throw new Exception("conniction to server problem pleaase call your hosting support");
            }
           
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tamplate_1.Models;

namespace Tamplate_1.Controllers
{
    [Authorize(Roles = "Admin")]//صلاحية الدخول للمطورين فقط
    public class Section_contentController : Controller
    {
        private ShaddadDbEntities db = new ShaddadDbEntities();

        //
        // GET: /Section_content/

        public ActionResult Index(int id=0)
        {
            ViewBag.sectionid = id;
            var c_section_content = db.C_Section_Content.Include(c => c.C_Images).Include(c => c.C_Images1).Include(c => c.C_Images2).Include(c => c.C_Images3).Include(c => c.C_Images4).Include(c => c.C_Images5).Include(c => c.C_Images6).Include(c => c.C_Images7).Include(c => c.C_Section_Table).Where(c => c.C_Section_Table.Id==id);
            return View(c_section_content.ToList());
        }

        //
        // GET: /Section_content/Details/5

        public ActionResult Details(int id = 0)
        {
            C_Section_Content c_section_content = db.C_Section_Content.Find(id);
            if (c_section_content == null)
            {
                return HttpNotFound();
            }
            return View(c_section_content);
        }

        //
        // GET: /Section_content/Create

        public ActionResult Create(int myid=0)
        {
            ViewBag.sectionid = myid;
            ViewBag.C_Img_1 = new SelectList(db.C_Images, "Id", "C_Title");
            ViewBag.C_Img_2 = new SelectList(db.C_Images, "Id", "C_Title");
            ViewBag.C_Img_3 = new SelectList(db.C_Images, "Id", "C_Title");
            ViewBag.C_Img_4 = new SelectList(db.C_Images, "Id", "C_Title");
            ViewBag.C_Img_5 = new SelectList(db.C_Images, "Id", "C_Title");
            ViewBag.C_Img_6 = new SelectList(db.C_Images, "Id", "C_Title");
            ViewBag.C_Img_7 = new SelectList(db.C_Images, "Id", "C_Title");
            ViewBag.C_Img_8 = new SelectList(db.C_Images, "Id", "C_Title");
            ViewBag.C_Section_Id = new SelectList(db.C_Section_Table, "Id", "C_Section_Name");
            ViewBag.ContintSectionId = myid;
            return View();
        }

        //
        // POST: /Section_content/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(C_Section_Content c_section_content)
        {
            if (ModelState.IsValid)
            {
                db.C_Section_Content.Add(c_section_content);
                db.SaveChanges();
                return RedirectToAction("Index", new { id=c_section_content.C_Section_Id});
            }

            ViewBag.C_Img_1 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_1);
            ViewBag.C_Img_2 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_2);
            ViewBag.C_Img_3 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_3);
            ViewBag.C_Img_4 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_4);
            ViewBag.C_Img_5 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_5);
            ViewBag.C_Img_6 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_6);
            ViewBag.C_Img_7 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_7);
            ViewBag.C_Img_8 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_8);
            ViewBag.C_Section_Id = new SelectList(db.C_Section_Table, "Id", "C_Section_Name", c_section_content.C_Section_Id);
            return View(c_section_content);
        }

        //
        // GET: /Section_content/Edit/5

        public ActionResult Edit(int id = 0)
        {
            C_Section_Content c_section_content = db.C_Section_Content.Find(id);
            if (c_section_content == null)
            {
                return HttpNotFound();
            }
            ViewBag.sectionid = c_section_content.C_Section_Id;
            ViewBag.C_Img_1 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_1);
            ViewBag.C_Img_2 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_2);
            ViewBag.C_Img_3 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_3);
            ViewBag.C_Img_4 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_4);
            ViewBag.C_Img_5 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_5);
            ViewBag.C_Img_6 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_6);
            ViewBag.C_Img_7 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_7);
            ViewBag.C_Img_8 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_8);
            ViewBag.C_Section_Id = new SelectList(db.C_Section_Table, "Id", "C_Section_Name", c_section_content.C_Section_Id);
            return View(c_section_content);
        }

        //
        // POST: /Section_content/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(C_Section_Content c_section_content)
        {
            if (ModelState.IsValid)
            {
                int secid = c_section_content.C_Section_Id;
                db.Entry(c_section_content).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = secid });
            }
            ViewBag.C_Img_1 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_1);
            ViewBag.C_Img_2 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_2);
            ViewBag.C_Img_3 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_3);
            ViewBag.C_Img_4 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_4);
            ViewBag.C_Img_5 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_5);
            ViewBag.C_Img_6 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_6);
            ViewBag.C_Img_7 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_7);
            ViewBag.C_Img_8 = new SelectList(db.C_Images, "Id", "C_Title", c_section_content.C_Img_8);
            ViewBag.C_Section_Id = new SelectList(db.C_Section_Table, "Id", "C_Section_Name", c_section_content.C_Section_Id);
            return View(c_section_content);
        }

        //
        // GET: /Section_content/Delete/5

        public ActionResult Delete(int id = 0)
        {
            C_Section_Content c_section_content = db.C_Section_Content.Find(id);
            if (c_section_content == null)
            {
                return HttpNotFound();
            }
            return View(c_section_content);
        }

        //
        // POST: /Section_content/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            C_Section_Content c_section_content = db.C_Section_Content.Find(id);
            db.C_Section_Content.Remove(c_section_content);
            db.SaveChanges();
            return RedirectToAction("Index", new { id=c_section_content.C_Section_Id });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
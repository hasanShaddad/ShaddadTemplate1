using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tamplate_1.Models;
using System.Web.Helpers;
using System.Drawing;
using System.Drawing.Imaging;

namespace Tamplate_1.Controllers
{
    [Authorize(Roles = "Admin")]//صلاحية الدخول للمطورين فقط
    public class ImagesTableController : Controller
    {
        private ShaddadDbEntities db = new ShaddadDbEntities();

        //
        // GET: /Images/

        public ActionResult Index()
        {
            return View(db.C_Images.ToList());
        }

        [HttpPost]
        public ActionResult UploadImg(ImgUpload image)
        {
            if (image.file != null && Request["C_Section_Table"] != null)
            {
                try
                {
                    string SectionName = Request["C_Section_Table"];

                    string FileName = Path.GetFileName(image.file.FileName);
                    ImageModel Img = new ImageModel();
                    if (Img.SaveImage(FileName, SectionName).Item1 == null)
                    {
                        return RedirectToAction("Error", new { errormsg = "you did not chose a correct file to upload" });
                    }
                    string ImgPath = Img.SaveImage(FileName, SectionName).Item1;
                    string path = Path.Combine(Server.MapPath("~/"), ImgPath);
                    image.file.SaveAs(path);



                    if (Img.SaveImage(FileName, SectionName).Item2 == null)
                    {
                        return RedirectToAction("Error", new { errormsg = "you did not chose a correct file to upload" });
                    }

                    string path2 = Path.Combine(Server.MapPath("~/Mobile"), ImgPath);


                    System.Drawing.Image original = System.Drawing.Image.FromFile(path);

                    System.Drawing.Image img = ImageModel.ResizeImage(original, SectionName);

                    original.Dispose();


                    img.Save(path2);


                    img.Dispose();




                    //this to get the section id and send it to the create page for section id field











                    int ImageSectionId = (from a in db.C_Section_Table
                                          where a.C_Section_Name == SectionName
                                          select a.Id).First();




                    return RedirectToAction("Create", new { sucsessmsg = ImgPath, imid = ImageSectionId });
                }
                catch
                {
                    return RedirectToAction("Error", new { errormsg = "you did not chose a correct file to upload" });
                }

            }
            else
            {

                return RedirectToAction("Error", new { errormsg = "you did not chose a correct file to upload" });
            }

        }
        //
        // GET: /Images/Details/

        public ActionResult Details(int id = 0)
        {
            C_Images c_images = db.C_Images.Find(id);
            if (c_images == null)
            {
                return HttpNotFound();
            }
            return View(c_images);
        }

        //
        // GET: /Images/Create

        public ActionResult Create(string sucsessmsg ="",int imid =1)
        {
            ViewBag.imid = imid;
            ViewBag.sucsessmsg =sucsessmsg ;
            ViewBag.C_Section_Table = new SelectList(db.C_Section_Table, "C_Section_Name", "C_Section_Name");
            ViewBag.C_Section_Table_Id = new SelectList(db.C_Section_Table, "Id", "Id");
            return View();
        }
    
        //
        // POST: /Images/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(C_Images c_images)
        {
            if (ModelState.IsValid)
            {
                try { 
                db.C_Images.Add(c_images);
                db.SaveChanges();
                ViewBag.sucsessmsg = "select photo to upload";
                return RedirectToAction("Index");
            }
                catch
                {
                    if (c_images.C_Link == null)
                    {
                        return RedirectToAction("Error", new { errormsg = "you have to fill the iamge`s link field" });
                    }
                    else
                    {
                        return RedirectToAction("Error", new { errormsg = "wrong" });
                    }
                }
            }

            return View(c_images);
        }

        //
        // GET: /Images/Edit/5

        public ActionResult Edit(int id = 0)
        {
            C_Images c_images = db.C_Images.Find(id);
            if (c_images == null)
            {
                return HttpNotFound();
            }
            return View(c_images);
        }

        //
        // POST: /Images/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(C_Images c_images)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(c_images).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c_images);
        }

        //
        // GET: /Images/Delete/5

        public ActionResult Delete(int id = 0)
        {
            C_Images c_images = db.C_Images.Find(id);
            if (c_images == null)
            {
                return HttpNotFound();
            }
            return View(c_images);
        }

        //
        // POST: /Images/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            C_Images c_images = db.C_Images.Find(id);
            db.C_Images.Remove(c_images);
            db.SaveChanges();

            string fullPath = Request.MapPath("~/" + c_images.C_Link);
            string fullPathMo = Request.MapPath("~/Mobile" + c_images.C_Link);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            if (System.IO.File.Exists(fullPathMo))
            {
                System.IO.File.Delete(fullPathMo);
            }


            return RedirectToAction("Index");
        }

        public ActionResult Error(string errormsg="")
        {
            ViewBag.errormsg = errormsg;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
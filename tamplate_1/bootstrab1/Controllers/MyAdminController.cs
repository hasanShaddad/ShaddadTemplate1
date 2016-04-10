using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tamplate_1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MyAdminController : Controller
    {
        //
        // GET: /MyAdmin/

        public ActionResult Index()
        {
            return View();
        }

    }
}

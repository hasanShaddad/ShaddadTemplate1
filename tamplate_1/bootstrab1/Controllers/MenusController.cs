using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using Tamplate_1.Models;

namespace Tamplate_1.Controllers
{
    public class MenusController : Controller
    {
        //
        // GET: /Menus/
        private ShaddadDbEntities db = new ShaddadDbEntities();
         //[OutputCache(Duration = 360)]
        public ActionResult Menu()
        {
            var roles = new List<string> { "Admin", "Developer"};
            var userRoles = Roles.GetRolesForUser(User.Identity.Name);

            if (userRoles.Any(u => roles.Contains(u)))
            {
                ViewBag.auth = "admin";
            }
            else
            {
                ViewBag.auth = "user";
            }
            var C_Section_Table = db.C_Section_Table;
            return PartialView(C_Section_Table.ToList());
        }
         
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamplate_1.Models
{
    public class AllTables
    {
        public IEnumerable<C_Section_Table> C_Section_Table { get; set; }
        public IEnumerable<C_Section_Content> C_Section_Content { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Subject { get; set; }
    }
}
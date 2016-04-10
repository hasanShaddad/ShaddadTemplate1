using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tamplate_1.Filters
{
    public class LogAttribute:ActionFilterAttribute
    {

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                if (filterContext.Exception.Message == "The underlying provider failed on Open.")
                {
                    throw new Exception("something wrong on conniction to server please call your hosting support" + filterContext.Exception.Message);

                }
            }
            base.OnResultExecuted(filterContext);
           
        }
    }
}
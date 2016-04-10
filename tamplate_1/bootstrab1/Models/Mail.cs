using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Tamplate_1.Filters;
using Tamplate_1.Models;
using Facebook;
using Postal;
using System.Net;
namespace Tamplate_1.Models
{
    public static class Mail
    {
        public static string SendMail(string _username, string _password, string _email, string confirmationToken)
        {
            //WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { Email=model.Email});

            dynamic email = new Email("RegEmail");
            email.To = _email;
            email.UserName = _username;
            email.ConfirmationToken = confirmationToken;
            email.Send();
            var confermation = "mail sent" + _email;
            return confermation;
        }
    }
}
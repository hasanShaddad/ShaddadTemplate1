using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using Tamplate_1.Models;

namespace Tamplate_1
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "fZFY2pmpmYKrXy8llivuO5FaT",
            //    consumerSecret: "IJkrlnkS9r1NBTJYzv5R1BfFzjIb1oilX4jWSsGeZtjy3uYxzS");



            OAuthWebSecurity.RegisterFacebookClient(
                appId: "891994577580789",
                appSecret: "ce8e0b21804c0ac115dea7693308cb71"
               );



            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InspectionProject.Helpers
{
    public static class SessionHelper
    {
        private const string username = "UserName";
        private const string password = "PassWord";

        #region Public Static Methods
        // Clear() Clears out all values stored in the session but it keeps the user session
        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        // Abandon() kills user session so user will be assigned new session id next time he/she visits the sites
        public static void Abandon()
        {
            ClearSession();
            HttpContext.Current.Session.Abandon();
        }

        // Remove old session id and create a new one on every login
        public static void ClearOnLogin()
        {
            Abandon();
            
            if (HttpContext.Current.Request.Cookies["ASP.NET_SessionId"] != null)
            {
                HttpContext.Current.Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                HttpContext.Current.Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }
        }
        #endregion

        #region Public Static Properties
        /// <summary>
        /// Gets/Sets Session for Username
        /// </summary>
        public static string Username
        {
            get
            {
                if (HttpContext.Current.Session[username] == null)
                    return "";
                else
                    return HttpContext.Current.Session[username].ToString();
            }
            set { HttpContext.Current.Session[username] = value; }
        }

        /// <summary>
        /// Gets/Sets Session for Password
        /// </summary>
        public static string Password
        {
            get
            {
                if (HttpContext.Current.Session[password] == null)
                    return "";
                else
                    return HttpContext.Current.Session[password].ToString();
            }
            set { HttpContext.Current.Session[password] = value; }
        }
        #endregion
    }
}
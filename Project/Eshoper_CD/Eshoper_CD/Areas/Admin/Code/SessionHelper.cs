using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshoper_CD.Areas.Code
{
    public class SessionHelper
    {
        public static void SetSession(UserSession session)
        {
            HttpContext.Current.Session["loginAsAdminSession"] = session;
        }
        public static UserSession GetSession()
        {
            var session = HttpContext.Current.Session["loginAsAdminSession"];
            if(session == null)
            {
                return null;
            }
            else
            {
                return session as UserSession;
            }
        }

    }
}
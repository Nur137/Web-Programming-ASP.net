using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.SessionState;

    public partial class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Application["TotalApplications"] = 0;
            Application["TotalUserSessions"] = 0;
            Application["TotalApplications"] = (int)Application["TotalApplications"] + 1;

        }
        void Session_Start(object sneder, EventArgs e)
        {
            Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] + 1;
        }
        void Session_End(object sneder, EventArgs e)
        {
            Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] - 1;
        }

    }



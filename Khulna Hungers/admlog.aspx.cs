using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

public partial class admlog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonLog_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);
        conn.Open();
        string checkuser = "select count(*) from ADM where UN='" + TextBoxUN.Text + "'";
        SqlCommand com = new SqlCommand(checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();
        if (temp == 1)
        {
            conn.Open();
            string checkPasswordQuery = "select Pass from ADM where UN='" + TextBoxUN.Text + "'";
            SqlCommand passCom = new SqlCommand(checkPasswordQuery, conn);
            string password = passCom.ExecuteScalar().ToString().Replace(" ", "");
            if (password == TextBoxPass.Text)
            {
                Session["New"] = TextBoxUN.Text;
                Response.Write("password is correct");
                Session["login"] = TextBoxUN.Text.Trim();
                if (RM.Checked == true)
                {
                    HttpCookie userCookie;
                    userCookie = Request.Cookies["Preferences"];
                    if (userCookie == null)
                    {
                        userCookie = new HttpCookie("Preferences");
                        userCookie.Expires = DateTime.Now.AddMonths(1);
                        Response.Cookies.Add(userCookie);
                    }

                }
                Response.Redirect("Manager.aspx");






            }
            else
            {
                Response.Write("password is incorrect");
            }
        }
        else
        {
            Response.Write("Username is not correct");
        }
    }
}
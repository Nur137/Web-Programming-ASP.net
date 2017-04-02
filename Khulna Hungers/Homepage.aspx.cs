using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class Homepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["New"] != null)
        {
            Label1.Text = "WELCOME" + " " + Session["New"].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Clear();

        HttpCookie myCookie = new HttpCookie("Preferences");
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);

        Response.Redirect("Login.aspx");
    }


    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    protected void SubCom_Click(object sender, EventArgs e)
    {
        /*   try
        {
         * string str=session["New"].ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);
            conn.Open();
            string insertQuary = "insert into Comment (UN,Comment) values(@Uname ,@Comment)";
            SqlCommand com = new SqlCommand(insertQuary, conn);
            com.Parameters.AddWithValue("@Uname", str);
            com.Parameters.AddWithValue("@Comment", );
        
            com.ExecuteNonQuery();

          
            Response.Write("Comment Received. Thanks");

            conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("Error:" + ex.ToString());
        }
                
    }*/
    }
}
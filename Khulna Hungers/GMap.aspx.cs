using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Web.Security;
using System.IO;

public partial class GMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

            dds.DataSource = GetData("SELECT Shop FROM Location");
            dds.DataTextField = "Shop";
            dds.DataValueField = "Shop";
            dds.DataBind();

        }
    }
    private DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }

    protected void FetchShop(object sender, EventArgs e)
    {
        string id = dds.SelectedItem.Value;
        Label1.Text = id;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);
        conn.Open();
        string checkuser = "select long from Location where Shop= @s";
        SqlCommand com = new SqlCommand(checkuser, conn);
        com.Parameters.AddWithValue("@s", id);
        string q = com.ExecuteScalar().ToString();
        conn.Close();
        T1.Text = q;

        conn.Open();
        string checkuser1 = "select lat from Location where Shop= @s";
        SqlCommand com1 = new SqlCommand(checkuser1, conn);
        com1.Parameters.AddWithValue("@s", id);
        string q1 = com1.ExecuteScalar().ToString();
        conn.Close();
        T2.Text = q1;
    
    
    
    }
}
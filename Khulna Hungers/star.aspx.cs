using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using AjaxControlToolkit;
public partial class star : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        
    }
    protected void Rating1_Changed(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);


        int ratingValue = Rating1.CurrentRating;
        conn.Open();
        string insertQuary = "insert into Rates (Star) values(@os)";

        SqlCommand com = new SqlCommand(insertQuary, conn);
        com.Parameters.AddWithValue("@os", ratingValue);
        com.ExecuteNonQuery();
        conn.Close();


        Label1.Text = "You Rated: " + ratingValue;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Rating1.Visible = false;
    }
}
    

    

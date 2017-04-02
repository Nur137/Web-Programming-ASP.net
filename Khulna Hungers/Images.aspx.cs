using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 

public partial class Images : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {   }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetCity(string prefixText)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["RstConnectionString"].ToString();
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Fdb where FoodName like @City+'%'", con);
        cmd.Parameters.AddWithValue("@City", prefixText);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);       
        adp.Fill(dt);
        List<string> CityNames = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {

            CityNames.Add(dt.Rows[i][1].ToString());
        }
        return CityNames;
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

    protected void FetchImage(object sender, EventArgs e)
    {
        
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);
        conn.Open();
        string ld = "select ID from fdata where FName='" + txtCity.Text + "'";
        SqlCommand x = new SqlCommand(ld, conn);
        string id = x.ExecuteScalar().ToString();
        Label1.Text = id;
        conn.Close();
        Image1.Visible = id != "0";
        if (id != "0")
        {
            byte[] bytes = (byte[])GetData("SELECT FImage FROM fdata WHERE ID =" + id).Rows[0]["FImage"];
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            Image1.ImageUrl = "data:image/png;base64," + base64String;
        }
    }





    protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
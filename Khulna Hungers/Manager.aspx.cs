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

public partial class Manager : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            
            dds.DataSource = GetData("SELECT ID, Shopname FROM Shopdb");
            dds.DataTextField = "Shopname";
            dds.DataValueField = "ID";
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

   



    protected void ShopUp(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);

        if (FS.PostedFile != null && FS.PostedFile.FileName != "")
        {
            string FileName = Path.GetFileName(FS.PostedFile.FileName);
            FS.SaveAs(Server.MapPath("images/" + FileName));
            this.Image1.ImageUrl = "images/" + FileName;

            byte[] myimage = new byte[FS.PostedFile.ContentLength];
            HttpPostedFile Image = FS.PostedFile;
            Image.InputStream.Read(myimage, 0, (int)FS.PostedFile.ContentLength);
            conn.Open();

            string checkuser = "select count(*) from Shopdb where Shopname='" + sh.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();

            if (temp == 0)
            {
                SqlCommand storeimage = new SqlCommand("INSERT INTO Shopdb "
                    + "(Shopname, ShopImage) "
                    + " values (@Sname, @Simage)", conn);
                storeimage.Parameters.Add("@Sname", SqlDbType.VarChar, 50).Value = sh.Text;
                storeimage.Parameters.Add("@Simage", SqlDbType.Image, myimage.Length).Value = myimage;

                if (!(conn.State == System.Data.ConnectionState.Open))
                    conn.Open();
                storeimage.ExecuteNonQuery();
                conn.Close();
            }

            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Already Exists" + "');", true);
            
            }
        }
    }

    protected void FetchShop(object sender, EventArgs e)
    {
        string id = dds.SelectedItem.Value;
        Image1.Visible = id != "0";
        if (id != "0")
        {
            byte[] bytes = (byte[])GetData("SELECT ShopImage FROM Shopdb WHERE ID =" + id).Rows[0]["ShopImage"];
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            Image1.ImageUrl = "data:image/png;base64," + base64String;
        }
    }

    
    protected void Upfood(object sender, EventArgs e)
    {
        
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);

        if (FU.PostedFile != null && FU.PostedFile.FileName != "")
        {
            string FileName = Path.GetFileName(FU.PostedFile.FileName);
            FU.SaveAs(Server.MapPath("images/" + FileName));
            this.Image1.ImageUrl = "images/" + FileName;

            byte[] myimage = new byte[FU.PostedFile.ContentLength];
            HttpPostedFile Image = FU.PostedFile;
            Image.InputStream.Read(myimage, 0, (int)FU.PostedFile.ContentLength);
            conn.Open();

            string checkuser = "select count(*) from Fdb where ShopName= @s and FoodName=@f ";
            SqlCommand com = new SqlCommand(checkuser, conn);
            com.Parameters.AddWithValue("@s", dds.Text);
            com.Parameters.AddWithValue("@f", txtCity.Text);
           
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
        
                
            if (temp == 0)
            {

                conn.Open();
                string ld = "select Shopname from Shopdb where ID='" + dds.Text + "'";
                SqlCommand x = new SqlCommand(ld, conn);
                string id = x.ExecuteScalar().ToString();


                SqlCommand storeimage = new SqlCommand("INSERT INTO Fdb "
                    + "(FoodName, ShopName, FoodImage) "
                    + " values (@Fname,@SName, @Fimage)", conn);
                storeimage.Parameters.Add("@Fname", SqlDbType.VarChar, 50).Value =txtCity.Text;

                storeimage.Parameters.Add("@Sname", SqlDbType.VarChar, 50).Value = dds.Text;
                storeimage.Parameters.Add("@Fimage", SqlDbType.Image, myimage.Length).Value = myimage;

                if (!(conn.State == System.Data.ConnectionState.Open))
                    conn.Open();
                storeimage.ExecuteNonQuery();
                conn.Close();
            }

            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "This Food Already Exists" + "');", true);

            }

        }
        txtCity.Text = "Search";
        }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> GetCity(string prefixText, int count, string contextKey)
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
            if (dt.Rows[i][2].ToString()==contextKey)
            CityNames.Add(dt.Rows[i][1].ToString());
        }
        return CityNames;
    }



    protected void SubShop_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);

        conn.Open();
            string checkuser = "select count(*) from Location where Shop='" + Shop.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            float lon = float.Parse(Long.Text);
            float lat = float.Parse(Lat.Text);
            if (temp == 0)
            {
                SqlCommand com6 = new SqlCommand("INSERT INTO Location "
                    + "(Shop, long, lat) "
                    + " values (@sh, @long,@lat)", conn);
            com6.Parameters.AddWithValue("@sh", Shop.Text);
            com6.Parameters.AddWithValue("@long", lon);
            com6.Parameters.AddWithValue("@lat", lat);
            
                if (!(conn.State == System.Data.ConnectionState.Open))
                    conn.Open();
                com6.ExecuteNonQuery();
                conn.Close();
            }

            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Shopname Already Exists" + "');", true);

            }
        }
    }


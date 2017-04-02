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

public partial class Myprof : System.Web.UI.Page
{

   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            if (Session["New"] == null)
                Response.Redirect("Default.aspx");
            else
            {
                Response.ClearHeaders();

                Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");

                Response.AddHeader("Pragma", "no-cache");
            }
            dds.DataSource = GetData("SELECT ID, Shopname FROM Shopdb");
            dds.DataTextField = "Shopname";
            dds.DataValueField = "ID";
            dds.DataBind();

        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);
        con.Open();

        string checkuser = "select count(*) from profpicture where Username='" + Session["New"] + "'";
        string ld = "select ID from profpicture where Username='" + Session["New"] + "'";
        SqlCommand com = new SqlCommand(checkuser, con);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        con.Close();
        if (temp >0)
        {
            con.Open();
            SqlCommand x = new SqlCommand(ld, con);
            string ID = x.ExecuteScalar().ToString();

            con.Close();
            Image1.Visible = ID != "0";
            if (ID != "0")
            {
                byte[] bytes = (byte[])GetData("SELECT Propic FROM profpicture WHERE ID =" + ID).Rows[0]["Propic"];
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                Image1.ImageUrl = "data:image/png;base64," + base64String;
            }
        }

        if (Session["New"] != null)
        {
            Label1.Text = "Hello" + " " + Session["New"].ToString();
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
            if(dt.Rows[i][2].ToString()==contextKey)
            CityNames.Add(dt.Rows[i][1].ToString());
        }
        return CityNames;
    }

    protected void FetchShop(object sender, EventArgs e)
    {
        string id = dds.SelectedItem.Value;
        shpimage.Visible = id != "0";
        if (id != "0")
        {
            byte[] bytes = (byte[])GetData("SELECT ShopImage FROM Shopdb WHERE ID =" + id).Rows[0]["ShopImage"];
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            shpimage.ImageUrl = "data:image/png;base64," + base64String;
        }
    }
    protected void propicup_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);

        if (FU.PostedFile != null && FU.PostedFile.FileName != "")
        {
            string FileName = Path.GetFileName( FU.PostedFile.FileName);
            FU.SaveAs(Server.MapPath("Propics/" + FileName));
            this.Image1.ImageUrl = "Propics/" + FileName;
            byte[] myimage = new byte[FU.PostedFile.ContentLength];
            HttpPostedFile Image = FU.PostedFile;
            Image.InputStream.Read(myimage, 0, (int)FU.PostedFile.ContentLength);

            conn.Open();
            string x = "Propics/" + FileName;
            string checkuser = "select count(*) from profpicture where Username='" + Session["New"] + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();

            if (temp == 0)
            {
                SqlCommand storeimage = new SqlCommand("INSERT INTO profpicture "
                     + "(Username, Propic,directory) "
                     + " values (@Tname, @image,@dir)", conn);
                storeimage.Parameters.Add("@Tname", SqlDbType.VarChar, 50).Value = Session["New"];
                storeimage.Parameters.Add("@image", SqlDbType.Image, myimage.Length).Value = myimage;
                storeimage.Parameters.Add("@dir", SqlDbType.VarChar, 50).Value = x;


                if (!(conn.State == System.Data.ConnectionState.Open))
                    conn.Open();
                storeimage.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                conn.Open();

                string ld = "select ID from profpicture where Username='" + Session["New"] + "'";
                SqlCommand x1 = new SqlCommand(ld, conn);
                string ID = x1.ExecuteScalar().ToString();
                int myInt = System.Convert.ToInt32(ID);
                conn.Close();
                
                conn.Open();
                SqlCommand stimage = new SqlCommand("UPDATE Profpicture SET Propic = @pp, directory=@dir WHERE ID = @Id",conn);
                stimage.Parameters.Add("@Id", SqlDbType.Int, 9999).Value = myInt;
                stimage.Parameters.Add("@pp", SqlDbType.Image, myimage.Length).Value = myimage;
                stimage.Parameters.Add("@dir", SqlDbType.VarChar,50).Value = FileName;
                
                if (!(conn.State == System.Data.ConnectionState.Open))
                    conn.Open();
                stimage.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
    protected void Logout(object sender, EventArgs e)
    {
        Session.Clear();

        HttpCookie myCookie = new HttpCookie("Preferences");
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);

        Response.Redirect("Default.aspx");

      
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);
        conn.Open();
        string checkuser = "select ID from Fdb where ShopName= @s and FoodName=@f ";
        SqlCommand com = new SqlCommand(checkuser, conn);
        com.Parameters.AddWithValue("@s", dds.Text);
        com.Parameters.AddWithValue("@f", txtCity.Text);
        Label8.Text = txtCity.Text;
        string id=com.ExecuteScalar().ToString();
        conn.Close();  
        fdimage.Visible = id != "0";
        if (id != "0")
        {
            byte[] bytes = (byte[])GetData("SELECT FoodImage FROM Fdb WHERE ID =" + id).Rows[0]["FoodImage"];
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            fdimage.ImageUrl = "data:image/png;base64," + base64String;
        }
        
        conn.Open();
        string checkuser1 = "select count(*) from Shoprate where Shop= @s and UN=@p";
        SqlCommand com1 = new SqlCommand(checkuser1, conn);
        com1.Parameters.AddWithValue( "@s", dds.Text);
        com1.Parameters.AddWithValue("@p", Session["New"]);
       
        int temp1 = Convert.ToInt32(com1.ExecuteScalar().ToString());
        conn.Close();
        if(temp1==0)
        {
            Label5.Text = "Rate this image";
            Rating2.Visible = true;
        }
        else
        {
            Rating2.Visible = false;
            conn.Open();
            string checkuser3 = "select Rating from Shoprate where Shop= @s and UN=@p";
            SqlCommand com3 = new SqlCommand(checkuser3, conn);
            com3.Parameters.AddWithValue("@s", dds.Text);
            com3.Parameters.AddWithValue("@p", Session["New"]);
            string r = com3.ExecuteScalar().ToString();
            string k="Already Rated " +r;
            Label5.Text = k;
            conn.Close();
        }


        conn.Open();
        string checkuser2 = "select count(*) from foodrate where Shop= @x and UN=@y and Food=@z";
        SqlCommand com2 = new SqlCommand(checkuser2, conn);
        com2.Parameters.AddWithValue("@x", dds.Text);
        com2.Parameters.AddWithValue("@y", Session["New"]);

        com2.Parameters.AddWithValue("@z", txtCity.Text);


        
       
        int temp2 = Convert.ToInt32(com2.ExecuteScalar().ToString());
        conn.Close();
        if (temp2 == 0)
        {
            Label7.Text = "Rate this image";
            Rating1.Visible = true;
        }
        else
        {
            Rating1.Visible = false;
            conn.Open();
            string checkuser5 = "select Rating from foodrate where Shop= @x and UN=@y and Food=@z";
            SqlCommand com5 = new SqlCommand(checkuser5, conn);
            com5.Parameters.AddWithValue("@x", dds.Text);
            com5.Parameters.AddWithValue("@y", Session["New"]);
            com5.Parameters.AddWithValue("@z", txtCity.Text);

            string x = com5.ExecuteScalar().ToString();
            conn.Close();
        
            Label7.Text = "Already Rated (" + x+ ")";
        }


        conn.Open();
        string checkusershp = "select count(*) from ShopComment where Shop= @x and UN=@y";
        SqlCommand comshp = new SqlCommand(checkusershp, conn);
        comshp.Parameters.AddWithValue("@x", dds.Text);
        comshp.Parameters.AddWithValue("@y", Session["New"]);




        int tempshp = Convert.ToInt32(comshp.ExecuteScalar().ToString());
        conn.Close();
        if(tempshp==0)
        {
            TextBoxshp.Visible = true;
            TextBoxshp.Text = "";
            feedshp.Text = "Provide A Feedback";
            Buttonshp.Visible = true;
        }
        else 
        {
            TextBoxshp.Visible=false;
            feedshp.Text = "Already Commented";
            Buttonshp.Visible = false;
            
        }


        conn.Open();
        string checkuserfd = "select count(*) from FoodComment where Shop= @x and UN=@y and Food=@z";
        SqlCommand comfd = new SqlCommand(checkuserfd, conn);
        comfd.Parameters.AddWithValue("@x", dds.Text);
        comfd.Parameters.AddWithValue("@y", Session["New"]);
        
        comfd.Parameters.AddWithValue("@z", txtCity.Text);




        int tempfd = Convert.ToInt32(comfd.ExecuteScalar().ToString());
        conn.Close();
        if (tempfd == 0)
        {
            TextBoxfd.Visible = true;
            TextBoxfd.Text = "";
            feedfd.Text = "Provide A Feedback";
            Buttonfd.Visible = true;
        
        }
        else {
            TextBoxfd.Visible=false;
            feedfd.Text = "Already Commented";
            Buttonfd.Visible = false;
           
        }        
   

  
        
    }






    protected void Bfd(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);
        conn.Open();
        string ty = "select directory from profpicture where Username='" + Session["New"] + "'";
        SqlCommand comq = new SqlCommand(ty, conn);
        string hw=comq.ExecuteScalar().ToString();
        conn.Close();

          

        conn.Open();
        string insertQuary = "insert into FoodComment (Shop,Food,UN,Comment,dir) values(@shp,@fd,@un,@feed,@dir)";

        SqlCommand com = new SqlCommand(insertQuary, conn);
        com.Parameters.AddWithValue("@shp", dds.Text);
        com.Parameters.AddWithValue("@fd", txtCity.Text);
        
        com.Parameters.AddWithValue("@un", Session["New"]);

        com.Parameters.AddWithValue("@feed", TextBoxfd.Text);
        com.Parameters.AddWithValue("@dir", hw);

        com.ExecuteNonQuery();
        conn.Close();
        TextBoxfd.Visible = false;
        feedfd.Text="Thanks";
        Buttonfd.Visible = false;

    }






    protected void Bshp(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);

        conn.Open();
        string ty = "select directory from profpicture where Username='" + Session["New"] + "'";
        SqlCommand comq = new SqlCommand(ty, conn);
        string hw = comq.ExecuteScalar().ToString();
        conn.Close();

          
        conn.Open();
        string insertQuary = "insert into ShopComment (Shop,UN,Comment,Dir) values(@shp,@un,@feed,@dir)";

        SqlCommand com = new SqlCommand(insertQuary, conn);
        com.Parameters.AddWithValue("@shp", dds.Text);
        com.Parameters.AddWithValue("@un", Session["New"]);

        com.Parameters.AddWithValue("@feed", TextBoxshp.Text);
        com.Parameters.AddWithValue("@dir", hw);

        com.ExecuteNonQuery();
        conn.Close();

        TextBoxshp.Visible = false;
        feedshp.Text = "Thanks ";
        Buttonshp.Visible = false;
     
    }
   

  
    protected void Rating1_Changed(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);


        int ratingValue = Rating1.CurrentRating;
        conn.Open();
        string insertQuary = "insert into foodrate (Food,UN,Rating,Shop) values(@w,@x,@y,@z)";

        SqlCommand com = new SqlCommand(insertQuary, conn);
        com.Parameters.AddWithValue("@w", txtCity.Text);
        com.Parameters.AddWithValue("@x", Session["New"]);
        com.Parameters.AddWithValue("@y", ratingValue);
        com.Parameters.AddWithValue("@z", dds.Text);
        
        com.ExecuteNonQuery();
        conn.Close();

        Rating1.Visible = false;
        Label7.Text = "You Rated: " + ratingValue;

    }


    protected void Rating2_Changed(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);


        int ratingValue = Rating2.CurrentRating;
        conn.Open();
        string insertQuary = "insert into Shoprate (Shop,UN,Rating) values(@shp,@un,@rat)";

        SqlCommand com = new SqlCommand(insertQuary, conn);
        com.Parameters.AddWithValue("@shp", dds.Text);
        com.Parameters.AddWithValue("@un", Session["New"]);

        com.Parameters.AddWithValue("@rat", ratingValue);

        com.ExecuteNonQuery();
        conn.Close();

        Rating2.Visible = false;
        Label5.Text = "You Rated: " + ratingValue;

    }


    protected void txtCity_TextChanged(object sender, EventArgs e)
    {

    }
}
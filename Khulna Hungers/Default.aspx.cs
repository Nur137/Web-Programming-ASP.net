using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     

        if(!IsPostBack)
        {
            LoadImageData();
            

   }

    }
    protected void L(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);
        conn.Open();
        string checkuser = "select count(*) from UserLogin where Username='" + TextBoxUN.Text + "'";
        SqlCommand com = new SqlCommand(checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();
        if (temp == 1)
        {
            conn.Open();
            string checkPasswordQuery = "select Password from UserLogin where Username='" + TextBoxUN.Text + "'";
            SqlCommand passCom = new SqlCommand(checkPasswordQuery, conn);
            string password = passCom.ExecuteScalar().ToString().Replace(" ", "");
            if (password == TextBoxPass.Text)
            {
                Session["New"] = TextBoxUN.Text;
                Response.Write("password is correct");
                Session["login"] = TextBoxUN.Text.Trim();
                /*if (RM.Checked == true)
                {
                    HttpCookie userCookie;
                    userCookie = Request.Cookies["Preferences"];
                    if (userCookie == null)
                    {
                        userCookie = new HttpCookie("Preferences");
                        userCookie.Expires = DateTime.Now.AddMonths(1);
                        Response.Cookies.Add(userCookie);
                    }

                }*/
                Response.Redirect("Myprof.aspx");






            }
            else
            {
                //Response.Write("password is incorrect");
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Wrong Password!!! Try Again" + "');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Wrong UserName!!! Try Again" + "');", true);
            
            Response.Write("Username is not correct");
        }

    }
    

    private void LoadImageData()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("Imagefd.xml"));
        ViewState["ImageData"] = ds;

        ViewState["ImageDisplayed"] = 1;
        DataRow imageDataRow = ds.Tables["image"].Select().FirstOrDefault(x => x["order"].ToString() == "1");
        Image1.ImageUrl = "~/Foods/" + imageDataRow["name"].ToString();
        lblImageName.Text = imageDataRow["name"].ToString();
        lblImageOrder.Text = imageDataRow["order"].ToString();

    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {

    
        int i = (int)ViewState["ImageDisplayed"];
        i = i + 1;
        ViewState["ImageDisplayed"] = i;

        DataRow imageDataRow = ((DataSet)ViewState["ImageData"]).Tables["image"].Select().FirstOrDefault(x => x["order"].ToString() == i.ToString());
        if (imageDataRow != null)
        {
            Image1.ImageUrl = "~/Foods/" + imageDataRow["name"].ToString();
            lblImageName.Text = imageDataRow["name"].ToString();
            lblImageOrder.Text = imageDataRow["order"].ToString();
            Label1.Text = imageDataRow["alter"].ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);
            conn.Open();
         

        }
        else
        {
            LoadImageData();
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

    public void FetchShop(object sender, EventArgs e)
    {
        string q = Label1.Text;
        
        
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);
        conn.Open();
        string ld = "select ID from Shopdb where Shopname='" + Label1.Text + "'";
        SqlCommand x = new SqlCommand(ld, conn);
        string id = x.ExecuteScalar().ToString();

        

       Image2.Visible = id != "0";
        if (id != "0")
        {
            byte[] bytes = (byte[])GetData("SELECT ShopImage FROM Shopdb WHERE ID =" + id).Rows[0]["ShopImage"];
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            Image2.ImageUrl = "data:image/png;base64," + base64String;
        }
    }
    
 }


   

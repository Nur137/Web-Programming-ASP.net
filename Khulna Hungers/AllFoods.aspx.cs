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

public partial class AllFoods : System.Web.UI.Page
{
    SqlCommand cmdn;
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

    protected void LoadFood()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString;
        con.Open(); //
        cmdn = new SqlCommand("SELECT * FROM FoodComment", con);
        SqlDataReader reader = cmdn.ExecuteReader();
        int i = 1;
        while (reader.Read())
        {
            //Image1.ImageUrl = "data:Image/png;base64," + strBase64;




          


            Label objLabel = new Label();
            objLabel.ID = "labelx" + i.ToString();
            objLabel.ForeColor = System.Drawing.Color.Brown;
            objLabel.Font.Bold = true;
            objLabel.Text = "<br/>" + reader["UN"].ToString() + "<br/>";

            Label objLabel2 = new Label();
            objLabel2.Font.Size = 10;
            objLabel2.ForeColor = System.Drawing.Color.Gray;
            objLabel2.ID = "lblQ" + i.ToString();
            objLabel2.Text = "Comment: " + reader["Comment"].ToString() + "<br/>";


            //placeholder1.Controls.Add(new LiteralControl("<br/>"));

            if (reader["Shop"].ToString() == dds.Text && reader["Food"].ToString()==txtCity.Text)
            {

                placeholder1.Controls.Add(objLabel);
                placeholder1.Controls.Add(objLabel2);

                placeholder1.Controls.Add(new LiteralControl("<hr />"));
                i++;
            }

        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadFood();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);
        conn.Open();
        string checkuser = "select ID from Fdb where ShopName= @s and FoodName=@f ";
        SqlCommand com = new SqlCommand(checkuser, conn);
        com.Parameters.AddWithValue("@s", dds.Text);
        com.Parameters.AddWithValue("@f", txtCity.Text);
        string id = com.ExecuteScalar().ToString();
        conn.Close();
        fdimage.Visible = id != "0";
        if (id != "0")
        {
            byte[] bytes = (byte[])GetData("SELECT FoodImage FROM Fdb WHERE ID =" + id).Rows[0]["FoodImage"];
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            fdimage.ImageUrl = "data:image/png;base64," + base64String;
        }

        int x1 = 1;
        conn.Open();
        string checkuser1 = "select count(*) from foodrate where Shop= @s1 and Rating=@r1 and Food=@f1";
        SqlCommand com1 = new SqlCommand(checkuser1, conn);
        com1.Parameters.AddWithValue("@s1", dds.Text);
        com1.Parameters.AddWithValue("@r1", x1);
        com1.Parameters.AddWithValue("@f1", txtCity.Text);

        int temp1 = Convert.ToInt32(com1.ExecuteScalar().ToString());

        Label1.Text = temp1.ToString();
        conn.Close();


        int x2 = 2;
        conn.Open();
        string checkuser2 = "select count(*) from foodrate where Shop= @s2 and Rating=@r2 and Food=@f2";
        SqlCommand com2 = new SqlCommand(checkuser2, conn);
        com2.Parameters.AddWithValue("@s2", dds.Text);
        com2.Parameters.AddWithValue("@r2", x2);

        com2.Parameters.AddWithValue("@f2", txtCity.Text);
        int temp2 = Convert.ToInt32(com2.ExecuteScalar().ToString());
        Label2.Text = temp2.ToString();
        conn.Close();

        int x3 = 3;
        conn.Open();
        string checkuser3 = "select count(*) from foodrate where Shop= @s3 and Rating=@r3 and Food=@f3";
        SqlCommand com3 = new SqlCommand(checkuser3, conn);
        com3.Parameters.AddWithValue("@s3", dds.Text);
        com3.Parameters.AddWithValue("@r3", x3);

        com3.Parameters.AddWithValue("@f3", txtCity.Text);
        int temp3 = Convert.ToInt32(com3.ExecuteScalar().ToString());

        Label3.Text = temp3.ToString();
        conn.Close();


        int x4 = 4;
        conn.Open();
        string checkuser4 = "select count(*) from foodrate where Shop= @s4 and Rating=@r4 and Food=@f4";
        SqlCommand com4 = new SqlCommand(checkuser4, conn);
        com4.Parameters.AddWithValue("@s4", dds.Text);
        com4.Parameters.AddWithValue("@r4", x4);

        com4.Parameters.AddWithValue("@f4", txtCity.Text);

        int temp4 = Convert.ToInt32(com4.ExecuteScalar().ToString());

        Label4.Text = temp4.ToString();
        conn.Close();

        int x5 = 5;
        conn.Open();
        string checkuser5 = "select count(*) from foodrate where Shop= @s5 and Rating=@r5 and Food=@f5";
        SqlCommand com5 = new SqlCommand(checkuser5, conn);
        com5.Parameters.AddWithValue("@s5", dds.Text);
        com5.Parameters.AddWithValue("@r5", x5);

        com5.Parameters.AddWithValue("@f5", txtCity.Text);
        int temp5 = Convert.ToInt32(com5.ExecuteScalar().ToString());

        Label5.Text = temp5.ToString();
        conn.Close();


        
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
            if (dt.Rows[i][2].ToString() == contextKey)
                CityNames.Add(dt.Rows[i][1].ToString());
        }
        return CityNames;
    }
    }


     
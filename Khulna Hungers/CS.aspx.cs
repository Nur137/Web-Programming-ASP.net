using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Configuration;

using System.Data.SqlClient;
using System.Net;

using System.Net.Mail;
public partial class CS : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    private void SendActivationEmail(int userId)
    {

        string constr = ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString;

        string activationCode = Guid.NewGuid().ToString();

        using (SqlConnection con = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("INSERT INTO Activation VALUES(@UserId, @ActivationCode)"))
            {

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@UserId", userId);

                    cmd.Parameters.AddWithValue("@ActivationCode", activationCode);

                    cmd.Connection = con;

                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();

                }

            }

        }

        using (MailMessage mm = new MailMessage("calmimtiaz1384321@gmail.com", txtEmail.Text))
        {


            mm.Subject = "Account Activation";

            string body = "Hello " + txtUsername.Text.Trim() + ",";

            body += "<br /><br />Please click the following link to activate your account";

            body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("CS.aspx", "CS_Activation.aspx?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>";

            body += "<br /><br />Thanks";

            mm.Body = body;

            mm.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";

            smtp.EnableSsl = true;

            NetworkCredential NetworkCred = new NetworkCredential("calmimtiaz1384321@gmail.com", "Determinedtokeepcalm");

            smtp.UseDefaultCredentials = true;

            smtp.Credentials = NetworkCred;

            smtp.Port = 587;

            smtp.Send(mm);

        }

    }

    protected void RegisterUser(object sender, EventArgs e)
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Your Message", true);
        
        int userId = 0;

        string constr = ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString;

        using (SqlConnection con = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("Insert_Users"))
            {

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());

                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                    cmd.Connection = con;

                    con.Open();

                    userId = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();

                }

            }

            string message = string.Empty;

            switch (userId)
            {

                case -1:

                    message = "Username already exists.\\nPlease choose a different username.";

                    break;

                case -2:

                    message = "Supplied email address has already been used.";

                    break;

                default:

                    message = "Registration successful.Activation Email has been sent.\\nUser Id: " + userId.ToString();
                    SendActivationEmail(userId);
                    break;

            }

           
            //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            Response.Redirect("Default.aspx");
        }

    }

    
    protected void txtUsername_TextChanged(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(txtUsername.Text))
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);

            con.Open();

            SqlCommand cmd = new SqlCommand("select * from UserLogin where Username=@N", con);

            cmd.Parameters.AddWithValue("@N", txtUsername.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {

                checkusername.Visible = true;

               

                lblStatus.Text = "UserName Already Taken";
                mb.Visible = false;
            }

            else
            {

                checkusername.Visible = true;

                mb.Visible = true;

                lblStatus.Text = "UserName Available";

            }

        }

        else
        {

            checkusername.Visible = false;

        }

    }


   
    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(txtEmail.Text))
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RstConnectionString"].ConnectionString);

            con.Open();

            SqlCommand cmd = new SqlCommand("select * from UserLogin where Email=@Name", con);

            cmd.Parameters.AddWithValue("@Name", txtEmail.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {

                em.Visible = true;



                Label1.Text = "Eamil Has Already Been Used";

            }

            else
            {

                em.Visible = true;



                Label1.Text = "Email Available";
                button.Visible = true;

            }

        }

        else
        {

            em.Visible = false;

        }

    }
     
  
}

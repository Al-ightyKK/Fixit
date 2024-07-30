using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.IO;
using System.Data.Sql;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

public partial class loginpassword : System.Web.UI.Page
{
    DataSet DsStockist = new DataSet();
    DataTable dtDsStockist = new DataTable();
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            account.Visible = false;
            newdetails.Visible = true;
            success.Visible = false;
            btonnok.Visible = false;
            Lblname.Text = "" + Session["zsmname"];
            Lblcode.Text = "" + Session["zcode"];
            Lblpass.Text = "" + Session["emppass"];
            Lbldiv.Text = "" + Session["divi"];

            Hidnfldname.Value = Session["zsmname"].ToString();
            Hidnfldcode.Value = Session["zcode"].ToString();
            Hidnfldiv.Value = Session["divi"].ToString();
            Hidnfldlogin.Value = Session["login"].ToString();
            Session.Clear();
            Session["zsmname"] = Hidnfldname.Value.ToString();
            Session["zcode"] = Hidnfldcode.Value.ToString();
            Session["divi"] = Hidnfldiv.Value.ToString();
            Session["login"] = Hidnfldlogin.Value.ToString();
            //  btonrest.Visible = false;
        }
    }
    protected void onclickverify(object sender, EventArgs e)
    {
        string match1 = string.Empty;
        string match2 = string.Empty;
         match1 = Txtboxnewpass.Text;
         match2 = Txtbxrepass.Text;
         if (match1.Length < 8)
         {
             Lblvrfy.Visible = false;
             Lblnoteice.Text = "Please make sure your passwords contains atleast 8 characters* (alphabets and numbers).";
             Lblnoteice.ForeColor = System.Drawing.Color.Red;
             Lblnotvrfy.Visible = false;

         }
         else
         {
             Regex rgx = new Regex("[^A-Za-z0-9]+$");
             if (!rgx.IsMatch(match1))
             {
                 Regex rgxnum = new Regex("[^0-9]+$");
                 if (!rgxnum.IsMatch(match1))
                 {
                     if (match1 == match2)
                     {
                         Lblvrfy.Visible = true;
                         Lblnoteice.ForeColor = System.Drawing.Color.Black;
                         Lblnoteice.Text = "Please make sure your passwords contains atleast 8 characters* (alphabets and numbers).";
                         Lblvrfy.Text = "Verified! Please Click on Ok to save the new password!";
                         Lblnotvrfy.Visible = false;
                         btonnok.Visible = true;
                         //  btonrest.Visible = true;
                     }
                     else
                     {
                         Lblvrfy.Visible = false;
                         Lblnotvrfy.Text = "Please make sure your passwords match.";
                         Lblnotvrfy.Visible = true;
                     }
                 }
                 else
                 {
                     Lblvrfy.Visible = false;
                     Lblnoteice.ForeColor = System.Drawing.Color.Red;
                     Lblnoteice.Text = "Please Make sure your Password contains Alphabets and Numbers Both!";
                     Lblnotvrfy.Visible = false;
                 }
             }
             else
             {
                 Lblvrfy.Visible = false;
                 Lblnoteice.ForeColor = System.Drawing.Color.Red;
                 Lblnoteice.Text = "Please Make sure your Password contains Alphabets and Numbers Both!";
                 Lblnotvrfy.Visible = false;
                
             }
         }
        newdetails.Visible = true;
    }

    protected void onclickreset(object sender, EventArgs e)
    {
        Hidnfldname.Value = Session["zsmname"].ToString();
        Hidnfldcode.Value = Session["zcode"].ToString();
        Hidnfldiv.Value = Session["divi"].ToString();
        Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("loginpassword.aspx");
    }
    protected void checkbuttonclick(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[loginID$];", conn);
        conn.Open();
        SqlDataReader read = cmd.ExecuteReader();
        var logintbl = new DataTable();
        string empcode = string.Empty;
        string emppass = string.Empty;
        string directpage = string.Empty;
        string zsmname = string.Empty;
        logintbl.Load(read);
        if (logintbl.Rows.Count > 0)
        {
            TableRow lgtbrw1 = new TableRow();
            for (int i = 0; i < logintbl.Rows.Count; i++)
            {
                empcode = logintbl.Rows[i][2].ToString();
                if (empcode == Usercode.Text)
                {
                    emppass = logintbl.Rows[i][4].ToString();
                    if (emppass == Useroldpass.Text)
                    {
                        string compcode = logintbl.Rows[i][0].ToString();
                        string zcode = logintbl.Rows[i][2].ToString();
                        Session["zcode"] = zcode;
                        zsmname = logintbl.Rows[i][3].ToString();
                        Session["zsmname"] = zsmname;
                        string divi = logintbl.Rows[i][6].ToString();
                        Session["divi"] = divi;
                        Session["emppass"] = emppass;
                        Lblname.Text = "" + Session["zsmname"];
                        Lblcode.Text = "" + Session["zcode"];
                        Lblpass.Text = "" + Session["emppass"];
                        Lbldiv.Text = "" + Session["divi"];
                        newdetails.Visible = true;
                        Lblmessage.Visible = false;
               
                    }
                    else
                    {
                        Lblmessage.ForeColor = System.Drawing.Color.Red;
                        Lblmessage.Text = "Please check your Password Again";
                    }

                }
            }
        }
    }
    protected void onclicksubmt(object sender, EventArgs e)
    {
        try
        {
            DateTime tmine = DateTime.Now;
            string match2 = string.Empty;
            match2 = Txtbxrepass.Text;
            SqlCommand cmd = new SqlCommand("templateps_passwordchange", conn);
            cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@newpass", match2);
            cmd.Parameters.AddWithValue("@ZSM_CODE", Hidnfldcode.Value.ToString());
            cmd.Parameters.AddWithValue("@division", Hidnfldiv.Value.ToString());
            cmd.Parameters.AddWithValue("@Submittime", tmine.ToString("MMM dd yyyy hh:mm tt"));
            conn.Open();
            //cmd.ExecuteNonQuery();
            string strRslt = cmd.ExecuteNonQuery().ToString();
            conn.Close();
            success.Visible = true;
            Lblvrfy.Visible = false;
            Lblnotvrfy.Visible = false;
            Lblnoteice.Visible = false;
            DateTime logout = DateTime.Now;
            SqlCommand cmdd = new SqlCommand("Logoutrecord_ps", conn);
            cmdd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.AddWithValue("@logout", logout.ToString("MMM dd yyyy hh:mm tt"));
            cmdd.Parameters.AddWithValue("@ZSM_CODE", Hidnfldcode.Value.ToString());
            cmdd.Parameters.AddWithValue("@Datetime", Hidnfldlogin.Value.ToString());
            conn.Open();
            //cmd.ExecuteNonQuery();
            string strRsslt = cmdd.ExecuteNonQuery().ToString();
            conn.Close();
            SqlCommand cmdt = new SqlCommand("SELECT * FROM [dbo].[loginID$] where ZSM_Code = '" + Hidnfldcode.Value.ToString() + "';", conn);
            conn.Open();
            SqlDataReader read = cmdt.ExecuteReader();
            var logintbl = new DataTable();
            logintbl.Load(read);
            if (logintbl.Rows.Count > 0)
            {
                TableRow lgtbrw1 = new TableRow();
                for (int i = 0; i < logintbl.Rows.Count; i++)
                {

                    string clientEmail = logintbl.Rows[i][7].ToString();
                    Session["clientEmail"] = clientEmail;
                }
            }
            conn.Close();
            string messageBody = "Dear " + Hidnfldname.Value.ToString() + "," + Environment.NewLine + Environment.NewLine + "Hope this email finds you well. We wanted to inform you that your password for your USERNAME : " + Hidnfldcode.Value.ToString() + " has been successfully updated as [ " + match2 + " ]. The security of your account is of utmost importance to us, and we encourage regular password updates as a proactive measure to keep your information safe. Make sure you remember your new password. " + Environment.NewLine + Environment.NewLine + "If you did not make this change or have any concerns about the security of your account, please contact our support team immediately at [anjali.mishra@gcvlife.in] so that we can assist you in resolving any potential issues." + Environment.NewLine + Environment.NewLine + "Thank you for your attention to this matter. We are committed to maintaining a secure environment for all our users and are here to assist you with any questions or concerns you might have." + Environment.NewLine + "Division: " + Hidnfldiv.Value.ToString() + Environment.NewLine + "Employee CODE: " + Hidnfldcode.Value.ToString() + Environment.NewLine + "Employee NAME: " + Hidnfldname.Value.ToString() + Environment.NewLine + "NEW PASSWORD: " + match2 + Environment.NewLine + "Module Link: https://glenmark.gcvlife.com/ " + Environment.NewLine;
            //string messmob = txtmob.Text;
            SqlCommand cmdemail = new SqlCommand("select top (1) * from PortforEmail;", conn);
            conn.Open();
            SqlDataReader reademail = cmdemail.ExecuteReader();
            var readl = new DataTable();
            readl.Load(reademail);

            string smtpclnt = readl.Rows[0][1].ToString();
            //  Session["smtpclnt"] = smtpclnt;
            string smtphost = readl.Rows[0][2].ToString();
            // Session["smtphost"] = smtphost;
            string smtpnoport = readl.Rows[0][3].ToString();
            // Session["smtpnoport"] = smtpnoport;
            string emailusername = readl.Rows[0][4].ToString();
            // Session["emailusername"] = emailusername;
            string emailuserpass = readl.Rows[0][5].ToString();
            // Session["emailuserpass"] = emailuserpass;
            string smtpenable = readl.Rows[0][6].ToString();
            // Session["smtpenable"] = smtpenable;

            conn.Close();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(emailusername);
            mail.To.Add(Session["clientEmail"].ToString()); // Client's email
            //mail.To.Add("anjali.mishra@gcvlife.in"); // Your email address
            mail.Subject = "AutoReply Fixit:- You have Changed your Password ";
            mail.Body = messageBody + Environment.NewLine + "Thanks and regards," + Environment.NewLine + "Anjali Mishra | Software Developer.";

            string Valueportno = smtpnoport;
            int intValueportno = int.Parse(Valueportno);
            string Valuebool = smtpenable;
            bool boolValenable = bool.Parse(Valuebool);
            //  SmtpClient smtp = new SmtpClient();
            SmtpClient smtpClient = new SmtpClient(smtpclnt);
            smtpClient.Host = smtphost; // Set your SMTP server address
            smtpClient.Port = intValueportno; // Set the SMTP port (usually 587 for TLS)
            smtpClient.Credentials = new NetworkCredential(emailusername, emailuserpass);
            smtpClient.EnableSsl = boolValenable;
            try
            {
            smtpClient.Send(mail);
             }
                   catch
                   {
                   }
        }
        catch (Exception)
        {
            success.Visible = false;
            Lblnoteice.Visible = false;
            Lblvrfy.Visible = false;
            Lblnotvrfy.Visible = true;
            Lblnotvrfy.ForeColor = System.Drawing.Color.Red;
            Lblnotvrfy.Text = "Your Password was Not Updated! Please try again!";
        }
    }
}
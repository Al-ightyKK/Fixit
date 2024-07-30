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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;


public partial class Portsmpt : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    DataSet DsStockist = new DataSet();
    DataTable dtDsStockist = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            update.Visible = false;
            Lblnote.Visible = false;
            divtest.Visible = false;
        }
    }

    public void BindGrid()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "select top (1)* from PortforEmail";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);


        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdport.DataSource = dtDsStockist;

            Grdport.DataBind();
        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {

        SqlCommand cmd1 = new SqlCommand("update_port", conn);
        cmd1.CommandType = CommandType.StoredProcedure;

        //passing parameters ddlselect          
        cmd1.Parameters.AddWithValue("@SmtpClient", TxtboxSmtpClient.Text.Replace("'", "").Replace("<", "").Replace("&nbsp;", string.Empty).Replace("&#39;", "'").Replace("&#160;", "  ").ToString());
        cmd1.Parameters.AddWithValue("@smtpClientfromus", TxtboxsmtpClientfromus.Text.Replace("'", "").Replace("<", "").Replace("&nbsp;", string.Empty).Replace("&#39;", "'").Replace("&#160;", "  ").ToString());
        cmd1.Parameters.AddWithValue("@Host", Host.Text.Replace("'", "").Replace("<", "").Replace("&nbsp;", string.Empty).Replace("&#39;", "'").Replace("&#160;", "  ").ToString());
        cmd1.Parameters.AddWithValue("@noPort", noPort.Text.Replace("'", "").Replace("<", "").Replace("&nbsp;", string.Empty).Replace("&#39;", "'").Replace("&#160;", "  ").ToString());
        cmd1.Parameters.AddWithValue("@Credentialsname", Credentialsname.Text.Replace("'", "").Replace("<", "").Replace("&nbsp;", string.Empty).Replace("&#39;", "'").Replace("&#160;", "  ").ToString());
        cmd1.Parameters.AddWithValue("@Credentialspass", Credentialspass.Text.Replace("'", "").Replace("<", "").Replace("&nbsp;", string.Empty).Replace("&#39;", "'").Replace("&#160;", "  ").ToString());
        cmd1.Parameters.AddWithValue("@EnableSsl", EnableSsl.Text.Replace("'", "").Replace("<", "").Replace("&nbsp;", string.Empty).Replace("&#39;", "'").Replace("&#160;", "  ").ToString());
        conn.Open();
        string strRslt = cmd1.ExecuteNonQuery().ToString();
        conn.Close();
        update.Visible = false;
        Lblnote.Text = "Your changes have been Updated!";
        Lblnote.Visible = true;
        Btntest.Visible = true;
        BindGrid();
    }

    protected void GrdStockist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //  divtest.Visible = false;
        Btntest.Visible = false;
        if (e.CommandName == "btnEdit")
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int intRow = row.RowIndex;
            string empid = row.Cells[0].Text;
            string empname = row.Cells[1].Text;
            string empemail = row.Cells[2].Text;
            string empcon = row.Cells[3].Text;
            string desg = row.Cells[4].Text;
            string doj = row.Cells[5].Text;
            string doj2 = row.Cells[6].Text;
            TxtboxSmtpClient.Text = empid.ToString();
            TxtboxsmtpClientfromus.Text = empname.ToString();
            Host.Text = empemail.ToString();
            noPort.Text = empcon.ToString();
            Credentialsname.Text = desg.ToString();
            Credentialspass.Text = doj.ToString();
            EnableSsl.Text = doj2.ToString();
            update.Visible = true;
            Lblnote.Visible = false;
        }
        BindGrid();
    }

    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Portsmpt.aspx");
    }

    protected void Testmail_Click(object sender, EventArgs e)
    {
        divtest.Visible = true;
        Lblnote.Visible = false;
        Btntest.Visible = false;
    }

    protected void Sendemail_Click(object sender, EventArgs e)
    {
        try
        {
            string messageBody = "Dear Anyone," + Environment.NewLine + Environment.NewLine + "Hope this email finds you well. We wanted to inform you that your test mail is working fine!";
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
            mail.To.Add(Txtbxrecmail.Text); // Client's email
            //mail.To.Add("anjali.mishra@gcvlife.in"); // Your email address
            mail.Subject = "HEYALL:- Test Mail";
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

            smtpClient.Send(mail);


            Lblnote.Visible = true;
            Btntest.Visible = false;
            Button1.Visible = false;
            Lblnote.Text = "Mail Sent Sucessfully!";
        }
        catch
        {
            Lblnote.Visible = true;
            Lblnote.Text = "Mail not Sent Sucessfully!";
        }
    }
}
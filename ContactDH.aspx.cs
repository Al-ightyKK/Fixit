using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

public partial class ContactDH : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Hidnfldname.Value = Session["zsmname"].ToString();
            Hidnfldcode.Value = Session["zcode"].ToString();
            Hidnfldiv.Value = Session["divi"].ToString();
            Hidnfldlogin.Value = Session["login"].ToString();
            Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
            Lbldetail.Text = "Employee Code : " + Hidnfldcode.Value.ToString() + "<br />" + "Division : " + Hidnfldiv.Value.ToString() + "";
        }
    }
    protected void Btnsub(object sender, EventArgs e)
    {
        string clientEmail = txtmail.Text;
        string messageBody = txtwrite.Text;
        string messmob = txtmob.Text;
        string Sy = "";
        Sy = "Select Count(PictureId)+1 from [dbo].[ContactDATA] ;";
        string connnn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(Sy, connnn);
        DataTable dataTable = new DataTable();
        adpRpt.Fill(dataTable);
        string countno = dataTable.Rows[0][0].ToString();
        string ticketno = "#000" + countno + Hidnfldcode.Value.ToString();
        SqlCommand cmdemail = new SqlCommand("select top (1)* from PortforEmail;", conn);
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
        mail.From = new MailAddress(clientEmail); // Client's email
        //  mail.From = new MailAddress("anjali.mishra@gcvlife.in");
        mail.To.Add(emailusername); // Your email address
        mail.Subject = "Fixit:- Ticket No: " + ticketno + " query raised by " + Hidnfldname.Value.ToString();
        mail.Body = "Division: " + Hidnfldiv.Value.ToString() + Environment.NewLine + "Employee CODE: " + Hidnfldcode.Value.ToString() + Environment.NewLine + "Employee NAME: " + Hidnfldname.Value.ToString() + Environment.NewLine + messageBody + Environment.NewLine + Environment.NewLine + "Contact Me at:" + messmob + Environment.NewLine + "Email Me at:" + clientEmail;

        if (FileUpload1.HasFile)
        {
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            mail.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, fileName));
        }

        //  SmtpClient smtp = new SmtpClient();
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
        try{
        smtpClient.Send(mail);
        }
        catch
        {
        }
        // Optionally, provide feedback to the user
        lblStatus.Text = "Message sent successfully.";
        //}
        MailMessage mailtoclient = new MailMessage();
        mailtoclient.From = new MailAddress(emailusername); // Client's email
        //  mail.From = new MailAddress("anjali.mishra@gcvlife.in");
        mailtoclient.To.Add(clientEmail); // Your email address
        mailtoclient.Subject = "AutoReply Fixit:- Acknowledgement of Your Query - Ticket No: " + ticketno;
        mailtoclient.Body = "Dear " + Hidnfldname.Value.ToString() + "," + Environment.NewLine + Environment.NewLine + "Hope this email finds you well. We acknowledge that we have received your recent query with ticket number " + ticketno + ". We greatly appreciate your interest and the time you've taken to communicate with us." + Environment.NewLine + Environment.NewLine + "We want to assure you that our dedicated team is actively working on addressing your query and finding the best possible solution. We understand the importance of your concern and we're committed to resolving it promptly and efficiently." + Environment.NewLine + Environment.NewLine + "While we work to resolve the matter, we kindly ask for your patience and understanding. Quality and excellence are at the forefront of our priorities, and we want to ensure that your needs are met to your utmost satisfaction." + Environment.NewLine + "" + Environment.NewLine + Environment.NewLine + "Thanks and regards," + Environment.NewLine + "Anjali Mishra | Software Developer.";

        //  SmtpClient smtp = new SmtpClient();
        SmtpClient smtpClientfromus = new SmtpClient(smtpclnt);
        smtpClientfromus.Host = smtphost; // Set your SMTP server address
        smtpClientfromus.Port = intValueportno; // Set the SMTP port (usually 587 for TLS)
        smtpClientfromus.Credentials = new NetworkCredential(emailusername, emailuserpass);
        smtpClientfromus.EnableSsl = boolValenable;
        try{
        smtpClientfromus.Send(mailtoclient);
         }
                   catch
                   {
                   }

        // Optionally, provide feedback to the user
        lblStatus.Text = "Message sent successfully.";
        lblStatus.Visible = true;
        byte[] bytes;
        using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
        {
            bytes = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
        }
        string constr = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        using (SqlConnection connt = new SqlConnection(constr))
        {
            string sql = "INSERT INTO ContactDATA VALUES(@zsmname, @zsmcode, @zsmdiv, @Write, @Emailadd, @Mobno, @Imagedetail, @ContentType,  @Data, @Pic)";
            using (SqlCommand cmd = new SqlCommand(sql, connt))
            {
                cmd.Parameters.AddWithValue("@zsmname", Hidnfldname.Value.ToString());
                cmd.Parameters.AddWithValue("@zsmcode", Hidnfldcode.Value.ToString());
                cmd.Parameters.AddWithValue("@zsmdiv", Hidnfldiv.Value.ToString());
                cmd.Parameters.AddWithValue("@Write", txtwrite.Text);
                cmd.Parameters.AddWithValue("@Emailadd", txtmail.Text);
                cmd.Parameters.AddWithValue("@Mobno", txtmob.Text);
                cmd.Parameters.AddWithValue("@Imagedetail", Path.GetFileName(FileUpload1.PostedFile.FileName));
                cmd.Parameters.AddWithValue("@ContentType", FileUpload1.PostedFile.ContentType);
                cmd.Parameters.AddWithValue("@Pic", "Uploads/" + Path.GetFileName(FileUpload1.PostedFile.FileName));
                cmd.Parameters.AddWithValue("@Data", bytes);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        Hidnfldname.Value = Session["zsmname"].ToString();
        Hidnfldcode.Value = Session["zcode"].ToString();
        Hidnfldiv.Value = Session["divi"].ToString();
        Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect(Request.Url.AbsoluteUri);

    }
    protected void btnShowNotification_Click(object sender, EventArgs e)
    {
        BindGridnotif();
        notificationBadge.Style["display"] = "none"; // Hide badge after clicking
        notificationPopup.Style["display"] = "block";
    }

    protected void btnCloseNotification_Click(object sender, EventArgs e)
    {
        notificationPopup.Style["display"] = "none";
    }


    public void BindGridnotif()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";

        StrQrry = "SELECT [DIVISION] , [NOTIFICATION], max([Time]) as Time from [dbo].[Notification$] where (([NOTIFICATION] like '%There%' or [NOTIFICATION] like '%Submitted%' or [NOTIFICATION] like '%awaiting%' or [NOTIFICATION] like '%Approved By Division%' or [NOTIFICATION] like '%Rejected By Division%' or [NOTIFICATION] like '%Rejected By Admin%') and  [DIVISION] = '" + Hidnfldiv.Value.ToString() + "') or [ZSM CODE] = '" + Hidnfldcode.Value.ToString() + "' group by [DIVISION] , [NOTIFICATION]  ORDER BY [Time] DESC;";
        //     Lblwh.Text = "Approval Request";where [Unblocked Percentage] <= " + Session["ddlpercent"] + " and Division = '" + Session["ddldiv"] + "'

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            notific.DataSource = dtDsStockist;
            // notific.Columns[1].Visible = false;
            notific.DataBind();
        }
        else
        {
            dtDsStockist.Rows.Add(dtDsStockist.NewRow());
            notific.DataSource = dtDsStockist;
            notific.DataBind();
        }

    }
    protected void btnoutclick(object sender, EventArgs e)
    {
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
        Response.Redirect("LoginPage.aspx");
    }

    protected void btnhmclick(object sender, EventArgs e)
    {
        Hidnfldname.Value = Session["zsmname"].ToString();
        Hidnfldcode.Value = Session["zcode"].ToString();
        Hidnfldiv.Value = Session["divi"].ToString();
        Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("Approvalpage.aspx");
    }
    protected void btntemp(object sender, EventArgs e)
    {
        Hidnfldname.Value = Session["zsmname"].ToString();
        Hidnfldcode.Value = Session["zcode"].ToString();
        Hidnfldiv.Value = Session["divi"].ToString();
        Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("TemplatesBh.aspx");
    }
    protected void btnnotific(object sender, EventArgs e)
    {
        Hidnfldname.Value = Session["zsmname"].ToString();
        Hidnfldcode.Value = Session["zcode"].ToString();
        Hidnfldiv.Value = Session["divi"].ToString();
        Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("Notificationpage.aspx");
    }
}
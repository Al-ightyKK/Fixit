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
using System.Net;
using System.Net.Mail;


public partial class Approvalpage : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Hidnfldname.Value = Session["zsmname"].ToString();
            Hidnfldcode.Value = Session["zcode"].ToString();
            Hidnfldiv.Value = Session["divi"].ToString();
            Hidnfldlogin.Value = Session["login"].ToString();
            BindGrid();
            binddropdown1();
            binddropdown2();
            binddropdown3();
            lblnow.Visible = false;
            Grdrprt.Visible = false;
        }
    }
    public void binddropdown1()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "Select distinct ZSM_Name from [dbo].[Approvallist$] where Division = '" + Hidnfldiv.Value.ToString() + "';";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            ddlempname.DataSource = dtDsStockist;
            ddlempname.DataTextField = "ZSM_Name";
            ddlempname.DataBind();
            ddlempname.Items.Insert(0, "Select");
            //ddlempname.SelectedIndex = 0;
        }

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
    public void binddropdown2()
    {
        DataSet DsStockist222 = new DataSet();
        DataTable dtDsStockist222 = new DataTable();
        string StrQrry222 = "";
        StrQrry222 = "Select distinct Brands from [dbo].[Templateconsolidate] where SALES_DIVISION = '" + Hidnfldiv.Value.ToString() + "';";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt222 = new SqlDataAdapter(StrQrry222, conn);
        adpRpt222.Fill(DsStockist222, "DsStockist222");
        adpRpt222.Fill(dtDsStockist222);
        if (DsStockist222.Tables[0].Rows.Count > 0)
        {
            ddlbrand.DataSource = dtDsStockist222;
            ddlbrand.DataTextField = "Brands";
            ddlbrand.DataBind();
            ddlbrand.Items.Insert(0, "Select");
            //ddlempname.SelectedIndex = 0;
        }

    }
    public void binddropdown3()
    {
        DataSet DsStockist222 = new DataSet();
        DataTable dtDsStockist222 = new DataTable();
        string StrQrry222 = "";
        StrQrry222 = "Select distinct Tag from [dbo].[Templateconsolidate] where SALES_DIVISION = '" + Hidnfldiv.Value.ToString() + "';";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt222 = new SqlDataAdapter(StrQrry222, conn);
        adpRpt222.Fill(DsStockist222, "DsStockist222");
        adpRpt222.Fill(dtDsStockist222);
        if (DsStockist222.Tables[0].Rows.Count > 0)
        {
            ddltag.DataSource = dtDsStockist222;
            ddltag.DataTextField = "Tag";
            ddltag.DataBind();
            ddltag.Items.Insert(0, "Select");
            //ddlempname.SelectedIndex = 0;
        }

    }
    protected void ddlemp_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlemp = string.Empty;
        ddlemp = ddlempname.SelectedValue.ToString();
        Session["ddlemp"] = ddlemp;
        Lblwh.Text = ddlempname.SelectedItem.ToString();
        BindGrid3();
        lblnow.Visible = false;
        Grdrprt.Visible = false;
    }
    protected void ddlbrnd_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlbrnd = string.Empty;
        ddlbrnd = ddlbrand.SelectedValue.ToString();
        Session["brnd"] = ddlbrnd;
        Lblwh.Text = ddlbrand.SelectedItem.ToString();
        BindGrid9();
        lblnow.Visible = false;
        Grdrprt.Visible = false;
    }
    protected void ddltag_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddltags = string.Empty;
        ddltags = ddltag.SelectedValue.ToString();
        Session["tag"] = ddltags;
        Lblwh.Text = ddltag.SelectedItem.ToString();
        BindGrid9();
        lblnow.Visible = false;
        Grdrprt.Visible = false;
    }
    public void BindGrid()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "Select distinct * from [dbo].[Approvallist$] where Division = '" + Hidnfldiv.Value.ToString() + "';";
        Lblwh.Text = "Approval Request";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        Lbldetail.Text = "Employee Code : " + Hidnfldcode.Value.ToString() + "<br />" + "Division : " + Hidnfldiv.Value.ToString() + "";
        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdemp.DataSource = dtDsStockist;
            Grdemp.Columns[1].Visible = false;
            Grdemp.DataBind();
        }
         else
        {
       dtDsStockist.Rows.Add(dtDsStockist.NewRow());
     Grdemp.DataSource = dtDsStockist;
     Grdemp.DataBind();
     Grdemp.Rows[0].Visible = false;
}

    }
    public void BindGrid3()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "Select distinct * from [dbo].[Approvallist$] where Division = '" + Hidnfldiv.Value.ToString() + "' and [ZSM_Name] = '" + Session["ddlemp"] + "';";
        Lblwh.Text = "Approval Request";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        Lbldetail.Text = "Employee Code : " + Hidnfldcode.Value.ToString() + "<br />" + "Division : " + Hidnfldiv.Value.ToString() + "";
        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdemp.DataSource = dtDsStockist;
            Grdemp.Columns[1].Visible = false;
            Grdemp.DataBind();
        }
        else
        {
            dtDsStockist.Rows.Add(dtDsStockist.NewRow());
            Grdemp.DataSource = dtDsStockist;
            Grdemp.DataBind();
            Grdemp.Rows[0].Visible = false;
        }

    }
        public void BindGrid9()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "Select * from Approvallist$ where ZSM_Name in (Select distinct [ZSM NAME] from [dbo].[Templateconsolidate] where SALES_DIVISION = '" + Hidnfldiv.Value.ToString() + "' and [Brands] = '" + Session["brnd"] + "');";
        Lblwh.Text = "Approval Request";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        Lbldetail.Text = "Employee Code : " + Hidnfldcode.Value.ToString() + "<br />" + "Division : " + Hidnfldiv.Value.ToString() + "";
        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdemp.DataSource = dtDsStockist;
            Grdemp.Columns[1].Visible = false;
            Grdemp.DataBind();
        }
        else
        {
            dtDsStockist.Rows.Add(dtDsStockist.NewRow());
            Grdemp.DataSource = dtDsStockist;
            Grdemp.DataBind();
            Grdemp.Rows[0].Visible = false;
        }

    }
        public void BindGrid10()
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select * from Approvallist$ where ZSM_Name in (Select distinct [ZSM NAME] from [dbo].[Templateconsolidate] where SALES_DIVISION = '" + Hidnfldiv.Value.ToString() + "' and [Tag] = '" + Session["tag"] + "');";
            Lblwh.Text = "Approval Request";
            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);

            Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
            Lbldetail.Text = "Employee Code : " + Hidnfldcode.Value.ToString() + "<br />" + "Division : " + Hidnfldiv.Value.ToString() + "";
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                Grdemp.DataSource = dtDsStockist;
                Grdemp.Columns[1].Visible = false;
                Grdemp.DataBind();
            }
            else
            {
                dtDsStockist.Rows.Add(dtDsStockist.NewRow());
                Grdemp.DataSource = dtDsStockist;
                Grdemp.DataBind();
                Grdemp.Rows[0].Visible = false;
            }

        }
    //protected void ddlmaster_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string ddlval = string.Empty;
    //    ddlval = ddlmasters.SelectedValue.ToString();
    //    Session["ddlses"] = ddlval;
    //    Lblwh.Text = ddlmasters.SelectedItem.ToString();
    //  //  BindGrid2();
    //}
    protected void changed(object sender, EventArgs e)
    {
        CheckBox chckstatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chckstatus.NamingContainer;
    }
    //protected void btnhome(object sender, EventArgs e)
    //{
    //    Response.Redirect("firstpage.aspx");
    //}
    //protected void btnmaster(object sender, EventArgs e)
    //{
    //    Response.Redirect("fixitmasters.aspx");
    //}
    //protected void btnreprt(object sender, EventArgs e)
    //{
    //    Response.Redirect("Fixitreports.aspx");
    //}
    //protected void btnsettng(object sender, EventArgs e)
    //{
    //    Response.Redirect("settings.aspx");
    //}
    protected void btnclk_noti(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("refrehnotific", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        //cmd.ExecuteNonQuery();
        string strRslt = cmd.ExecuteNonQuery().ToString();
        conn.Close();
        Hidnfldname.Value = Session["zsmname"].ToString();
        Hidnfldcode.Value = Session["zcode"].ToString();
        Hidnfldiv.Value = Session["divi"].ToString();
        Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("Notificationpage.aspx");
    }
    protected void btntemp(object sender, EventArgs e)
    {
        Hidnfldname.Value = Session["zsmname"].ToString();
        Hidnfldcode.Value = Session["zcode"].ToString();
        Hidnfldiv.Value = Session["divi"].ToString();
        Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("TemplatesBh.aspx");
    }
    protected void btnconta(object sender, EventArgs e)
    {
        Hidnfldname.Value = Session["zsmname"].ToString();
        Hidnfldcode.Value = Session["zcode"].ToString();
        Hidnfldiv.Value = Session["divi"].ToString();
        Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("ContactDH.aspx");
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
    protected void Grdemp_rowcommand(object sender, GridViewCommandEventArgs e)
    {
        DateTime Submitt = DateTime.Now;
        string[] arg = new string[4];
        arg = e.CommandArgument.ToString().Split(';');
        Session["ZSM CODE"] = arg[0];
        Session["ZSM_Name"] = arg[1];
        Session["Unblocked Percentage"] = arg[2];
        Session["Approvedview"] = arg[3];
        string id = "";
        string name = "";
        string approved = "";
        if (e.CommandName == "btncApproved")
        {

            id = arg[0].ToString();
            approved = arg[3].ToString();
            SqlCommand cmd = new SqlCommand("templateps_approvaldone", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ZSM_CODE", id.ToString());
            cmd.Parameters.AddWithValue("@approv", approved.ToString());
            cmd.Parameters.AddWithValue("@Submittime", Submitt.ToString("MMM dd yyyy hh:mm tt"));
            conn.Open();
            //cmd.ExecuteNonQuery();
            string strRslt = cmd.ExecuteNonQuery().ToString();
            conn.Close();
            SqlCommand cmdt = new SqlCommand("SELECT * FROM [dbo].[loginID$] where ZSM_Code = '" + id.ToString() + "';", conn);
            conn.Open();
            SqlDataReader read = cmdt.ExecuteReader();
            var logintbl = new DataTable();
            logintbl.Load(read);
            if (logintbl.Rows.Count > 0)
            {
                TableRow lgtbrw1 = new TableRow();
                for (int i = 0; i < logintbl.Rows.Count; i++)
                {
                    string ZSMname = logintbl.Rows[i][3].ToString();
                    Session["ZSMname"] = ZSMname;
                    string ZSMcode = logintbl.Rows[i][2].ToString();
                    Session["ZSMcode"] = ZSMcode;
                    string clientEmail = logintbl.Rows[i][7].ToString();
                    Session["clientEmail"] = clientEmail;
                }
            }
            SqlCommand cmdt2 = new SqlCommand("SELECT * FROM [dbo].[Approvallist$] where [ZSM CODE] = '" + id.ToString() + "';", conn);
            SqlDataReader read2 = cmdt2.ExecuteReader();
            var logintbl2 = new DataTable();
            logintbl2.Load(read2);
            string percentagezsm = logintbl2.Rows[0][6].ToString();
            // Session["percentagezsm"] = percentagezsm;
            conn.Close();
            string messageBody = "Dear " + Session["ZSMname"].ToString() + "," + Environment.NewLine + Environment.NewLine + "Hope this email finds you well. Thanks for your support, one of the pivotal initiatives taken over by the company is to reduce ‘Expiry returns (Expiry + Short Expiry+ Near Expiry + Damaged goods)’ which currently stands at levels higher than the industry average of 1.5% - 2%." + Environment.NewLine + Environment.NewLine + "Your response to the unblocking of stockiest pack combinations has been successfully sent to the Division Head for approval as the % of stockiest-pack combinations requested to be unblocked exceeds 60%." + Environment.NewLine + " We are pleased to inform you that current approval status stands: Approved by Division Head" + Environment.NewLine + Environment.NewLine + "Response Details for your ready reference:" + Environment.NewLine + Environment.NewLine + "% to be Unblocked: " + percentagezsm + "%" + Environment.NewLine + "Status: Approved by Division Head" + Environment.NewLine + Environment.NewLine + "In case of any queries please write to me or Ankur." + Environment.NewLine;
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
            mail.Subject = "AutoReply Fixit:- Your Unblocking List has been Approved ";
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
            try{
            smtpClient.Send(mail);
             }
                   catch
                   {
                   }
            //SqlDataReader read = cmdt.ExecuteReader();
            //var logintbl = new DataTable();
            //logintbl.Load(read);
            //if (logintbl.Rows.Count > 0)
            //{
            //    TableRow lgtbrw1 = new TableRow();
            //    for (int i = 0; i < logintbl.Rows.Count; i++)
            //    {

            //        string clientEmail = logintbl.Rows[i][7].ToString();
            //        Session["clientEmail"] = clientEmail;
            //        string ZSMname = logintbl.Rows[i][3].ToString();
            //        Session["ZSMname"] = ZSMname;
            //        string ZSMcode = logintbl.Rows[i][2].ToString();
            //        Session["ZSMcode"] = ZSMcode;
            //    }
            //}
            //SqlCommand cmdt2 = new SqlCommand("SELECT * FROM [dbo].[Approvallist$] where [ZSM CODE] = '" + id.ToString() + "';", conn);
            //SqlDataReader read2 = cmdt2.ExecuteReader();
            //var logintbl2 = new DataTable();
            //logintbl2.Load(read2);
            //if (logintbl2.Rows.Count > 0)
            //{
            //    TableRow lgtbrw12 = new TableRow();
            //    for (int i = 0; i < logintbl2.Rows.Count; i++)
            //    {

            //        string percentagezsm = logintbl2.Rows[i][6].ToString();
            //        Session["percentagezsm"] = percentagezsm;
            //    }
            //}
            //conn.Close();
            //string messageBody = "Dear " + Session["ZSMname"].ToString() + "," + Environment.NewLine + Environment.NewLine + "Hope this email finds you well. Thanks for your support, one of the pivotal initiatives taken over by the company is to reduce ‘Expiry returns (Expiry + Short Expiry+ Near Expiry + Damaged goods)’ which currently stands at levels higher than the industry average of 1.5% - 2%." + Environment.NewLine + Environment.NewLine + "Your response to the unblocking of stockiest pack combinations has been successfully sent to the Division Head for approval as the % of stockiest-pack combinations requested to be unblocked exceeds 60%." + Environment.NewLine + " We are pleased to inform you that current approval status stands: Approved by Division Head" + Environment.NewLine + Environment.NewLine + "Response Details for your ready reference:" + Environment.NewLine + Environment.NewLine + "% to be Unblocked: " + Session["percentagezsm"].ToString() + "%" + Environment.NewLine + "Status: Approved by Division Head" + Environment.NewLine + Environment.NewLine + "In case of any queries please write to me or Ankur." + Environment.NewLine;
            ////string messmob = txtmob.Text;

            //MailMessage mail = new MailMessage();
            //mail.From = new MailAddress("anjali.mishra@gcvlife.in");
            //mail.To.Add(Session["clientEmail"].ToString()); // Client's email
            ////mail.To.Add("anjali.mishra@gcvlife.in"); // Your email address
            //mail.Subject = "AutoReply Fixit:- Your Unblocking List has been Approved ";
            //mail.Body = messageBody + Environment.NewLine + "Thanks and regards," + Environment.NewLine + "Anjali Mishra | Software Developer.";


            ////  SmtpClient smtp = new SmtpClient();
            //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            //smtpClient.Host = "smtp.gmail.com"; // Set your SMTP server address
            //smtpClient.Port = 587; // Set the SMTP port (usually 587 for TLS)
            //smtpClient.Credentials = new NetworkCredential("anjali.mishra@gcvlife.in", "Anja@321");
            //smtpClient.EnableSsl = true;

            //smtpClient.Send(mail);

            BindGrid();
            Hidnfldname.Value = Session["zsmname"].ToString();
            Hidnfldcode.Value = Session["zcode"].ToString();
            Hidnfldiv.Value = Session["divi"].ToString();
            Hidnfldlogin.Value = Session["login"].ToString();
            Response.Redirect("Approvalpage.aspx");
        }
        if (e.CommandName == "btncNotApproved")
        {
            id = arg[0].ToString();
            approved = arg[3].ToString();
            SqlCommand cmd = new SqlCommand("templateps_approvalnotdone", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ZSM_CODE", id.ToString());
            cmd.Parameters.AddWithValue("@approv", approved.ToString());
            cmd.Parameters.AddWithValue("@Submittime", Submitt.ToString("MMM dd yyyy hh:mm tt"));
            conn.Open();
            //cmd.ExecuteNonQuery();
            string strRslt = cmd.ExecuteNonQuery().ToString();
            conn.Close();
            SqlCommand cmdt = new SqlCommand("SELECT * FROM [dbo].[loginID$] where ZSM_Code = '" + id.ToString() + "';", conn);
            conn.Open();
            SqlDataReader read = cmdt.ExecuteReader();
            var logintbl = new DataTable();
            logintbl.Load(read);
            if (logintbl.Rows.Count > 0)
            {
                TableRow lgtbrw1 = new TableRow();
                for (int i = 0; i < logintbl.Rows.Count; i++)
                {
                    string ZSMname = logintbl.Rows[i][3].ToString();
                    Session["ZSMname"] = ZSMname;
                    string ZSMcode = logintbl.Rows[i][2].ToString();
                    Session["ZSMcode"] = ZSMcode;
                    string clientEmail = logintbl.Rows[i][7].ToString();
                    Session["clientEmail"] = clientEmail;
                }
            }
            SqlCommand cmdt2 = new SqlCommand("SELECT * FROM [dbo].[Approvallist$] where [ZSM CODE] = '" + id.ToString() + "';", conn);
            SqlDataReader read2 = cmdt2.ExecuteReader();
            var logintbl2 = new DataTable();
            logintbl2.Load(read2);
            string percentagezsm = logintbl2.Rows[0][6].ToString();
           // Session["percentagezsm"] = percentagezsm;
            conn.Close();
            string messageBody = "Dear " + Session["ZSMname"].ToString() + "," + Environment.NewLine + Environment.NewLine + "Hope this email finds you well.Thanks for your support, one of the pivotal initiatives taken over by the company is to reduce ‘Expiry returns (Expiry + Short Expiry+ Near Expiry + Damaged goods)’ which currently stands at levels higher than the industry average of 1.5% - 2%." + Environment.NewLine + Environment.NewLine + "Your response to the unblocking of stockiest pack combinations was sent to the Division Head for approval as the % of stockiest-pack combinations requested to be unblocked exceeds 60%." + Environment.NewLine + " The current approval status stands: Rejected" + Environment.NewLine + Environment.NewLine + "Response Details for your ready reference:" + Environment.NewLine + Environment.NewLine + "% to be Unblocked: " + percentagezsm + "%" + Environment.NewLine + "Status: Rejected by Division Head" + Environment.NewLine + Environment.NewLine + "Kindly review the unblocking list and submit the response again." + Environment.NewLine + "In case of any queries please write to me or Ankur." + Environment.NewLine;
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
            mail.Subject = "AutoReply Fixit:- Your Unblocking List has been Rejected ";
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
            try{
            smtpClient.Send(mail);
             }
                   catch
                   {
                   }
            //SqlCommand cmdt = new SqlCommand("SELECT * FROM [dbo].[loginID$] where ZSM_Code = '" + id.ToString() + "';", conn);
            // conn.Open();
            //SqlDataReader read = cmdt.ExecuteReader();
            //var logintbl = new DataTable();
            //logintbl.Load(read);
            //if (logintbl.Rows.Count > 0)
            //{
            //    TableRow lgtbrw1 = new TableRow();
            //    for (int i = 0; i < logintbl.Rows.Count; i++)
            //    {

            //        string clientEmail = logintbl.Rows[i][7].ToString();
            //        Session["clientEmail"] = clientEmail;
            //        string ZSMname = logintbl.Rows[i][3].ToString();
            //        Session["ZSMname"] = ZSMname;
            //        string ZSMcode = logintbl.Rows[i][2].ToString();
            //        Session["ZSMcode"] = ZSMcode;
            //    }
            //}

            //    SqlCommand cmdt2 = new SqlCommand("SELECT * FROM [dbo].[Approvallist$] where [ZSM CODE] = '" + id.ToString() + "';", conn);
            //    SqlDataReader read2 = cmdt2.ExecuteReader();
            //     var logintbl2 = new DataTable();
            //logintbl2.Load(read2);
            //if (logintbl2.Rows.Count > 0)
            //{
            //    TableRow lgtbrw12 = new TableRow();
            //    for (int i = 0; i < logintbl2.Rows.Count; i++)
            //    {

            //        string percentagezsm = logintbl2.Rows[i][6].ToString();
            //        Session["percentagezsm"] = percentagezsm;
            //    }
            //}
            // conn.Close();
            /////////////////////////////////////////Rejected remaining 30-08-23/////////////////////////////
            // string messageBody = "Dear " + Session["ZSMname"].ToString() + "," + Environment.NewLine + Environment.NewLine + "Hope this email finds you well.Thanks for your support, one of the pivotal initiatives taken over by the company is to reduce ‘Expiry returns (Expiry + Short Expiry+ Near Expiry + Damaged goods)’ which currently stands at levels higher than the industry average of 1.5% - 2%." + Environment.NewLine + Environment.NewLine + "Your response to the unblocking of stockiest pack combinations was sent to the Division Head for approval as the % of stockiest-pack combinations requested to be unblocked exceeds 60%." + Environment.NewLine + " The current approval status stands: Rejected" + Environment.NewLine + Environment.NewLine + "Response Details for your ready reference:" + Environment.NewLine + Environment.NewLine + "% to be Unblocked: " + Session["percentagezsm"].ToString() + "%" + Environment.NewLine + "Status: Rejected by Division Head" + Environment.NewLine + Environment.NewLine + "Kindly review the unblocking list and submit the response again." + Environment.NewLine + "In case of any queries please write to me or Ankur." + Environment.NewLine;
            ////string messmob = txtmob.Text;

            //MailMessage mail = new MailMessage();
            //mail.From = new MailAddress("anjali.mishra@gcvlife.in");
            //mail.To.Add(Session["clientEmail"].ToString()); // Client's email
            ////mail.To.Add("anjali.mishra@gcvlife.in"); // Your email address
            //mail.Subject = "AutoReply Fixit:- Your Unblocking List has been Rejected ";
            //mail.Body = messageBody + Environment.NewLine + "Thanks and regards," + Environment.NewLine + "Anjali Mishra | Software Developer.";


            ////  SmtpClient smtp = new SmtpClient();
            //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            //smtpClient.Host = "smtp.gmail.com"; // Set your SMTP server address
            //smtpClient.Port = 587; // Set the SMTP port (usually 587 for TLS)
            //smtpClient.Credentials = new NetworkCredential("anjali.mishra@gcvlife.in", "Anja@321");
            //smtpClient.EnableSsl = true;

            //smtpClient.Send(mail);
            BindGrid();
            conn.Close();
            Hidnfldname.Value = Session["zsmname"].ToString();
            Hidnfldcode.Value = Session["zcode"].ToString();
            Hidnfldiv.Value = Session["divi"].ToString();
            Hidnfldlogin.Value = Session["login"].ToString();
            Response.Redirect("Approvalpage.aspx");
        } 
        if (e.CommandName == "btncview")
        {
            if (Grdrprt.Visible == false)
            {
                id = arg[0].ToString();
                approved = arg[3].ToString();
                name = arg[1].ToString();
                Session["ZSM_Name"] = name;
                Session["code"] = id;
                BindGrid2();
                lblnow.Visible = true;
                Grdrprt.Visible = true;
                
            }
            else
            {
                lblnow.Visible = false;
                Grdrprt.Visible = false;
            }
        } 
    }
    protected void Grdemp_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox Checkedboxx = (CheckBox)e.Row.FindControl("Checkedbox");
            Button btnapp = (Button)e.Row.FindControl("btnApproved");
            Button btndnt = (Button)e.Row.FindControl("btnNotApproved");
            ImageButton btnview = (ImageButton)e.Row.FindControl("btnview");
            //DataRowView dr = (DataRowView)e.Row.DataItem;
            //e.Row.Cells[4].Text = dr["Approved"].ToString();
            //string vall = string.Empty;
            //vall = (string)dr["Approved"];
            if (e.Row.Cells[7].Text == "Pending")
            {
                btnapp.Visible = true;
                btndnt.Visible = true;
                btnapp.Enabled = true;
                btndnt.Enabled = true;
                btnview.Visible = true;
                Checkedboxx.Visible = false;

            }
            if (e.Row.Cells[7].Text == "Rejected")
            {
                btnapp.Visible = false;
                btndnt.Visible = true;
                btnapp.Enabled = false;
                btndnt.Enabled = true;
                btnview.Visible = true;
                Checkedboxx.Visible = true;
                btndnt.ForeColor = System.Drawing.Color.White;
                btndnt.BackColor = System.Drawing.Color.Gray;
            }
            if (e.Row.Cells[7].Text == "AdminRejected")
            {
                btnapp.Visible = false;
                btndnt.Visible = true;
                btnapp.Enabled = true;
                btndnt.Enabled = true;
                btnview.Visible = true;
                Checkedboxx.Visible = false;
                Checkedboxx.Visible = true;
                btndnt.ForeColor = System.Drawing.Color.White;
                btndnt.BackColor = System.Drawing.Color.Gray;
            }
            if (e.Row.Cells[7].Text == "Approved")
            {
                btndnt.Visible = false;
                btnapp.Visible = true;
                btnapp.Enabled = false;
                btndnt.Enabled = false;
                Checkedboxx.Visible = true;
                btnview.Visible = true;
                btnapp.ForeColor = System.Drawing.Color.White;
                btnapp.BackColor = System.Drawing.Color.Gray;
            }
        }

    }
    public void BindGrid2()
    {

        DataSet DsStockistt = new DataSet();
        DataTable dtDsStockistt = new DataTable();
        string StrQrryy = "";
        StrQrryy = "Select distinct [SALES_DIVISION],[ZSM CODE],[ZSM NAME],[Territory Code],[Territory Name],[SALES_GCV_ACC_CODE],[SALES_ACC_NAME],[SALES_ProdID],[SALES_PROD_NAME],[SALES_2023-05],[SALES_2023-06],[SALES_2023-07],[CLO_2023_07],[CLO_Unit_07],[AVG_SEC_JUL23],[Unblock],[Brands],[Tag], [Liquidation], [ReasonUnblock]  from dbo.[Templateconsolidate] where [ZSM CODE] = '" + Session["code"] + "' and Approved = '" + Session["Approvedview"] + "'union all Select distinct [SALES_DIVISION],[ZSM CODE],[ZSM NAME],[Territory Code],[Territory Name],[SALES_GCV_ACC_CODE],[SALES_ACC_NAME],[SALES_ProdID],[SALES_PROD_NAME],[SALES_2023-06],[SALES_2023-07],[SALES_2023-08],[CLO_2023_08],[CLO_Unit_08],Round([AVG_SEC_AUG23], 0),('Blocked'),[Brands],[Tag],('Not Requested'),('Not Requested') from dbo.[TemplateData] where [ZSM CODE] = '" + Session["code"] + "' and SALES_UNIQUEKEY not in (Select distinct (SALES_ProdID + SALES_GCV_ACC_CODE) as SALES_UNIQUEKEY from dbo.[Templateconsolidate]where [ZSM CODE] = '" + Session["code"] + "' and Approved = '" + Session["Approvedview"] + "');";
        //Select distinct * from dbo.[Templateconsolidate] where [ZSM CODE] = '" + Session["code"] + "' and Approved = '" + Session["Approvedview"] + "';";
        lblnow.Text = "Unblocking/Blocking List of " + Session["ZSM_Name"];
        // Lblcount.Text = " Unblocked " + Session["count"] + " from " + Session["countrows"] +" ";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrryy, conn);
        adpRpt.Fill(DsStockistt, "DsStockistt");
        adpRpt.Fill(dtDsStockistt);


        if (DsStockistt.Tables[0].Rows.Count > 0)
        {
            Grdrprt.DataSource = dtDsStockistt;
            Grdrprt.DataBind();
        }
        else
        {
            dtDsStockistt.Rows.Add(dtDsStockistt.NewRow());
            Grdrprt.DataSource = dtDsStockistt;
            Grdrprt.DataBind();
            Grdrprt.Rows[0].Visible = false;
        }
        lblnow.Visible = true;
        //  btnsubmit.Visible = true;
        Grdrprt.Visible = true;
        //Lblrows.Visible = false;
        // Lblnote.Visible = false;
    }

}

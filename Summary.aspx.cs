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


public partial class Summary : System.Web.UI.Page
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
            binddropdown2();
            binddropdown4();
            binddropdown3();
            btndisapp.Visible = false;
        }
    }
    protected void ddlreport_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["zsmname"] = Hidnfldname.Value.ToString();
        Session["zcode"] = Hidnfldcode.Value.ToString();
        Session["divi"] = Hidnfldiv.Value.ToString();
        Session["login"] = Hidnfldlogin.Value.ToString();
        string ddlvalrep = string.Empty;
        ddlvalrep = ddlreports.SelectedValue.ToString();
        if (ddlvalrep == "btnreprt")
        {
            Response.Redirect("Fixitreports.aspx");
        }
        if (ddlvalrep == "sumaryreport")
        {
            Response.Redirect("overallsumar.aspx");
        }
        
        Session["ddlsesrep"] = ddlvalrep;
        //Response.Redirect("Fixitreports.aspx");
    }
    public void binddropdown4()
    {
        DataSet DsStockist222 = new DataSet();
        DataTable dtDsStockist222 = new DataTable();
        string StrQrry222 = "";
        StrQrry222 = "Select distinct Brands from [dbo].[Templateconsolidate] ;";

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

        StrQrry = "SELECT [NOTIFICATION], Max([Time]) as Time from [dbo].[Notification$] where [NOTIFICATION] not like 'You have Changed your Password to %' group by [DIVISION] , [ZSM CODE] ,[NOTIFICATION] ORDER BY [Time] DESC;";
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
    public void binddropdown3()
    {
        DataSet DsStockist222 = new DataSet();
        DataTable dtDsStockist222 = new DataTable();
        string StrQrry222 = "";
        StrQrry222 = "Select distinct Tag from [dbo].[Templateconsolidate] ;";

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
    protected void btntemp(object sender, EventArgs e)
    {
        Hidnfldname.Value = Session["zsmname"].ToString();
        Hidnfldcode.Value = Session["zcode"].ToString();
        Hidnfldiv.Value = Session["divi"].ToString();
        Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("Templatesadmin.aspx");
    }
    //protected void btnsettng(object sender, EventArgs e)
    //{
    //  //  Response.Redirect("settings.aspx");
    //}
    protected void ddldiv_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddldiv = string.Empty;
        ddldiv = ddldivname.SelectedValue.ToString();
        Session["ddldiv"] = ddldiv;
        Lblwh.Text = ddldivname.SelectedItem.ToString();
        binddropdown1();
        Grdrprt.Visible = false;
        lblnow.Visible = false;
        BindGrid3();
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
    protected void ddlpercent_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlper = string.Empty;
        ddlper = ddlpercent.SelectedValue.ToString();
        Session["ddlpercent"] = ddlper;
        Lblwh.Text = ddlpercent.SelectedItem.ToString();

        BindGridper();
        Grdrprt.Visible = false;
        lblnow.Visible = false;
    }
        public void BindGrid9()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "Select * from Approvallist$ where ZSM_Name in (Select distinct [ZSM NAME] from [dbo].[Templateconsolidate] where [Brands] = '" + Session["brnd"] + "');";
        Lblwh.Text = "Approval Request";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        //Lbldetail.Text = "Employee Code : " + Hidnfldcode.Value.ToString() + "<br />" + "Division : " + Hidnfldiv.Value.ToString() + "";
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
             lblnow.Text = "NO DATA";
                  lblnow.Visible = true;
        }

    }
        public void BindGrid10()
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select * from Approvallist$ where ZSM_Name in (Select distinct [ZSM NAME] from [dbo].[Templateconsolidate] where [Tag] = '" + Session["tag"] + "');";
            Lblwh.Text = "Approval Request";
            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);

            Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
           // Lbldetail.Text = "Employee Code : " + Hidnfldcode.Value.ToString() ;
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
                 lblnow.Text = "NO DATA";
                  lblnow.Visible = true;
            }

        }
    public void binddropdown2()
    {
        DataSet DsStockistt = new DataSet();
        DataTable dtDsStockistt = new DataTable();
        string StrQrryy = "";
        try
        {
            decimal sess = Decimal.Parse(Session["ddlpercent"].ToString());  
        if (sess == 49)
        {
            StrQrryy = "Select distinct Division from [dbo].[Approvallist$] where [Unblocked Percentage] <= " + Session["ddlpercent"] + ";";
        }
        if (sess >= 50)
        {
            StrQrryy = "Select distinct Division from [dbo].[Approvallist$] where [Unblocked Percentage] >= " + Session["ddlpercent"] + " ;";
        }
        }
         catch (Exception ex)
        {
            StrQrryy = "Select distinct Division from [dbo].[Approvallist$];";
        }  
        //else
        //{
        //    StrQrryy = "Select distinct Division from [dbo].[Approvallist$];";
        //}
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRptt = new SqlDataAdapter(StrQrryy, conn);
        adpRptt.Fill(DsStockistt, "DsStockistt");
        adpRptt.Fill(dtDsStockistt);
        if (DsStockistt.Tables[0].Rows.Count > 0)
        {
            ddldivname.DataSource = dtDsStockistt;
            ddldivname.DataTextField = "Division";
            ddldivname.DataBind();
            ddldivname.Items.Insert(0, "Select");
            //ddldivname.SelectedIndex = 0;
        }
        else
        {
            string nodata = string.Empty;
            nodata = "NO DATA";
            nodata = ddldivname.Text; 
        }
        binddropdown1();
    }
      public void binddropdown1()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        try
        {
            decimal sess = Decimal.Parse(Session["ddlpercent"].ToString());
            if (sess == 49)
            {
                StrQrry = "Select distinct ZSM_Name from [dbo].[Approvallist$] where [Approved] = 'Approved' and  [Unblocked Percentage] <= " + Session["ddlpercent"] + " and Division = '" + Session["ddldiv"] + "';";
            }
            if (sess >= 50)
            {

                StrQrry = "Select distinct ZSM_Name from [dbo].[Approvallist$] where [Approved] = 'Approved' and  [Unblocked Percentage] >= " + Session["ddlpercent"] + " and Division = '" + Session["ddldiv"] + "';";
            }
        }
        catch (Exception ex)
        {
            StrQrry = "Select distinct ZSM_Name from [dbo].[Approvallist$] where [Approved] = 'Approved' and  Division = '" + Session["ddldiv"] + "';";
        }
        //else
        //{
        //    StrQrry = "Select distinct ZSM_Name from [dbo].[Approvallist$] where  Division = '" + Session["ddldiv"] + "';";
        //}
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
        if (DsStockist.Tables[0].Rows.Count == 0)
        {
            string nodata = string.Empty;
            nodata = "NO DATA";
            nodata = ddlempname.Text; 
        }

    }
    protected void ddlemp_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlemp = string.Empty;
        ddlemp = ddlempname.SelectedValue.ToString();
        Session["ddlemp"] = ddlemp;
        Lblwh.Text = ddlempname.SelectedItem.ToString();
        BindGrid4();
        Grdrprt.Visible = false;
        lblnow.Visible = false;
    }
    public void BindGrid()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
       string admin = string.Empty;
       admin = ""+ Session["zcode"];
        string StrQrry = "";
        if (admin == "Admin" || admin == "90248986" || admin == "90038190")
            {
                StrQrry = "Select distinct * from [dbo].[Approvallist$] where [Approved] = 'Approved' and  [Unblocked Percentage] >= 70;";
        }
         //else
        //{
       //    StrQrry = "Select distinct * from [dbo].[Approvallist$] where [ZSM CODE] = '" + Session["zcode"] + "';";
      //}
        Lblwh.Text = "Approval Request Summary";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
    //  Lbldetail.Text = "Division : " + Session["divi"] + "";
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
            lblnow.Text = "NO ZSM's with more than 70% approval";
            lblnow.Visible = true;
        }

    }
     public void BindGridper()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
       string admin = string.Empty;
       admin = ""+ Session["zcode"];
        string StrQrry = "";
        decimal sess = Decimal.Parse(Session["ddlpercent"].ToString());
        if (sess == 49)
        {
            StrQrry = "Select distinct * from [dbo].[Approvallist$] where [Approved] = 'Approved' and  [Unblocked Percentage] <= " + Session["ddlpercent"] + " ;";
        }
        if (sess >= 50)
        {
            StrQrry = "Select distinct * from [dbo].[Approvallist$] where [Approved] = 'Approved' and  [Unblocked Percentage] >= " + Session["ddlpercent"] + ";";
        }

        //else
        //{
        //    StrQrry = "Select distinct * from [dbo].[Approvallist$] where [ZSM CODE] = '" + Session["zcode"] + "';";
        //}
        Lblwh.Text = "Approval Request Summary";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
    //    Lbldetail.Text = "Division : " + Session["divi"] + "";
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
            lblnow.Text = "NO ZSM's with more than " + Session["ddlpercent"] + " approval";
            lblnow.Visible = true;
        }
        binddropdown2();
        binddropdown1();
    }
    public void BindGrid3()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "Select distinct * from [dbo].[Approvallist$] where [Approved] = 'Approved' and [Unblocked Percentage] <= " + Session["ddlpercent"] + " and Division = '" + Session["ddldiv"] + "';";
        Lblwh.Text = "Approval Request";
        
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
     
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
            lblnow.Text = "NO ZSM's of " + Session["ddldiv"] + " with more than 70% approval";
            lblnow.Visible = true;
        }

    }
    public void BindGrid4()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "Select distinct * from [dbo].[Approvallist$] where ZSM_Name = '" + Session["ddlemp"] + "';";
        Lblwh.Text = "Approval Request";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
   
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
            lblnow.Text = "NO DATA";
            lblnow.Visible = true;
        }

    }
    //protected void ddlmaster_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string ddlval = string.Empty;
    //    ddlval = ddlmasters.SelectedValue.ToString();
    //    Session["ddlses"] = ddlval;
    //    Lblwh.Text = ddlmasters.SelectedItem.ToString();
    //    //  BindGrid2();
    //}
    protected void changed(object sender, EventArgs e)
    {
        CheckBox chckstatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chckstatus.NamingContainer;
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
            conn.Open();
            //cmd.ExecuteNonQuery();
            string strRslt = cmd.ExecuteNonQuery().ToString();
            conn.Close();
           // BindGridper();
            Hidnfldname.Value = Session["zsmname"].ToString();
            Hidnfldcode.Value = Session["zcode"].ToString();
            Hidnfldiv.Value = Session["divi"].ToString();
            Hidnfldlogin.Value = Session["login"].ToString();
           Response.Redirect("Summary.aspx");
        }
        if (e.CommandName == "btncNotApproved")
        {
            

            id = arg[0].ToString();
            approved = arg[3].ToString();
            SqlCommand cmd = new SqlCommand("templateps_approvalnotdoneadmin", conn);
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

                    string clientEmail = logintbl.Rows[i][7].ToString();
                    Session["clientEmail"] = clientEmail;
                    string ZSMname = logintbl.Rows[i][3].ToString();
                    Session["ZSMname"] = ZSMname;
                    string ZSMcode = logintbl.Rows[i][2].ToString();
                    Session["ZSMcode"] = ZSMcode;
                }
            }
            SqlCommand cmdt2 = new SqlCommand("SELECT * FROM [dbo].[Approvallist$] where [ZSM CODE] = '" + id.ToString() + "';", conn);
            SqlDataReader read2 = cmdt2.ExecuteReader();
            var logintbl2 = new DataTable();
            logintbl2.Load(read2);
           // if (logintbl2.Rows.Count > 0)
           // {
           //     TableRow lgtbrw12 = new TableRow();
           //     for (int i = 0; i < logintbl2.Rows.Count; i++)
           //     {
            string divzsm = logintbl2.Rows[0][0].ToString();
            Session["divzsm"] = divzsm;
              string percentagezsm = logintbl2.Rows[0][6].ToString();
                 Session["percentagezsm"] = percentagezsm;
           //     }
           // }
                 conn.Close();
                 string messageBody = "Dear " + Session["ZSMname"].ToString() + "," + Environment.NewLine + Environment.NewLine + "Hope this email finds you well.Thanks for your support, one of the pivotal initiatives taken over by the company is to reduce ‘Expiry returns (Expiry + Short Expiry+ Near Expiry + Damaged goods)’ which currently stands at levels higher than the industry average of 1.5% - 2%." + Environment.NewLine + Environment.NewLine + "Your response to the unblocking of stockiest pack combinations was sent to the Distribution Head for approval as the % of stockiest-pack combinations requested to be unblocked exceeds 60%." + Environment.NewLine + " The current approval status stands: Admin Rejected" + Environment.NewLine + Environment.NewLine + "Response Details for your ready reference:" + Environment.NewLine + Environment.NewLine + "% to be Unblocked: " + percentagezsm + "%" + Environment.NewLine + "Status: Rejected by Distribution Head" + Environment.NewLine + Environment.NewLine + "Kindly review the unblocking list and submit the response again." + Environment.NewLine + "In case of any queries please write to me or Ankur." + Environment.NewLine;
           // //string messmob = txtmob.Text;
          SqlCommand cmdemail = new SqlCommand("select top (1)* from PortforEmail;", conn);
          conn.Open();
          SqlDataReader reademail = cmdemail.ExecuteReader();
          var readl = new DataTable();
          readl.Load(reademail);
          string smtpclnt = readl.Rows[0][1].ToString();
          //    Session["smtpclnt"] = smtpclnt;
          string smtphost = readl.Rows[0][2].ToString();
          //   Session["smtphost"] = smtphost;
          string smtpnoport = readl.Rows[0][3].ToString();
          //   Session["smtpnoport"] = smtpnoport;
          string emailusername = readl.Rows[0][4].ToString();
          //   Session["emailusername"] = emailusername;
          string emailuserpass = readl.Rows[0][5].ToString();
          //   Session["emailuserpass"] = emailuserpass;
          string smtpenable = readl.Rows[0][6].ToString();
          //   Session["smtpenable"] = smtpenable;
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
try
{
          smtpClient.Send(mail);
             }
                   catch
                   {
                   }
           // MailMessage mail = new MailMessage();
           // mail.From = new MailAddress("anjali.mishra@gcvlife.in");
           // mail.To.Add(Session["clientEmail"].ToString()); // Client's email
           // //mail.To.Add("anjali.mishra@gcvlife.in"); // Your email address
           // mail.Subject = "AutoReply Fixit:- Your Unblocking List has been Rejected ";
           // mail.Body = messageBody + Environment.NewLine + "Thanks and regards," + Environment.NewLine + "Anjali Mishra | Software Developer.";


           // //  SmtpClient smtp = new SmtpClient();
           // SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
           // smtpClient.Host = "smtp.gmail.com"; // Set your SMTP server address
           // smtpClient.Port = 587; // Set the SMTP port (usually 587 for TLS)
           // smtpClient.Credentials = new NetworkCredential("anjali.mishra@gcvlife.in", "Anja@321");
           // smtpClient.EnableSsl = true;

           // smtpClient.Send(mail);
           //// BindGridper();
           // // Optionally, provide feedback to the user

           // if (logintbl.Rows.Count > 0)
           // {
           //     TableRow lgtbrw1 = new TableRow();
           //     for (int i = 0; i < logintbl.Rows.Count; i++)
           //     {

           //         string clientEmailcc = logintbl.Rows[i][8].ToString();
           //         Session["clientEmailcc"] = clientEmailcc;
           //     }
           // }
           string Sy = "";
           // ///////////////////////////////////////////////////////////write submitted mail------------------------------------------------start from here 29-08-23
         //  Sy = "SELECT * FROM [dbo].[loginID$] where Division = '" + Hidnfldiv.Value.ToString() + "' and Username like 'DH%';";
           // string connnn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
           // SqlDataAdapter adpt = new SqlDataAdapter(Sy, connnn);
           // DataTable dataTable = new DataTable();
           // adpt.Fill(dataTable);
           // string dhcode = dataTable.Rows[0][2].ToString();
           // string dhname = dataTable.Rows[0][3].ToString();
           // string dhpass = dataTable.Rows[0][4].ToString();
           // string dhemail = dataTable.Rows[0][7].ToString();
           // MailMessage mailtoclient = new MailMessage();
           // mailtoclient.From = new MailAddress("anjali.mishra@gcvlife.in"); // Client's email
           // //  mail.From = new MailAddress("anjali.mishra@gcvlife.in");
           // mailtoclient.To.Add(Session["clientEmailcc"].ToString()); // Your email address
           // mailtoclient.Subject = "AutoReply Fixit:- Admin has Rejected " + Hidnfldname.Value.ToString() + "'s Unblocking List";
           // mailtoclient.Body = "Dear " + dhname + "," + Environment.NewLine + Environment.NewLine + "Thanks for your support to one of the pivotal initiatives taken over by the company is to reduce 'Expiry returns (Expiry + Short Expiry+ Near Expiry + Damaged goods)' which currently stands at levels higher than the industry average of 1.5% - 2%." + Environment.NewLine + "The unblocking list of " + Hidnfldname.Value.ToString() + " has been Rejected by Distribution Head, as the percentage of stockiest-pack combinations requested to be unblocked by this ZSM surpasses 60%." + Environment.NewLine + Environment.NewLine + Environment.NewLine + " The current approval status stands: Admin Rejected" + Environment.NewLine + Environment.NewLine + "Response Details for your ready reference:" + Environment.NewLine + Environment.NewLine + "% to be Unblocked: " + Session["percentagezsm"].ToString() + "%" + Environment.NewLine + "Status: Rejected by Distribution Head." + Environment.NewLine + Environment.NewLine + "Thanks and regards," + Environment.NewLine + "Anjali Mishra | Software Developer.";
          ///////////////////////////////////////////////////////////write submitted mail------------------------------------------------start from here 29-08-23
           Sy = "SELECT * FROM [dbo].[loginID$] where Division = '" + divzsm + "' and Username like 'DH%';";
          string connnn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
          SqlDataAdapter adpt = new SqlDataAdapter(Sy, connnn);
          DataTable dataTable = new DataTable();
          adpt.Fill(dataTable);
          string dhcode = dataTable.Rows[0][2].ToString();
          string dhname = dataTable.Rows[0][3].ToString();
          string dhpass = dataTable.Rows[0][4].ToString();
          string dhemail = dataTable.Rows[0][7].ToString();
          MailMessage mailtoclient = new MailMessage();
          mailtoclient.From = new MailAddress(emailusername); // Client's email
          //  mail.From = new MailAddress("anjali.mishra@gcvlife.in");
          mailtoclient.To.Add(dhemail); // Your email address
          mailtoclient.Subject = "AutoReply Fixit:- Admin has Rejected " + Session["ZSMname"].ToString() + "'s Unblocking List";
          mailtoclient.Body = "Dear " + dhname + "," + Environment.NewLine + Environment.NewLine + "Thanks for your support to one of the pivotal initiatives taken over by the company is to reduce 'Expiry returns (Expiry + Short Expiry+ Near Expiry + Damaged goods)' which currently stands at levels higher than the industry average of 1.5% - 2%." + Environment.NewLine + "The unblocking list of " + Session["ZSMname"].ToString() + " has been Rejected by Distribution Head, as the percentage of stockiest-pack combinations requested to be unblocked by this ZSM surpasses 60%." + Environment.NewLine + Environment.NewLine + Environment.NewLine + " The current approval status stands: Admin Rejected" + Environment.NewLine + Environment.NewLine + "Response Details for your ready reference:" + Environment.NewLine + Environment.NewLine + "% to be Unblocked: " + percentagezsm + "%" + Environment.NewLine + "Status: Rejected by Distribution Head." + Environment.NewLine + Environment.NewLine + "Thanks and regards," + Environment.NewLine + "Anjali Mishra | Software Developer.";

          SmtpClient smtpClientfromus = new SmtpClient(smtpclnt);
          smtpClientfromus.Host = smtphost; // Set your SMTP server address
          smtpClientfromus.Port = intValueportno; // Set the SMTP port (usually 587 for TLS)
          smtpClientfromus.Credentials = new NetworkCredential(emailusername, emailuserpass);
          smtpClientfromus.EnableSsl = boolValenable;
            try
            {
          smtpClientfromus.Send(mailtoclient);
             }
                   catch
                   {
                   }
            Hidnfldname.Value = Session["zsmname"].ToString();
            Hidnfldcode.Value = Session["zcode"].ToString();
            Hidnfldiv.Value = Session["divi"].ToString();
            Hidnfldlogin.Value = Session["login"].ToString();
            Response.Redirect("Summary.aspx");
        }
        if (e.CommandName == "btncview")
        {

            approved = arg[3].ToString();
            id = arg[0].ToString();
             name = arg[1].ToString();
             Session["approved"] = approved;
            Session["ZSMNAME"] = name;
            Session["code"] = id;
            BindGrid2();
            btndisapp.Visible = true;
        } 
    }
    protected void Grdemp_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox Checkedboxx = (CheckBox)e.Row.FindControl("Checkedbox");
            Button btnapp = (Button)e.Row.FindControl("btnApproved");
            Button btndnt = (Button)e.Row.FindControl("btnNotApproved");
         //   GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
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
                Checkedboxx.Visible = true;
                btnapp.Visible = false;
                btndnt.Visible = true;
                btnapp.Enabled = true;
                btndnt.Enabled = true;
                btnview.Visible = true;
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
                Checkedboxx.Visible = true;
                btndnt.ForeColor = System.Drawing.Color.White;
                btndnt.BackColor = System.Drawing.Color.Gray;
            }
            if (e.Row.Cells[7].Text == "Approved")
            {
                btnapp.Visible = false;
                btndnt.Visible = true;
                btnapp.Enabled = true;
                btndnt.Enabled = true;
                btnview.Visible = true;
                Checkedboxx.Visible = false;
                //btndnt.Visible = false;
                //btnapp.Visible = true;
                //btnapp.Enabled = false;
                //btndnt.Enabled = false;
                //Checkedboxx.Visible = true;
                //btnview.Visible = true;
                //btnapp.ForeColor = System.Drawing.Color.White;
                //btnapp.BackColor = System.Drawing.Color.Gray;
            }
        }

    }
    //protected void btnmaster(object sender, EventArgs e)
    //{
    //    Response.Redirect("Fixitmasters.aspx");
    //}
    protected void btnnotific(object sender, EventArgs e)
    {
        Hidnfldname.Value = Session["zsmname"].ToString();
        Hidnfldcode.Value = Session["zcode"].ToString();
        Hidnfldiv.Value = Session["divi"].ToString();
        Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("NotificationAdmin.aspx");
    }
    protected void Grdemp_NEERowdatabound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            conn.Open();
            DropDownList DropDownList2 = (e.Row.FindControl("ddlblock") as DropDownList);
            SqlCommand cmd1 = new SqlCommand("Select * from BlockAdmin;", conn);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            conn.Close();
            DropDownList2.DataSource = dt1;

            DropDownList2.DataTextField = "Block";
            DropDownList2.DataValueField = "Block";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Unblock", "0"));
        }
    }
    protected void btndisapp_Click(object sender, EventArgs e)
    {

        var checkedbox = 0;
        var count = 0;
        foreach (GridViewRow row in Grdrprt.Rows)
        {
            count++;
            DropDownList chckhrw = (DropDownList)row.FindControl("ddlblock");
            if (chckhrw.SelectedValue == "Admin Block")
            {

                checkedbox++;
                string namevalue0 = row.Cells[0].Text;
                namevalue0 = namevalue0.Replace("&nbsp;", string.Empty).Replace("&#39;", "'").Replace("&#160;", "  ").Replace("'", "%").ToString();
                string namevalue1 = row.Cells[1].Text;
                namevalue1 = namevalue1.Replace("&nbsp;", string.Empty).Replace("&#39;", "'").Replace("&#160;", "  ").Replace("'", "%").ToString();
                string namevalue2 = row.Cells[2].Text;
                namevalue2 = namevalue2.Replace("&nbsp;", string.Empty).Replace("&#39;", "'").Replace("&#160;", "  ").Replace("'", "%").ToString();
                DropDownList ddlblock = (DropDownList)row.FindControl("ddlblock");
                string ddlunb = ddlblock.SelectedValue;
                string adminblock = string.Empty;
                adminblock = "Adminblock";
                DateTime Submitt = DateTime.Now;
                DataSet Dsvals = new DataSet();
                DataTable dtDsvals = new DataTable();
                string Svals = "";
                Svals = "Select Distinct [SALES_DIVISION], [ZSM CODE],[ZSM NAME],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME],Round([SALES_2023-05], 0) as [SALES_2023-05],Round([SALES_2023-06], 0) as [SALES_2023-06], Round([SALES_2023-07], 0) as [SALES_2023-07],Round([AVG_SEC_JUL23], 0) as [AVG_SEC_JUL23],Round([CLO_2023_07], 0) as [CLO_2023_07], Round([CLO_Unit_07], 0) as [CLO_Unit_07] FROM [dbo].[Templateconsolidate] where [ZSM CODE] =  '" + Session["code"].ToString() + "' and  [Territory Name]='" + namevalue0.Replace("&amp;", "&") + "' and [SALES_ACC_NAME]='" + namevalue1.Replace("&amp;", "&") + "' and [SALES_PROD_NAME] like'" + namevalue2.Replace("'", "''").Replace("&amp;", "&") + "%' and [Approved] = '" +Session["approved"].ToString() + "';";
                SqlDataAdapter adpRpt13 = new SqlDataAdapter(Svals, conn);
                adpRpt13.Fill(Dsvals, "dtDsvals");
                adpRpt13.Fill(dtDsvals);
                string Accid = dtDsvals.Rows[0][5].ToString();
                namevalue1 = namevalue1.Replace("&amp;", "&").Replace("&#160;", "  ").Replace("'", "%");
                string terrid = dtDsvals.Rows[0][3].ToString();
                namevalue0 = namevalue0.Replace("&amp;", "&").Replace("&#160;", "  ").Replace("'", "%");
                string Prodid = dtDsvals.Rows[0][7].ToString();
                namevalue2 = namevalue2.Replace("&amp;", "&").Replace("&#160;", "  ").Replace("'", "%");
                SqlCommand cmd1 = new SqlCommand("adminblock_ps", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@SALES_DIVISION", Hidnfldiv.Value.ToString());
                cmd1.Parameters.AddWithValue("@ZSM_CODE",  Session["code"].ToString());
                cmd1.Parameters.AddWithValue("@ZSM_NAME", Session["ZSMNAME"].ToString());
                cmd1.Parameters.AddWithValue("@Territory_Code", terrid);
                cmd1.Parameters.AddWithValue("@SALES_GCV_ACC_CODE", Accid);
                cmd1.Parameters.AddWithValue("@SALES_ProdID", Prodid);
                 cmd1.Parameters.AddWithValue("@Unblock", ddlunb.ToString());
                cmd1.Parameters.AddWithValue("@Approved", adminblock.ToString());     
                cmd1.Parameters.AddWithValue("@Submittime", Submitt.ToString("MMM dd yyyy hh:mm tt"));
                conn.Open();
                // cmd1.ExecuteNonQuery();
                string strRslt = cmd1.ExecuteNonQuery().ToString();
                conn.Close();
            
                btndisapp.Visible = false;
                Grdrprt.Visible = false;
                lblnow.Visible = false;
                BindGrid();
             
            }

        }
    }
    //protected void btnreprt(object sender, EventArgs e)
    //{
    //    Session["zsmname"] = Hidnfldname.Value.ToString();
    //    Session["zcode"] = Hidnfldcode.Value.ToString();
    //    Session["divi"] = Hidnfldiv.Value.ToString();
    //    Session["login"] = Hidnfldlogin.Value.ToString();
    //    Response.Redirect("Fixitreports.aspx");
    //}
    protected void btncontac(object sender, EventArgs e)
    {
        Hidnfldname.Value = Session["zsmname"].ToString();
        Hidnfldcode.Value = Session["zcode"].ToString();
        Hidnfldiv.Value = Session["divi"].ToString();
        Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("ContactAdmin.aspx");
    }
    public void BindGrid2()
    {

        DataSet DsStockistt = new DataSet();
        DataTable dtDsStockistt = new DataTable();
        string StrQrryy = "";

        StrQrryy = "Select distinct * from dbo.[Templateconsolidate] where [ZSM CODE]  = '" + Session["code"] + "' and Approved = '" + Session["approved"] + "';";
        lblnow.Text = "Unblocking List of " + Session["ZSMNAME"];
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
            lblnow.Text = "NO DATA";
            lblnow.Visible = true;
        }

      //  btnsubmit.Visible = true;
        Grdrprt.Visible = true;
        //Lblrows.Visible = false;
        // Lblnote.Visible = false;
    }
}
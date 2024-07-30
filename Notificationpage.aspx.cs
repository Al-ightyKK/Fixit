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
using System.Drawing;
using System.Windows.Forms;

public partial class Notificationpage : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Response.AppendHeader("Refresh", "30");
            Hidnfldname.Value = Session["zsmname"].ToString();
            Hidnfldcode.Value = Session["zcode"].ToString();
            Hidnfldiv.Value = Session["divi"].ToString();
            Hidnfldlogin.Value = Session["login"].ToString();
            Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
           
            Lbldetail.Text = "Employee Code : " + Hidnfldcode.Value.ToString() + "<br />" + "Division : " + Hidnfldiv.Value.ToString() + "";
           // BindGrid();
            ////DataSet DsScount1 = new DataSet();
            ////DataTable dtDsScount1 = new DataTable();
            ////string Scounty1 = "";
            ////Scounty1 = "SELECT Division FROM [dbo].[Approvallist$] ; ";
            ////SqlDataAdapter adpRpt11 = new SqlDataAdapter(Scounty1, conn);
            ////adpRpt11.Fill(DsScount1, "dtDsScount1");
            ////adpRpt11.Fill(dtDsScount1);
            ////if (dtDsScount1.Rows.Count <= 0)
            ////{
            ////    lblcount.Text = "SUBMITTED COUNT OF ZSM's 0";
            ////}
            ////else
            ////{
            ////    lblcount.Text = "SUBMITTED COUNT OF ZSM's " + dtDsScount1.Rows.Count.ToString();
            ////}
            //DataSet DsScount2 = new DataSet();
            //DataTable dtDsScount2 = new DataTable();
            //string Scounty2 = "";
            //Scounty2 = "SELECT Division FROM [dbo].[Approvallist$] WHERE [Approved] = 'Approved' ;";
            //SqlDataAdapter adpRpt12 = new SqlDataAdapter(Scounty2, conn);
            //adpRpt12.Fill(DsScount2, "dtDsScount2");
            //adpRpt12.Fill(dtDsScount2);
            //if (dtDsScount2.Rows.Count <= 0)
            //{
            //    lblapprvcnt.Text = "APPROVED COUNT OF ZSM's 0";
            //}
            //else
            //{
            //    lblapprvcnt.Text = "APPROVED COUNT OF ZSM's " + dtDsScount2.Rows.Count.ToString();
            //}
            DataSet DsScount3 = new DataSet();
            DataTable dtDsScount3 = new DataTable();
            string Scounty3 = "";
            Scounty3 = "SELECT Division FROM [dbo].[Approvallist$] WHERE [Approved] = 'Pending' and Division = '" + Hidnfldiv.Value.ToString() + "';";
            SqlDataAdapter adpRpt13 = new SqlDataAdapter(Scounty3, conn);
            adpRpt13.Fill(DsScount3, "dtDsScount3");
            adpRpt13.Fill(dtDsScount3);
            if (dtDsScount3.Rows.Count <= 0)
            {
                //lblpndincnt.Text = "PENDING COUNT OF ZSM's 0";
                BindGrid1();
            }
            else
            {
               // lblpndincnt.Text = "PENDING COUNT OF ZSM's " + dtDsScount3.Rows.Count.ToString();
                BindGrid();
            }
            //DataSet DsScount4 = new DataSet();
            //DataTable dtDsScount4 = new DataTable();
            //string Scounty4 = "";
            //Scounty4 = "SELECT Division FROM [dbo].[Approvallist$] WHERE [Approved] = 'Rejected' ; ";
            //SqlDataAdapter adpRpt14 = new SqlDataAdapter(Scounty4, conn);
            //adpRpt14.Fill(DsScount4, "dtDsScount4");
            //adpRpt14.Fill(dtDsScount4);
            //if (dtDsScount4.Rows.Count <= 0)
            //{
            //    lblrejnt.Text = "REJECTED COUNT OF ZSM's 0";
            //}
            //else
            //{
            //    lblrejnt.Text = "REJECTED COUNT OF ZSM's " + dtDsScount4.Rows.Count.ToString();
            //}
            //DataSet DsScount5 = new DataSet();
            //DataTable dtDsScount5 = new DataTable();
            //string Scounty5 = "";
            //Scounty5 = "SELECT Division FROM [dbo].[Approvallist$] WHERE [Approved] = 'AdminRejected' ;";
            //SqlDataAdapter adpRpt15 = new SqlDataAdapter(Scounty5, conn);
            //adpRpt15.Fill(DsScount5, "dtDsScount5");
            //adpRpt15.Fill(dtDsScount5);
            //if (dtDsScount5.Rows.Count <= 0)
            //{
            //    lbladrejcnt.Text = "ADMIN REJECTED COUNT OF ZSM's 0";
            //}
            //else
            //{
            //    lbladrejcnt.Text = "ADMIN REJECTED COUNT OF ZSM's " + dtDsScount5.Rows.Count.ToString();
            //}
        }
    }
  
    public void BindGrid()
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

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";

        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            notific.DataSource = dtDsStockist;
            notific.Columns[1].Visible = true;
            notific.DataBind();
        }
        else
        {
            dtDsStockist.Rows.Add(dtDsStockist.NewRow());
            notific.DataSource = dtDsStockist;
            notific.DataBind();
            notific.Columns[1].Visible = true;
            lblnow.Text = "NO DATA";
            lblnow.Visible = true;
        }

    }
    public void BindGrid1()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "SELECT [DIVISION],[NOTIFICATION], max([Time]) as Time from [dbo].[Notification$] where (([NOTIFICATION] like '%with approval%' or [NOTIFICATION] like '%Submitted%' or [NOTIFICATION] like '%Approved By Division%'or [NOTIFICATION] like '%Rejected By Division%' or [NOTIFICATION] like '%Rejected By Admin%') and [DIVISION] = '" + Hidnfldiv.Value.ToString() + "') or [ZSM CODE] = '" + Hidnfldcode.Value.ToString() + "' group by [DIVISION] , [NOTIFICATION]  ORDER BY [Time] DESC;";
        //     Lblwh.Text = "Approval Request";where [Unblocked Percentage] <= " + Session["ddlpercent"] + " and Division = '" + Session["ddldiv"] + "'

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";

        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            notific.DataSource = dtDsStockist;
            notific.Columns[1].Visible = true;
            notific.DataBind();
        }
        else
        {
            dtDsStockist.Rows.Add(dtDsStockist.NewRow());
            notific.DataSource = dtDsStockist;
            notific.DataBind();
            notific.Rows[1].Visible = false;
            lblnow.Text = "NO DATA";
            lblnow.Visible = true;
        }

    }
    protected void btnconta(object sender, EventArgs e)
    {
        Session["zsmname"] = Hidnfldname.Value.ToString();
        Session["zcode"] = Hidnfldcode.Value.ToString();
        Session["divi"] = Hidnfldiv.Value.ToString();
        Session["login"] = Hidnfldlogin.Value.ToString();
        Response.Redirect("ContactDH.aspx");
    }
    protected void btntemp(object sender, EventArgs e)
    {
        Session["zsmname"] = Hidnfldname.Value.ToString();
        Session["zcode"] = Hidnfldcode.Value.ToString();
        Session["divi"] = Hidnfldiv.Value.ToString();
        Session["login"] = Hidnfldlogin.Value.ToString();
        Response.Redirect("TemplatesBh.aspx");
    }
    protected void btnhmclick(object sender, EventArgs e)
    {
        Session["zsmname"] = Hidnfldname.Value.ToString();
        Session["zcode"] = Hidnfldcode.Value.ToString();
        Session["divi"] = Hidnfldiv.Value.ToString();
        Session["login"] = Hidnfldlogin.Value.ToString();
        Response.Redirect("Approvalpage.aspx");
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

    public void btncount()
    {
        DataSet DsStockistt = new DataSet();
        DataTable dtDsStockistt = new DataTable();
        string StrQrryy = "";
        StrQrryy = "SELECT * FROM [dbo].[Approvallist$];";
        lblnow.Text = "SUBMITTED ZSM's OF " + Hidnfldiv.Value.ToString();
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
        Grdrprt.Visible = true;
    }
    protected void Grdemp_rowcommand(object sender, GridViewCommandEventArgs e)
    {
        string[] arg = new string[2];
        arg = e.CommandArgument.ToString().Split(';');
        Session["DIVIS"] = arg[0];
        Session["Notification"] = arg[1];
        string div = "";
        string notification = "";
        if (e.CommandName == "btncview")
        {

            div = arg[0].ToString();
            notification = arg[1].ToString();
            Session["DIVISION"] = div;
            Session["notific"] = notification;
            if (notification.Contains("pending"))
            {
                btnpend();
            }
            if (notification.Contains("with approval"))
            {
                btnapprv();
            }
            if (notification.Contains("Rejected By Division Head"))
            {
                btnrejj();
            }
            if (notification.Contains("Rejected By Admin"))
            {
                btnadrejj();
            }
            // btncount();

        }
    }
    public void btnapprv()
    {

        DataSet DsStockistt = new DataSet();
        DataTable dtDsStockistt = new DataTable();
        string StrQrryy = "";
        StrQrryy = "SELECT * FROM [dbo].[Approvallist$] WHERE [Approved] = 'Approved' And [Division] = '" + Session["DIVISION"] + "' ;";
        lblnow.Text = "APPROVED ZSM's OF " + Session["DIVISION"];
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
        Grdrprt.Visible = true;
    }
    public void btnpend()
    {

        DataSet DsStockistt = new DataSet();
        DataTable dtDsStockistt = new DataTable();
        string StrQrryy = "";
        StrQrryy = "SELECT * FROM [dbo].[Approvallist$] WHERE [Approved] = 'Pending'And [Division] = '" + Session["DIVISION"] + "' ;";
        lblnow.Text = "PENDING ZSM's OF " + Session["DIVISION"];
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
        Grdrprt.Visible = true;
    }
    public void btnrejj()
    {
        DataSet DsStockistt = new DataSet();
        DataTable dtDsStockistt = new DataTable();
        string StrQrryy = "";
        StrQrryy = "SELECT * FROM [dbo].[Approvallist$] WHERE [Approved] = 'Rejected' And [Division] = '" + Session["DIVISION"] + "';";
        lblnow.Text = "REJECTED ZSM's OF " + Session["DIVISION"];
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
        Grdrprt.Visible = true;
    }
    protected void btnadrejj()
    {

        DataSet DsStockistt = new DataSet();
        DataTable dtDsStockistt = new DataTable();
        string StrQrryy = "";
        StrQrryy = "SELECT * FROM [dbo].[Approvallist$] WHERE [Approved] = 'AdminRejected' And [Division] = '" + Session["DIVISION"] + "' ;";
        lblnow.Text = "ADMIN REJECTED ZSM's OF " + Session["DIVISION"];
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
        Grdrprt.Visible = true;
    }
}
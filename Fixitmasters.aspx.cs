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

public partial class Fixitmasters : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    protected void changed(object sender, EventArgs e)
    {
        CheckBox chckstatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chckstatus.NamingContainer;
    }
    protected void ddlmaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlval = string.Empty;
        ddlval = ddlmasters.SelectedValue.ToString();
        Session["ddlses"] = ddlval;
       
        Response.Redirect("Fixitmasters.aspx");
    }

    protected void ddlreport_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlvalrep = string.Empty;
        ddlvalrep = ddlreports.SelectedValue.ToString();
        Session["ddlsesrep"] = ddlvalrep;
        Response.Redirect("Fixitreports.aspx");
    }
    protected void btntemp(object sender, EventArgs e)
    {
        //   Response.Redirect("templates.aspx");
    }
    protected void btnsettng(object sender, EventArgs e)
    {
        //  Response.Redirect("settings.aspx");
    }
    public void BindGrid()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "Select top (100) * from [dbo].[" + Session["ddlses"] + "]";
        Lblwh.Text = " "+ Session["ddlses"] +" ";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);


        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdmaster.DataSource = dtDsStockist;

            Grdmaster.DataBind();
        }
    }
}
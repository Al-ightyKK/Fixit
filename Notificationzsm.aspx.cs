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

public partial class Notificationzsm : System.Web.UI.Page
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
            BindGrid();

        }
    }
    public void BindGrid()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";

        StrQrry = "SELECT [DIVISION] ,[NOTIFICATION], Max([Time]) as Time from [dbo].[Notification$] where DIVISION =  '" + Hidnfldiv.Value.ToString() + "' and [ZSM CODE] = '" + Hidnfldcode.Value.ToString() + "'  group by [DIVISION] , [ZSM CODE] ,[NOTIFICATION] ORDER BY [Time] DESC;";
        //     Lblwh.Text = "Approval Request";where [Unblocked Percentage] <= " + Session["ddlpercent"] + " and Division = '" + Session["ddldiv"] + "'

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";

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
            // notific.Rows[0].Visible = false;
            lblnow.Text = "NO DATA";
            lblnow.Visible = true;
        }

    }
    protected void Btncontact(object sender, EventArgs e)
    {
        Hidnfldname.Value = Session["zsmname"].ToString();
        Hidnfldcode.Value = Session["zcode"].ToString();
        Hidnfldiv.Value = Session["divi"].ToString();
        Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("Contactus.aspx");
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
        Response.Redirect("Templates.aspx");
    }
  
}
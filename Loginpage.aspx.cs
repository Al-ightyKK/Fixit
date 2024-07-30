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

public partial class Loginpage : System.Web.UI.Page
{
    DataSet DsStockist = new DataSet();
    DataTable dtDsStockist = new DataTable();
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) lblVersion.Text = "v2.4.5.14";
        HyperLink hl1 = new HyperLink();
        hl1.NavigateUrl = "loginpassword.aspx";
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[loginID$];", conn);
        conn.Open();
        SqlDataReader read = cmd.ExecuteReader();
        var logintbl = new DataTable();
        string empcode = string.Empty;
        string emppass = string.Empty;
        string directpage = string.Empty;
        string zsmname = string.Empty;
        string newpass = string.Empty;
        newpass = "pass123";
        logintbl.Load(read);
        if (logintbl.Rows.Count > 0)
        {
            TableRow lgtbrw1 = new TableRow();
            for (int i = 0; i < logintbl.Rows.Count; i++)
            {
                empcode = logintbl.Rows[i][2].ToString();
                if (empcode == Txtboxempcode.Text)
                {
                    emppass = logintbl.Rows[i][4].ToString();
                    if (emppass == Txtboxpass.Text)
                    {
                        Lblmessage.ForeColor = System.Drawing.Color.Green;
                        Lblmessage.Text = "Login Successful";
                       directpage = logintbl.Rows[i][5].ToString();
                       string compcode = logintbl.Rows[i][0].ToString();
                       DateTime datetimee = DateTime.Now;
                       string zcode = logintbl.Rows[i][2].ToString();
                       Session["zcode"] = zcode;
                       zsmname = logintbl.Rows[i][3].ToString();
                       Session["zsmname"] = zsmname;
                       string divi = logintbl.Rows[i][6].ToString();
                       Session["divi"] = divi;
                       Session["emppass"] = emppass;
                       Session["login"] = datetimee;

                       SqlCommand cmmd = new SqlCommand("Loginrecord_ps", conn1);
                       cmmd.CommandType = CommandType.StoredProcedure;
                       cmmd.Parameters.AddWithValue("@Emp_code", compcode.ToString());
                       cmmd.Parameters.AddWithValue("@Username", empcode.ToString());
                       cmmd.Parameters.AddWithValue("@ZSM_Code", zcode.ToString());
                       cmmd.Parameters.AddWithValue("@Name", zsmname.ToString());
                       cmmd.Parameters.AddWithValue("@Datetime", datetimee.ToString("MMM dd yyyy hh:mm tt"));   
                       conn1.Open();
                       //cmd.ExecuteNonQuery();
                       string strRslt = cmmd.ExecuteNonQuery().ToString();
                       conn1.Close();
                    //   Response.Redirect("loginpassword.aspx");
                    if (newpass != emppass)
                    {
                        Response.Redirect("" + directpage + ".aspx");
                    }
                    else
                    {
                        Response.Redirect("loginpassword.aspx");
                    }
                      // Response.Redirect("" + directpage + ".aspx");
                    }          
                    
                }
                else if (emppass != Txtboxpass.Text)
                {
                    Lblmessage.ForeColor = System.Drawing.Color.Red;
                    Lblmessage.Text = "Login Unsuccessful " + "<br />" + "  Please check your Password";
                    if (newpass == Txtboxpass.Text)
                    {
                        Lblmessage.ForeColor = System.Drawing.Color.Red;
                        string mess = string.Empty;
                        mess = "Login Unsuccessful!" + "<br />" + " Please enter your New Password";
                        Lblmessage.Text = mess;
                    }
                }
                else
                {
                    Lblmessage.ForeColor = System.Drawing.Color.Red;
                    Lblmessage.Text = "Login Unsuccessful " + "<br />" + "  Please check your Username";
                }
                
            }
        }
        read.Close();
        conn.Close();
    }
   
}
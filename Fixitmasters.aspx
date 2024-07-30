<%@ Page Title="" Language="C#" MasterPageFile="~/fixitmasterpage.master" AutoEventWireup="true" CodeFile="Fixitmasters.aspx.cs" Inherits="Fixitmasters" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js" 
    integrity="sha512-rMGGF4wg1R73ehtnxXBt5mbUfN9JUJwbk21KMlnLZDJh7BkPmeovBuddZCENJddHYYMkCh9hPFnPmS9sspki8g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" 
    integrity="sha512-yVvxUQV0QESBt1SyZbNJMAwyKvFTLMyXSyBHDO4BG5t7k/Lw34tyqlSDlKIrIENIzCl+RVUNjmCPG+V/GMesRw==" crossorigin="anonymous" referrerpolicy="no-referrer" /> 
<style type="text/css">
      .sidenav {
  height:100%;
  width: 0;
  position: fixed;
  z-index: 1;
  top: 10;
  left: 0;
  background-color:#0d9dbc;
  overflow-x: hidden;
  transition: 0.5s;
  border-radius: 0px 10px 0px 0px;
  padding-top:60px;
}
.sidenav a {
  padding: 8px 8px 8px 32px;
  text-decoration: none;
  font-size: 25px;
  color:White;
  display: block;
  transition: 0.3s;
}

.sidenav a:hover {
  color:#0d9dbc;
}

.sidenav .closebtn {
  position: absolute;
  top: 0;
  right: 25px;
  font-size: 36px;
  margin-left: 50px;
}
  .button
 {
   box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
       border:none;
       width:300px;
       height:50px;
       background-color:#0d9dbc;
       color:white;
       text-align:center;
      }
     #header
        {
            width: 1731px;
            margin-left: 0px;
        }
        .Panell
        {
            margin-left: 0px;
            text-align:center;
        
          background-color:#0d9dbc;
        color:White;
        margin-top: 0px;
        margin-bottom: 0px;
        margin-left: 118px;
        border-radius:13px;
        padding:15px 50px 0px 20px;
        font-size:large;
        }
        .addbtn
        { 
        box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
        border-radius:6px;
        border-style:none;
        background-color:#0d9dbc;
        width:100px;
        color:White;
        height:35px;
        }
          .modalBackground
    {
        background-color:Black;
        filter:alpha(opacity=90) !important;
        opacity:0.6 !important;
        z-index:20;
    }
    .box
    {
         box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
         border-radius:6px;
         border-style:none;
         height:25px;
         width:200px;
    }
     .btn1
        { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:#0d9dbc;
            color:White;
            height:40px;
            Width:150px; 
     }
  table
   {
         position: absolute;
         right: 0px;
   }
    .style3
    {
         height: px;
    }
    </style>
      <link href="design.css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="header pull-left" style="width: 100%">
       <p style="background-color:#0d9dbc; height: 9px; width: 1520px; margin-bottom: 9px;"><br />
          <img src="images/ggror p.png" style=" margin-left:10px; height: 50px; width:100px" /> 
  <asp:Panel ID="Panel1" CssClass="Panell" runat="server" Width="1330px" Height="31px">
      <label style="width: 718px; text-align:left;  margin-bottom:30px; margin-top:20px; font-family:Calibri; margin-left:0px"><b>
        FIXIT - Expiry Reduction</b></label> 
        </asp:Panel>
   <hr style="height:8px; background-color:#0d9dbc; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); width: 1520px; margin-left: 0px;" />
  <table style=" width:100%; margin-top:0px; top: 86px;"> <td><span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; </span> </td> 
     
          <td> <div id="header pull-right" style="width: 100%;text-align:right;"> 
       <asp:TextBox ID="srchtxtbox" CssClass="box" placeholder="Search menu" runat="server"></asp:TextBox> 
           <img src="images/message-16.png" style="height: 25px; width: 25px" /><img src="images/message-31-128.png" style="height: 25px; width: 25px" />
           <img src="images/message-17-128.png" style="height: 25px; width: 25px" />
           </div></td>
                   <div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
   <asp:DropDownList ID="ddlmasters" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlmaster_SelectedIndexChanged" runat="server">
                         <asp:ListItem Text="Master"></asp:ListItem>
                         <asp:ListItem Text="Stockist Master" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Product Master" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="Employee Master" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Hierarchy Master" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="CNF Master" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Territory Master" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="YTD Master" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Product Category" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="Customer Master" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="Product Division" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Product Type" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="City Master" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="HQ Master" Value="Product master"></asp:ListItem>
                 </asp:DropDownList>
   <br />
   <asp:Button ID="btnnav2" CssClass="button" runat="server"  OnClick="btntemp"  Text="Templates" />
   <br />
   <asp:DropDownList ID="ddlreports" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlreport_SelectedIndexChanged" runat="server">
                         <asp:ListItem Text="Reports"></asp:ListItem>
                         <asp:ListItem Text="Savings(Expiry Reduction)" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Expiry to Sales Ratio" Value="expiryratio"></asp:ListItem>
                         <asp:ListItem Text="Inventory Days" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Sales Expiry" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="Stockist Reports" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="HQ Reports" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="Closing Value Trends" Value="closingtrnd"></asp:ListItem>
                         <asp:ListItem Text="Inevitable Expiry" Value="Product master"></asp:ListItem>
                 </asp:DropDownList>
   <br />
    <asp:Button ID="btnnav4" CssClass="button"  runat="server"  OnClick="btnsettng" Text="Settings" />
    <br />
   <asp:Button ID="Btnnav5" CssClass="button"  runat="server" Text="Option3" />
   <br />
   <asp:Button ID="Btnnav6" CssClass="button"  runat="server" Text="Option4" />
    <br />
   <asp:Button ID="Btnnav7" CssClass="button"  runat="server" Text="Option5" />
   </div>
     </table>    
    
<script type="text/javascript">
    function openNav() {
        document.getElementById("mySidenav").style.width = "250px";
    }

    function closeNav() {
        document.getElementById("mySidenav").style.width = "0";
    }
</script>
</p>
</div>
 <div> 
<br />
<br />
<br />
    <hr style="width: 1506px; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px;" />
   <center>  <asp:Label ID="Lblwh"  Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></center>
<br />
    <asp:GridView ID="Grdmaster" HeaderStyle-BackColor="#0d9dbc"  RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="left"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" 
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2" 
            AlternatingRowStyle-ForeColor="Black"   RowStyle-Font-Size="Small" 
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white" 
            RowStyle-BorderColor="#f2f2f2" runat="server" 
            Height="50px" Width="100%">
            <Columns >
              
            </Columns>           
            </asp:GridView>
     <hr style="width: 1248px; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px;" />
</div>
<br />
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/fixitmasterpage.master" AutoEventWireup="true" CodeFile="emailnoti.aspx.cs" Inherits="emailnoti" %>


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
.buttondis
{           border:none;
       width:300px;
       height:50px;
       background-color:#0d9dbc;
       color:#0d9dbc;
       text-align:center;
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
            color:White;
            height:35px;
                           }
      .popblbtn
      { 
             border:none;
             background-color:White;
             color:White;
             height:1px;
             width:1px;
                           }
             .popbtn
        { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:#0d9dbc;
             color:White;
             height:35px;
             width:50px;
                           }
                           .popbtn2
                            { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:#0d9dbc;
             color:White;
             height:35px;
             width:100px;
                           }
 .popbtn
        { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:#0d9dbc;
             color:White;
             height:35px;
             width:100px;
                           }
          .modalBackground
    {
        background-color:Black;
        filter:alpha(opacity=90) !important;
        opacity:0.6 !important;
        z-index:30;
    }
    .box
    {
         box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
         border-radius:6px;
         border-style:none;
         height:25px;
         width:200px;
    }
    
    .boxsresn
      {
         box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
         border-radius:6px;
         border-style:none;
         height:25px;
         width:100px;
    }
     .ddl
    {
         box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
         border-radius:6px;
         border-style:none;
         height:25px;
         width:80px;
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
                           .PanelB
    { border-color:Black; 
       border-radius:15px 15px 0px 0px;
       background-color:#F2F2F2;
        width:200px;
        height:150px;
             box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
        }
          .blinkblink
          {
              text-decoration:blink;
          }
    .modalpopup
    {
     border-radius:15px 15px 15px 15px; 
        position:relative;
        width:450px;
        height:150px;
         top: 50px;
          left:500px;
        text-align:center;
        background-color:White;
        border:1px solid black;    
       vertical-align:middle;    
    }
                   .rigg
               {
                   text-align:left;
               }
        .style1
    {
        width: 42px;
        height: 17px;
    }
    .style2
    {
        height: 17px;
        width: 876px;
    }
      .style3
    {
        width: 639px;
    }
                           </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="Hidnfldname" runat="server" />
        <asp:HiddenField ID="Hidnfldcode" runat="server" />
            <asp:HiddenField ID="Hidnfldiv" runat="server" />
              <asp:HiddenField ID="Hidnfldlogin" runat="server" />
    <div id="header pull-left" style="width: 100%">
       <p style="background-color:#0d9dbc; height: 9px; width: 1520px; margin-bottom: 9px;"><br />
          <img src="images/ggror p.png" style=" margin-left:10px; height: 50px; width:100px" />
  <asp:Panel ID="Panel1" CssClass="Panell" runat="server" Width="1330px" Height="31px">
      <label style="width: 718px; text-align:left;  margin-bottom:30px; margin-top:20px; font-family:Calibri; margin-left:0px"><b>
      FIXIT - Expiry Reduction</b></label> 
        </asp:Panel>
   <hr style="height:8px; background-color:#0d9dbc; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); width: 1520px; margin-left: 0px;" />
  <table style=" width:100%; margin-top:0px; top: 86px;"> <td class="style1"><span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; </span> </td> 
     
        <td> <div id="header pull-right" style="width:50%;text-align:left;">
      <asp:Label ID="Lblcount"  Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
 <asp:Label ID="Lblwelcm"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Lbldetail"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
        </td><td></td>
                   <div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
 <%--  <asp:Button ID="btnnav3" CssClass="button" runat="server"   Text="Home" />
   <br />
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
   <br />--%>
   <asp:Button ID="btnnav2" CssClass="button" runat="server"   Text="Blocking List" />
  <br />
  <%--
   <asp:DropDownList ID="ddlreports" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlreport_SelectedIndexChanged" runat="server">
     <asp:ListItem Text="Reports"></asp:ListItem>
                         <asp:ListItem Text="Savings(Expiry Reduction)" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Unblocking Report" Value="btnreprt"></asp:ListItem>
                       <asp:ListItem Text="Inventory Days" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Sales Expiry" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="Stockist Reports" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="HQ Reports" Value="Product master"></asp:ListItem>
                        <asp:ListItem Text="Closing Value Trends" Value="closingtrnd"></asp:ListItem>
                         <asp:ListItem Text="Inevitable Expiry" Value="Product master"></asp:ListItem>
                 </asp:DropDownList>
   <br />
   --%>
   <asp:Button ID="btnrprt" CssClass="button"  runat="server"  Text="Unblocking Report" />
      <br />
          <asp:Button ID="Button4" CssClass="button"  runat="server" Text="Notifications" />
<br />
       <asp:Button ID="btnconta" CssClass="button"  runat="server" Text="Contact Us" />
      <br />
   <asp:Button ID="btnout" CssClass="button"  runat="server" OnClick="btnoutclick"  Text="Logout" />
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
</p> <hr style="width: 1506px; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px;" />
   <center>  <asp:Label ID="Lblwh" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></center>
   <br /><asp:ScriptManager ID="ScriptManger1" runat="Server">
</asp:ScriptManager><br /><asp:GridView ID="Grdlink" HeaderStyle-BackColor="#0d9dbc"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" 
        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" 
        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" 
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"  
        ShowHeader="true" ShowHeaderWhenEmpty="true"
            AlternatingRowStyle-ForeColor="Black"    AutoGenerateColumns="false" 
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white" 
            RowStyle-BorderColor="#f2f2f2" runat="server"  
            Height="50px" Width="1506px"  >
            <Columns>
             <asp:BoundField DataField="Division" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Division"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" />
                <asp:BoundField DataField="ZSM_Code" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" HeaderText="ZSM Code" ItemStyle-Width="100px"   HeaderStyle-Width="100px" />
              <asp:BoundField DataField="Name" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" HeaderText="ZSM Name" ItemStyle-Width="100px"  HeaderStyle-Width="100px" />
                 <asp:BoundField DataField="Password" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" HeaderText="Subject" ItemStyle-Width="100px"   HeaderStyle-Width="100px" />
                   <asp:BoundField DataField="Email" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Email"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
                    <asp:BoundField DataField="EmailCC" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Email CC"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
               </Columns>           
                  </asp:GridView>          <br />
                 <div style=" text-align:right;">       <asp:Button ID="btnsendlink" CssClass="addbtn"  runat="server" Text="SEND EMAILS TO ZSM" 
        onclick="SendEmailsButtonlink_Click" />  </div><br />  <hr style="width: 1506px; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px;" />
        <asp:GridView ID="Grdnot" HeaderStyle-BackColor="#0d9dbc"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" 
        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" 
        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" 
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"  
        ShowHeader="true" ShowHeaderWhenEmpty="true"
            AlternatingRowStyle-ForeColor="Black"    AutoGenerateColumns="false" 
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white" 
            RowStyle-BorderColor="#f2f2f2" runat="server"  
            Height="50px" Width="1506px"  >
            <Columns>
             <asp:BoundField DataField="Division" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Division"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" />
                <asp:BoundField DataField="ZSM_Code" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" HeaderText="ZSM Code" ItemStyle-Width="100px"   HeaderStyle-Width="100px" />
              <asp:BoundField DataField="Name" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" HeaderText="ZSM Name" ItemStyle-Width="100px"  HeaderStyle-Width="100px" />
                 <asp:BoundField DataField="Password" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" HeaderText="Subject" ItemStyle-Width="100px"   HeaderStyle-Width="100px" />
                   <asp:BoundField DataField="Email" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Email"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
                    <asp:BoundField DataField="EmailCC" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Email CC"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
               </Columns>           
                  </asp:GridView>          <br />
                 <div style=" text-align:right;">       <asp:Button ID="btnotdon" CssClass="addbtn"  runat="server" Text="SEND EMAILS TO NOT DONE ZSM" 
        onclick="SendEmailsmotdoneButtonlink_Click" /> 
        <asp:Button ID="Button1" CssClass="addbtn"  runat="server" Text="SEND Review EMAILS" 
        onclick="SendEmailsButtonReviewd_Click" />   
         <asp:Button ID="pendDH" CssClass="addbtn"  runat="server" Text="SEND Pending EMAILS DH" 
        onclick="SendEmailsButtonAPendingDH_Click" />      
     <asp:Button ID="btnrej" CssClass="addbtn"  runat="server" Text="SEND Rejected EMAILS" 
        onclick="SendEmailsButtonRejected_Click" />  </div><br />
         <hr style="width: 1506px; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px;" />
  <asp:Label ID="Label2" Font-Size="Medium" Font-Bold="true" Text="Select Status to Send Email to ZSM:" Font-Names="calibri" runat="server"></asp:Label>
 <asp:DropDownList ID="ddlstatus" CssClass="ddl" Width="150px" runat="server"  AutoPostBack= "true" onselectedindexchanged="ddlstus_SelectedIndexChanged">
                 </asp:DropDownList>
                 <script type="text/javascript">
                     $('#<%=ddlstatus.ClientID %>').chosen();
                </script> <br /><br />
    <asp:GridView ID="Grdemp" HeaderStyle-BackColor="#0d9dbc"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" 
        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" 
        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" 
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"  
        ShowHeader="true" ShowHeaderWhenEmpty="true"
            AlternatingRowStyle-ForeColor="Black"    AutoGenerateColumns="false" 
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white" 
            RowStyle-BorderColor="#f2f2f2" runat="server"  
            Height="50px" Width="1506px"  >
            <Columns>
             <asp:BoundField DataField="DIVISION" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Division"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" />
                <asp:BoundField DataField="ZSM CODE" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" HeaderText="ZSM Code" ItemStyle-Width="100px"   HeaderStyle-Width="100px" />
              <asp:BoundField DataField="ZSM NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" HeaderText="ZSM Name" ItemStyle-Width="100px"  HeaderStyle-Width="100px" />
                 <asp:BoundField DataField="Subject" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" HeaderText="Subject" ItemStyle-Width="100px"   HeaderStyle-Width="100px" />
                   <asp:BoundField DataField="Body" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Body"  ItemStyle-Width="300px"  HeaderStyle-Width="300px" /> 
                     <asp:BoundField DataField="Approval" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Approval"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
                    <asp:BoundField DataField="Email" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Email"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
                    <asp:BoundField DataField="EmailCC" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Email CC"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
               </Columns>           
                  </asp:GridView>          <br />
                
                  <center>  <asp:Label ID="lblnow" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></center>
      <hr style="width: 1506px; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px;" />
        <br />
<br /><div style=" text-align:right;"><asp:Button ID="btnapp" CssClass="addbtn"  runat="server" Text="SEND Approved EMAILS" 
        onclick="SendEmailsButtonApproved_Click" /> 
           <asp:Button ID="btnreview" CssClass="addbtn"  runat="server" Text="SEND Review EMAILS" 
        onclick="SendEmailsButtonReviewd_Click" />   
      <asp:Button ID="btnpen" CssClass="addbtn"  runat="server" Text="SEND Pending EMAILS" 
        onclick="SendEmailsButtonAPending_Click" />  
      <asp:Button ID="btnadrej" CssClass="addbtn"  runat="server" Text="SEND AdminRejected EMAILS" 
        onclick="SendEmailsButtonAdRejected_Click" />  </div>
          <asp:Label ID="Label1" Font-Size="Medium" Font-Bold="true" Text="Select Division to Send Email to DH:" Font-Names="calibri" runat="server"></asp:Label>
 <asp:DropDownList ID="ddldhdiv" CssClass="ddl" Width="150px" runat="server"  AutoPostBack= "true" onselectedindexchanged="ddldh_SelectedIndexChanged">
                 </asp:DropDownList>
                 <script type="text/javascript">
                     $('#<%=ddldhdiv.ClientID %>').chosen();
                </script> <br /><br />
    <asp:GridView ID="Grddh" HeaderStyle-BackColor="#0d9dbc"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" 
        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" 
        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" 
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"  
        ShowHeader="true" ShowHeaderWhenEmpty="true"
            AlternatingRowStyle-ForeColor="Black"    AutoGenerateColumns="false" 
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white" 
            RowStyle-BorderColor="#f2f2f2" runat="server"  
            Height="50px" Width="1506px"  >
            <Columns>
             <asp:BoundField DataField="DIVISION" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Division"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" />
                <asp:BoundField DataField="ZSM CODE" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" HeaderText="ZSM Code" ItemStyle-Width="100px"   HeaderStyle-Width="100px" />
              <asp:BoundField DataField="ZSM NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" HeaderText="ZSM Name" ItemStyle-Width="100px"  HeaderStyle-Width="100px" />
                 <asp:BoundField DataField="Subject" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" HeaderText="Subject" ItemStyle-Width="100px"   HeaderStyle-Width="100px" />
                   <asp:BoundField DataField="Body" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Body"  ItemStyle-Width="300px"  HeaderStyle-Width="300px" /> 
                     <asp:BoundField DataField="Approval" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Approval"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
                    <asp:BoundField DataField="Email" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Email"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
                    <asp:BoundField DataField="EmailCC" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="Email CC"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
               </Columns>           
                  </asp:GridView>          <br />
                 <div style=" text-align:right;">       </div>
          


</asp:Content>


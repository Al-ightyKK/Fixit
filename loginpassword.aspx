<%@ Page Title="" Language="C#" MasterPageFile="~/fixitmasterpage.master" AutoEventWireup="true" CodeFile="loginpassword.aspx.cs" Inherits="loginpassword" %>

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
                           
                           .passchangebtn
                             { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:White;
             color:Black;
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
         width:100px;
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
    .hidden { display: none; }
                           </style>
   <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:HiddenField ID="Hidnfldname" runat="server" />
        <asp:HiddenField ID="Hidnfldcode" runat="server" />
            <asp:HiddenField ID="Hidnfldiv" runat="server" />
              <asp:HiddenField ID="Hidnfldlogin" runat="server" />
 <div id="header pull-left" style="width: 92%; height: 148px;">
       <p style="background-color:#0d9dbc; height: 9px; width: 1520px; margin-bottom: 9px;"><br />
          <img src="images/ggror p.png" style=" margin-left:10px; height: 50px; width:100px" />            
  <asp:Panel ID="Panel1" CssClass="Panell" runat="server" Width="1330px" Height="31px">
      <label style="width: 718px; text-align:left;  margin-bottom:30px; margin-top:20px; font-family:Calibri; margin-left:0px"><b>
         FIXIT - Expiry Reduction</b></label>
        </asp:Panel>
   <hr style="height:8px; background-color:#0d9dbc; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); width: 1520px; margin-left: 0px;" />
   </p> </div>   <div runat="server" id="account" style="border-width:medium;">
            <br /><center><h2>Your Account details</h2></center>
  <center>  Enter Your Username: <asp:TextBox ID="Usercode" CssClass="ddl" runat="server"></asp:TextBox> </center>
  <br< />   <br />
 <center>  Enter Your old Password:  <asp:TextBox ID="Useroldpass" CssClass="ddl" TextMode="Password" runat="server"></asp:TextBox></center>
  <br< />   <br />
 <center><asp:Button ID="btncheck" CssClass="popbtn" onclick="checkbuttonclick"  runat="server" Text="Check"  /> </center><br />
  <center><asp:Label ID="Lblmessage"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></center>

</div>

<div runat="server" id="newdetails" style=" font-family:Calibri; font-size:large; border-width:medium;">

      <center> <table style="height:300px;      border-radius:15px 15px 15px 15px;   background-color:#0d9dbc;  color:White; border-collapse: separate; border-spacing: 0; box-shadow: 0px 0px 36px 15px rgba(0, 0, 0, 0.28); width:500px;">
     <tr><td align="center"> <center><h3 style="height: 2px; font-family:Calibri; font-size:large; width: 489px">Password Change Required!</h3></center></td></tr>
    <tr><td align="center">Name: <asp:Label ID="Lblname"  Font-Size="Medium"  Font-Bold="false" Font-Names="calibri" runat="server"></asp:Label></td></tr>
 
     <tr><td align="center"> Emp Code:  <asp:Label ID="Lblcode"  Font-Size="Medium" Font-Bold="false" Font-Names="calibri" runat="server"></asp:Label> </td></tr>

<tr><td align="center">Division: <asp:Label ID="Lbldiv"  Font-Size="Medium" Font-Bold="false" Font-Names="calibri" runat="server"></asp:Label></td></tr>

<tr>   <td align="center"> Old Password:  <asp:Label ID="Lblpass"  Font-Size="Medium" Font-Bold="false" Font-Names="calibri" runat="server"></asp:Label></td></tr> 
    <tr>   <td align="center">   <center style="font-family:Calibri; font-size:Medium;"> Enter Your New password: <asp:TextBox ID="Txtboxnewpass" ToolTip="Please make sure your passwords contains atleast 8 characters* (alphabets and numbers)." CssClass="ddl" TextMode="Password" runat="server"></asp:TextBox>   </center></td></tr> 

  <tr>   <td align="center">    <center style="font-family:Calibri; font-size:Medium;">   Re-Enter New password:  <asp:TextBox ID="Txtbxrepass" CssClass="ddl" runat="server"></asp:TextBox>
   <asp:ImageButton ID="btnverfy" Enabled="true" Width="20px" runat="server"
                       ImageUrl="~/images/check-mark.png" OnClick="onclickverify" class="ttip_t" ToolTip="verify" />  </center> </td> </tr>
   <br />       <tr>   <td align="center">   <center> <asp:Button ID="btonnok" CssClass="passchangebtn" OnClick="onclicksubmt"  runat="server" Text="OK"  /></center> </td> </tr>  </table>
    <asp:Label ID="Lblnoteice"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server">Please make sure your passwords contains atleast 8 characters* (alphabets and numbers).</asp:Label>
</center>
<%--          <asp:Button ID="btonrest" CssClass="popbtn"  runat="server" OnClick="onclickreset"  Text="Reset"  />--%> 
       <br />  <br />       <center>   <asp:Label ID="Lblvrfy"  Font-Size="Large" Font-Bold="true" ForeColor="Green" Font-Names="calibri" runat="server"></asp:Label> <br />
                       <asp:Label ID="Lblnotvrfy"  Font-Size="Large" Font-Bold="true" ForeColor="Red" Font-Names="calibri" runat="server"></asp:Label></center>
              </div>
<div runat="server" id="success" style="border-width:medium;">
<center><h3 style="font-family:Calibri; font-size:large; color:Green;">Your Updated Password has been sent on your registered Email address.</h3></center>
<%--<center><h3 style="font-family:Calibri; font-size:large; color:Green;">Your Password has been Updated! Please Login with your New Password!</h3></center>--%>
<center> <asp:HyperLink id="hgoback" NavigateUrl="Loginpage.aspx" Text="Go back to Login" runat="server"/></center>
</div>

</asp:Content>


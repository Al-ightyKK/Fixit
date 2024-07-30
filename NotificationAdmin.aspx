<%@ Page Title="" Language="C#" MasterPageFile="~/fixitmasterpage.master" AutoEventWireup="true" CodeFile="NotificationAdmin.aspx.cs" Inherits="NotificationAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
   <meta http-equiv="Refresh" content="30">
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
       width:250px;
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
         height:40px;
         width:300px;
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
        width: 4020px;
    }
      .WrapText {  
            width: 100%;  
            word-break: break-all;  
        }  
    .hidden { display: none; }
   
      #file
        {
            width: 35px;
            height: 10px;
        }
           .file
        { border-style: none;
          
            border-width: medium;
            padding: 10px 20px;
            background-color:#0d9dbc;
            color:White;
              border-radius:15px;
               font-family:Calibri;
               text-align:center;
               width:100px;
          
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);    
             display:inline-block;
            
            }
             
              .input-file-container {
  position: relative;
  width: 159px;
            top: 0px;
            left: 0px;
            height: 46px;
        } 
.js .input-file-trigger {
  display: block;
  padding: 14px 45px;
  background: #0d9dbc;
  color: white;
  width:100px;
  font-size: 1em;
  transition: all .4s;
  border-radius:15px;
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
  cursor: pointer;
}
.js .input-file {
  position: absolute;
  top: 0; left: 0;
  width: 100px;
  opacity: 0;
  padding: 14px 0;
  cursor: pointer;
}
.js .input-file:hover + .input-file-trigger,
.js .input-file:focus + .input-file-trigger,
.js .input-file-trigger:hover,
.js .input-file-trigger:focus {
  background: #0d9dbc;
  color: white;
}

.file-return {
  margin: 0 0 0 407px;
            width: 100px;
            height: 0px;
        }
.file-return:not(:empty) {
  margin: 1em 0;
}
.js .file-return {
  font-style:normal;
  font-size: 15px;
  font-weight: normal;
}
.js .file-return:not(:empty):before {
  content: "Selected file: ";
  font-style: normal;
  font-weight: normal;
}


    
       
    
        .input-file
        {
            margin-left: 0px;
            margin-top: 0px;
            width: 100px;
        }


                           .style3
    {
        width: 519px;
        text-align:right;
    }

    
    .notification-badge {
    position: absolute;
    top: 15%;
    right: 20px;
}

.badge {
    background-color: red;
    color: white;
    padding: 0px 8px;
    border-radius: 50%;
}
    .notification 
    {
          position: fixed;
    top: 30%;
    right: 20px; /* Adjust this value to control the distance from the right side */
    transform: translateY(-50%);
    z-index: 1000;
    position: fixed;
    background-color: #fff;
    padding: 20px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
    display: none;
}

    .movingLabel {
        position: absolute;
        left: -100%; /* Initial position outside the container */
        white-space: nowrap; /* Prevent labels from wrapping */
        animation: moveLabel 10s linear infinite; /* Animation properties */
       
    }
     .moving-label {
    position: absolute;
    top: 100px;
    left: 0; /* Start from the leftmost position */
    white-space: nowrap; /* Prevent label text from wrapping */
    transition: left 5s linear; /* Transition for smooth movement */
}
                           </style>
                        
   <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="Hidnfldname" runat="server" />
        <asp:HiddenField ID="Hidnfldcode" runat="server" />
            <asp:HiddenField ID="Hidnfldiv" runat="server" />
              <asp:HiddenField ID="Hidnfldlogin" runat="server" />
    <div id="header pull-left" style="width:   100%; height: 148px;">
       <p style="background-color:#0d9dbc; height: 9px; width: 100%; margin-bottom: 9px;"><br />
          <img src="images/ggror p.png" style=" margin-left:10px; height: 50px; width:100px" />            
  <asp:Panel ID="Panel1" CssClass="Panell" runat="server" Width="87%" Height="31px">
      <label style="width: 718px; text-align:left;  margin-bottom:30px; margin-top:20px; font-family:Calibri; margin-left:0px"><b>
         FIXIT - Expiry Reduction</b></label> 
        </asp:Panel>
   <hr style="height:8px; background-color:#0d9dbc; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); width: 100%; margin-left: 0px;" />
  <table style=" width:100%; margin-top:0px height: 51px; height: 50px;"> 
      <td valign="top" class="style1"><span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; </span> </td> 
          <td valign="top" class="style2"> 
          <div id="header pull-right" style="width: 100%; text-align:Left; height: 48px;"> 
              <asp:Label ID="Lblwelcm"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label> 
   <br />
           
       <asp:Label ID="Lbldetail"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
            </div>
                   <div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
    <br />
       <asp:Button ID="Btnhm" CssClass="button"  runat="server"  OnClick="btnhmclick" Text="Home" />
<br />
<asp:Button ID="Button1" CssClass="button" runat="server" OnClick="btntemp"  Text="Blocking List" />
    <br />
  <%--   <asp:Button ID="btnrprt" CssClass="button"  runat="server" OnClick="btnreprt" Text="Unblocking Report" />
      <br />--%>
           <asp:DropDownList ID="ddlreports" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlreport_SelectedIndexChanged" runat="server">
     <asp:ListItem Text="Reports"></asp:ListItem>
      <asp:ListItem Text="Overall Summary Report" Value="sumaryreport"></asp:ListItem>
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
       <asp:Button ID="btnconta" CssClass="button"  runat="server" OnClick="btncontac" Text="Contact Us" />
      <br />
   <asp:Button ID="btnout" CssClass="button"  runat="server"  OnClick="btnoutclick" Text="Logout" />
   <br />
   <asp:Button ID="Btnnav6" CssClass="buttondis" Enabled="false" runat="server" Text="Disable" />
   </div></td>
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
 <br />
 <br />
  <br />
   <br />
<div>
        <br />
           <center>  <asp:Label ID="Label1" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></center>
       <asp:GridView ID="notific" HeaderStyle-BackColor="#0d9dbc"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" 
        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false" 
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" 
        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true"
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="15px" RowStyle-Height="15px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"  
            AlternatingRowStyle-ForeColor="Black" RowStyle-Font-Size="Small"  AutoGenerateColumns="false"   
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white" DataKeyNames="DIVISION"
            RowStyle-BorderColor="#f2f2f2" runat="server"   onrowcommand="Grdemp_rowcommand"
            Height="50px"  Width="100%" >
            <Columns>   
            <asp:BoundField DataField="DIVISION" ItemStyle-Font-Size="Medium" ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="Division" ItemStyle-Width="20px"  HeaderStyle-Width="20px" />
                     <asp:BoundField DataField="NOTIFICATION" ItemStyle-Font-Size="Medium" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Notifications"  ItemStyle-Width="50px"  HeaderStyle-Width="50px" /> 
       <asp:TemplateField HeaderText="For Details" ItemStyle-HorizontalAlign="center" ItemStyle-Width="10px" >
                      <ItemTemplate>
                      <asp:ImageButton ID="btnview" Enabled="true" Width="20px"  CommandName="btncview" CommandArgument='<%#Eval("DIVISION") + ";" +Eval("[NOTIFICATION]")%>' runat="server" ImageUrl="~/images/eye-icon-1457.png" ToolTip="view" />                  
                     </ItemTemplate>
                     </asp:TemplateField> 
  <asp:BoundField DataField="Time" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="center" HeaderText="Time"  ItemStyle-Width="50px"  HeaderStyle-Width="50px" /> 
                              </Columns>           
                  </asp:GridView><br /></div>
 <div>
 
           <center>  <asp:Label ID="lblnow" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></center>
       <asp:GridView ID="Grdrprt" HeaderStyle-BackColor="#0d9dbc"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" 
        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" 
        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true"
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"  
            AlternatingRowStyle-ForeColor="Black" RowStyle-Font-Size="Small"  AutoGenerateColumns="false"   
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white" 
            RowStyle-BorderColor="#f2f2f2" runat="server"
            Height="50px" Width="100%" >
            <Columns>   
            <asp:BoundField DataField="Division" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="Division" ItemStyle-Width="200px"  HeaderStyle-Width="200px" />
         <asp:BoundField DataField="ZSM CODE" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="ZSM Code" ItemStyle-Width="200px"   HeaderStyle-Width="200px" />
         <asp:BoundField DataField="ZSM_Name" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="ZSM Name" ItemStyle-Width="300px"   HeaderStyle-Width="300px" />
   <asp:BoundField DataField="Unblocked" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="center" HeaderText="Unblocked"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
   <asp:BoundField DataField="Blocked" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="center" HeaderText="Blocked"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
  <asp:BoundField DataField="Total" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="center" HeaderText="Total"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
  <asp:BoundField DataField="Unblocked Percentage" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="center" HeaderText="Unblocked Percentage"  ItemStyle-Width="200px"  HeaderStyle-Width="200px" /> 
                    <asp:BoundField DataField="Approved" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="Status"  ItemStyle-Width="200px"  HeaderStyle-Width="200px" />     
               </Columns>           
                  </asp:GridView><br /></div>
                  
</asp:Content>

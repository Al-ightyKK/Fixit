<%@ Page Title="" Language="C#" MasterPageFile="~/fixitmasterpage.master" AutoEventWireup="true" CodeFile="Portsmpt.aspx.cs" Inherits="Portsmpt" %>

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
<div id="header pull-left" style="width: 92%; height: 148px;">
       <p style="background-color:#0d9dbc; height: 9px; width: 1520px; margin-bottom: 9px;"><br />
          <img src="images/ggror p.png" style=" margin-left:10px; height: 50px; width:100px" />            
  <asp:Panel ID="Panel1" CssClass="Panell" runat="server" Width="1330px" Height="31px">
      <label style="width: 718px; text-align:left;  margin-bottom:30px; margin-top:20px; font-family:Calibri; margin-left:0px"><b>
         FIXIT - Expiry Reduction</b></label>
        </asp:Panel>
   <hr style="height:8px; background-color:#0d9dbc; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); width: 1520px; margin-left: 0px;" />
   </p> </div>  
   <div>    <center> <asp:GridView ID="Grdport" HeaderStyle-BackColor="#0d9dbc" 
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" 
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" 
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2" 
            AlternatingRowStyle-ForeColor="Black"   
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white" 
            RowStyle-BorderColor="#f2f2f2" AutoGenerateColumns="False" runat="server"
            Height="50px" Width="1240px" onrowcommand="GrdStockist_RowCommand">
            <Columns>
            <asp:BoundField DataField="SmtpClient" HeaderText="SmtpClient" />
                         <asp:BoundField DataField="smtpClientfromus" HeaderText="smtpClientfromus" />
                           <asp:BoundField DataField="Host" HeaderText="Host" />
                         <asp:BoundField DataField="noPort" HeaderText="Port no." />
                          <asp:BoundField DataField="Credentialsname" HeaderText="Credentials email" />
                           <asp:BoundField DataField="Credentialspass" HeaderText="Credentials password" />
                             <asp:BoundField DataField="EnableSsl" HeaderText="EnableSsl" />
                        <asp:TemplateField HeaderText="Update" ItemStyle-HorizontalAlign="Center">  <ItemTemplate>
                     <asp:ImageButton ID="btnEdit"  CommandName="btnEdit" CommandArgument='<%# Bind("SmtpClient") %>'
                                   runat="server" ImageUrl="~/images/edit.png" ToolTip="Edit" class="ttip_t" Width="25px" />
                     </ItemTemplate></asp:TemplateField> 
                          </Columns>
                              </asp:GridView><br />  <center>  <asp:Button ID="Btntest" CssClass="btn1" runat="server" 
                    Text="Testa a mail" onclick="Testmail_Click" /></center>  <br /> 
           <asp:Label ID="Lblnote" Font-Size="Large" Font-Bold="true"  ForeColor="Green" Font-Names="calibri" runat="server"></asp:Label></center>   
            </div>
                        <div runat="server" id="update" style="border-width:medium;">       
        <center> <table border="5px"> <tr> <td>SmtpClient:</td> 
        <td>   <asp:TextBox ID="TxtboxSmtpClient" CssClass="box" runat="server"></asp:TextBox> </td></tr>
       <tr> <td> smtpClientfromus: </td>
      <td>     <asp:TextBox ID="TxtboxsmtpClientfromus" CssClass="box" runat="server"></asp:TextBox> </td></tr>
        <tr> <td>   Host: </td>
    <td>       <asp:TextBox ID="Host" CssClass="box" runat="server"></asp:TextBox></td> </tr>
      <tr>  <td> Port no.: </td>
   <td>        <asp:TextBox ID="noPort" CssClass="box" runat="server"></asp:TextBox></td> </tr>
        <tr>   <td>   Credentials email: </td>
   <td>        <asp:TextBox ID="Credentialsname" CssClass="box" runat="server"></asp:TextBox></td> </tr>
       <tr> <td> Credentials password: </td>
     <td>      <asp:TextBox ID="Credentialspass" CssClass="box" runat="server"></asp:TextBox></td> </tr>
        <tr>  <td>    EnableSsl: </td>
    <td>       <asp:TextBox ID="EnableSsl" CssClass="box" runat="server"></asp:TextBox></td> </tr>
                  <tr>   <td>  <center><asp:Button ID="Btnsave" CssClass="btn1" runat="server" 
                       Text="Save" onclick="Save_Click" /> </center></td>
                         <td> <asp:Button ID="Btnback" CssClass="btn1" runat="server" 
                    Text="Cancel" onclick="Back_Click" /></td> </tr> </table>
           </center>  
          </div>
             <div runat="server" id="divtest" style="border-width:medium;">      
               <center>   Email ID of Receiver:   <asp:TextBox ID="Txtbxrecmail" CssClass="box" runat="server"></asp:TextBox></center>
             <br />
                 <center><asp:Button ID="Button1" CssClass="btn1" runat="server" 
                       Text="Test" onclick="Sendemail_Click" /> </center></div>

</asp:Content>


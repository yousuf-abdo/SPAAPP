<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="5wfForgetPassword.aspx.cs" Inherits="SPAAPP.wfForgetPassword1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <br /> 
       <div  class="row">
           <div class="col-3"></div>
           <div class="col-6">
                <div class="card card-body">
                    <div style="text-align:center"><h4>Recover Your Password</h4></div>
        <asp:Label ID="Label1" runat="server"    Text="Register ID:"></asp:Label>
    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Register ID" runat="server"></asp:TextBox>
        <br />                             
    <asp:Label ID="Label2" runat="server"  Visible="false" Text="Password:"></asp:Label>
        <asp:TextBox ID="TextBox2"  CssClass="form-control" placeholder="New Password"  TextMode="Password"   Visible="false"  runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server"  Visible="false" Text="confirm Password:"></asp:Label>        
        <asp:TextBox ID="TextBox3"  CssClass="form-control"  placeholder="Confirm Password"  TextMode="Password"  Visible="false"  runat="server"></asp:TextBox>
        <br />
    <asp:Button ID="Button1"  OnClick="Button1_Click" CssClass="btn btn-info" runat="server" Text="Recover" />
        <br />
    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    </div>
           </div>
           <div class="col-3"></div>
       </div>
    <br />
</asp:Content>

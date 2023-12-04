<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="vNum.aspx.cs" Inherits="SPAAPP.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <br /><br /><br />
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <div class="card card-body">
            <div  style="text-align:center"> <h4>Recover Your Password</h4></div>
                <br />
        <asp:Label ID="Label5" runat="server"    Text=" We Sent a Code  to your  E-mail plaese check your inbox  "></asp:Label>
        <br />
         <asp:Label ID="Label1" runat="server"    Text="The Code:"></asp:Label>
    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder ="Write the code here..." runat="server"></asp:TextBox>
        <br />                
        <asp:Button ID="Button1" CssClass="btn btn-info"  OnClick="Button1_Click"  runat="server" Text="Check The Code" />
            </div>
            </div>
        <div class="col-3"></div>
    </div>
    <br /><br /><br />
</asp:Content>

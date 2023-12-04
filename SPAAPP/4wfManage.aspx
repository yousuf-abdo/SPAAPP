<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="4wfManage.aspx.cs" Inherits="SPAAPP.wfManage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <br />
        <br />
        <br />
    <br />

    <div class="row">  
        <asp:Button ID="Button1" CssClass="btn btn-primary m-5"  Width="100%" OnClick="Button1_Click" runat="server" Text="Pharmacy" />                    
        </div>
            <div class="row">       
        <asp:Button ID="Button2"  CssClass="btn btn-success  m-5"  Width="100%"  OnClick="Button2_Click" runat="server" Text="Medicinses" />                                     
                </div>  
    <div class="row">       
        <asp:Button ID="Button3"  CssClass="btn btn-warning  m-5"  Width="100%"  OnClick="Button3_Click" runat="server" Text="Requested Medicinses" />                                     
                </div>                             
    <br /><br />
    <br /><br />
    <br />
</asp:Content>

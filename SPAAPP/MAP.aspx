<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="MAP.aspx.cs" Inherits="SPAAPP.MAP" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">    
    <div  style="margin:10px; padding:10px;background-color:white;">
    <cc1:GMap ID="GMap1" Width="1310px" Height="510px" runat="server" />
        </div>
</asp:Content>

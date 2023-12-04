<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="wfRequestedMedAdmin.aspx.cs" Inherits="SPAAPP.wfRequestedMedAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     <br /><br />        
    <div id="d" class="row" style="padding-left:10px;padding-right:5px;justify-content:center;margin:5px;">        
        <div class="card card-body">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
          <asp:GridView ID="gvRequMed" DataKeyNames="ID" 
                OnRowCommand="gvRequMed_RowCommand" 
                style="padding-left:10px;padding-right:10px; justify-content:center" 
                CssClass="table table-bordered"   runat="server" BackColor="White" 
                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="1">           
              <Columns>                    
        <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>                
                <asp:Button ID="btnDelete" CssClass="btn btn-danger"  CausesValidation="true" ValidationGroup="UpdatingGrid"  CommandArgument='<%# Bind("ID") %>'  CommandName="Button22" runat="server" Text="Delete" />
            </ItemTemplate>         
        </asp:TemplateField>         
    </Columns>

              <FooterStyle BackColor="White" ForeColor="#000066" />
              <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" 
                  HorizontalAlign="Center" VerticalAlign="Middle" />
              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
              <RowStyle ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Middle" />
              <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
              <SortedAscendingCellStyle BackColor="#F1F1F1" />
              <SortedAscendingHeaderStyle BackColor="#007DBB" />
              <SortedDescendingCellStyle BackColor="#CAC9C9" />
              <SortedDescendingHeaderStyle BackColor="#00547E" />

            </asp:GridView>

            <asp:HiddenField ID="HiddenField2" runat="server" />
            <asp:HiddenField ID="HiddenField3" runat="server" />
        </div>
    </div>

</asp:Content>

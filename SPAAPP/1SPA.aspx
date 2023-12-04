<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="1SPA.aspx.cs" Inherits="SPAAPP.SPA2" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div   class="row"> 
        <%------------------------------------------------For MAP-------------------------------------------------%>
        <div  class="col-5"  style="padding-top:40px;padding-bottom:40px;">
                <cc1:GMap ID="GMap1" BackColor="Green"  Width="550px" Height="600px" Visible="false" runat="server" />
        </div>
        <%------------------------------------------------For GridView and Search------------------------------------------------%>
        <div  class="col-7"  style="justify-content:flex-start;padding:-10px;" >
  <br /><br /><br /><br /><br /><br /><br />             
             <div class="card card-body">
            <div class="row" style="justify-content:center">
            <asp:Button ID="btnSearch" CssClass="btn btn-info" OnClick="btnSearch_Click" runat ="server"  Text="Search"/>                     
            <asp:TextBox ID="TextBox1" CssClass="form-control   ml-1"  runat="server" Width="400px"></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" CssClass="form-control  ml-1" Width="400px"  AutoPostBack="false"  Visible="false"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server"></asp:DropDownList>            
            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-link  ml-1" OnClick="LinkButton1_Click" runat="server">By Pharmacy</asp:LinkButton>               
                </div>          
                <br />
    <div  class="row" style="justify-content:center;direction:ltr;">
       <asp:Label ID="Label1" runat="server" Visible="false" Text=""></asp:Label>
       <asp:HyperLink ID="hylReq"  class="btn btn-warning" data-toggle="modal" data-target="#modal-warning" Visible="false" runat="server">Requset this Medicine?</asp:HyperLink> 
              
            <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand" 
                CssClass="table  table-bordered mt-2"  runat="server" BackColor="White" 
                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                DataKeyNames="phID" >

               

                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
 <Columns>
                    <asp:TemplateField HeaderText="View Map">
                        <ItemTemplate>
                            <asp:Button ID="Button1" CssClass="btn btn-info" CommandArgument='<%# Bind("phID") %>' CausesValidation="true" ValidationGroup="UpdatingGrid"  CommandName="Button22" runat="server" Text="View Map" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>      
        </div>    
                </div>
        </div>       
    </div>   
    <asp:HiddenField ID="HiddenField1" runat="server" />  
    <br /><br /><br />
    <br /><br /><br />
    <br /><br /><br />  
    

    <div class="modal fade" id="modal-warning">
        <div class="modal-dialog">
          <div class="modal-content bg-warning">
            <div class="modal-header">
              <h4 class="modal-title">Requset This Medicene</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span></button>
            </div>
            <div class="modal-body">
                <asp:Label ID="lblReqMedName" runat="server" Text=""></asp:Label><br />
                <asp:TextBox ID="txtReqTel" CssClass="form-control" placeHolder="Your Telphone Number" runat="server"></asp:TextBox>
            </div>
            <div class="modal-footer justify-content-between">
              <button type="button" class="btn btn-outline-dark" data-dismiss="modal">Close</button>

                <asp:Button ID="Button2" OnClick="Button2_Click" class="btn btn-outline-dark  swalDefaultSuccess" runat="server" Text="Save Requset" />                
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
              
</asp:Content>

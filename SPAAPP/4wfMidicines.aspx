<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="4wfMidicines.aspx.cs" Inherits="SPAAPP.wfMidiciness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

<br />         
    <div class =" row">
        
        <div  class="col-3"></div>
        <div  class="col-6">
            <div  class="card card-body">
                <div style="justify-content:center;text-align:center">
            <h3>Manage Your Medicines </h3>
                    <br />
        </div>
            <div>
            Medicine NAME: <asp:TextBox ID="TextBox1" runat="server"  CssClass="form-control"  placeholder="Medicine Name"></asp:TextBox>   
                   
        <asp:RequiredFieldValidator   ID="RequiredFieldValidator1" ValidationGroup="aaa"    ControlToValidate="TextBox1"  runat="server" ErrorMessage="Required Field"  ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />      
         Medicine Price:  <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Medicine Price"></asp:TextBox>     
                  
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="aaa"  ControlToValidate="TextBox2"  runat="server" ErrorMessage="Required Field"  ForeColor="Red"></asp:RequiredFieldValidator>
                  <br />     
         Medicine Quantaty:   <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Medicine Quantaty"></asp:TextBox>           
                   
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="aaa" ControlToValidate="TextBox3"  runat="server" ErrorMessage="Required Field"  ForeColor="Red"></asp:RequiredFieldValidator>
                   <br />    
            <asp:Button ID="Button1" CssClass="btn btn-info"  ValidationGroup="aaa"    Width="100%" runat="server" OnClick="Button1_Click" Text="SAVE" />
                <br />           
     <div  style="justify-content:center;text-align:center;">
            <asp:Label ID="Label1"  runat="server" Text=""></asp:Label>
         </div>
                <br />
               </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
                 <%--ValidationGroup="UpdatingGrid" --%>

        
                </div>
        </div>
        <div  class="col-3"></div>
        </div>

    <br />

       <div id="d" class="row" style="padding-left:10px;padding-right:5px;justify-content:center;margin:5px;">
        <div class="card card-body">
            
          <asp:GridView ID="GridView1" DataKeyNames="medID" OnRowCommand="GridView1_RowCommand" style="padding-left:10px;padding-right:10px; justify-content:center" CssClass="table table-bordered"   runat="server">           
              <Columns>
                     <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>                
                <asp:Button ID="btnDelete"  CssClass="btn btn-danger" CausesValidation="true" ValidationGroup="UpdatingGrid"  CommandArgument='<%# Bind("medID") %>'  CommandName="Button33" runat="server" Text="Delete" />
            </ItemTemplate>
                         </asp:TemplateField>
        <asp:TemplateField HeaderText="Change">
            <ItemTemplate>                
                <asp:Button ID="btnUpdate" CssClass="btn btn-warning"  CausesValidation="true" ValidationGroup="UpdatingGrid"  CommandArgument='<%# Bind("medID") %>'  CommandName="Button22" runat="server" Text="Change" />
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

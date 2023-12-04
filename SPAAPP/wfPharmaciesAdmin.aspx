<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="wfPharmaciesAdmin.aspx.cs" Inherits="SPAAPP.wfPharmaciesAdmin1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <br />
        <div class="row"> 
             <div class="col-3 m-3">
                 <p>
                     Sometimes Customers Request a medicine and that medicines my not found in those Registered Pharmacies<br />
                     so we will Rgister that Reqested Medicines...
                     So the Admin can control those Reqseted medicines.<br />
                     To Show More Details <a href="wfRequestedMedAdmin.aspx">Click Here</a>
                 </p>
             </div>
         <div class="col-6">
             <div class="card card-body">
                 <div style="text-align:center"><h4>Manage Your Pharmacy Account</h4></div>
                 
                 
                 <table>
                 <tr>
                         <td>
           Pharmacy Name : <asp:TextBox ID="TextBox1"  CssClass="form-control" runat="server"  placeHolder="pharmacy Name"></asp:TextBox> 
                             </td>                
                         <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ValidationGroup="aaa" ControlToValidate="TextBox1"  runat="server" ErrorMessage="*"  ForeColor="Red"></asp:RequiredFieldValidator>
                         </td>                 
                         </tr>
                      
                 <tr>
                    <td>
                        Pharmacy Address : <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"  placeHolder="pharmacy Address"></asp:TextBox>
                    </td>
                    <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ValidationGroup="aaa" ControlToValidate="TextBox2"  runat="server" ErrorMessage="*"  ForeColor="Red"></asp:RequiredFieldValidator>
                 </td>
                </tr>
                 
                      <tr>
                    <td>
                        Map Location: <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server"  placeHolder="Map Location"></asp:TextBox>
                    </td>
                    <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10"  ValidationGroup="aaa" ControlToValidate="TextBox9"  runat="server" ErrorMessage="*"  ForeColor="Red"></asp:RequiredFieldValidator>
                 </td>
                </tr>
                 

                 <tr>
                         <td>
          Pharmacy Phone1 : <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"  placeHolder="pharmacy Phone1"></asp:TextBox>
                             </td>
                         <td>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  ValidationGroup="aaa"  ControlToValidate="TextBox3"  runat="server" ErrorMessage="*"  ForeColor="Red"></asp:RequiredFieldValidator>
                          </td>
                 </tr>
        
                 <tr>
                         <td>
          Pharmacy Phone2 : <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"  placeHolder="pharmacy Phone2"></asp:TextBox>
                             </td>
                       <td>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="aaa"  ControlToValidate="TextBox4"  runat="server" ErrorMessage="*"  ForeColor="Red"></asp:RequiredFieldValidator>
                          </td>
        </tr>
                 
                 <tr>
                         <td>
          Pharmacy E-Mail : <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"  placeHolder="pharmacy E-mail"></asp:TextBox>
                             </td>
                         <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ValidationGroup="aaa"  ControlToValidate="TextBox5"  runat="server" ErrorMessage="*"  ForeColor="Red"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="aaa"  runat="server"  ControlToValidate="TextBox5" ErrorMessage="Invalid E-mail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                             </td>
        </tr>
                  
                 <tr>
                         <td>
          Pharmacy Register ID : <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server"  placeHolder="pharmacy Register  ID"></asp:TextBox>
                             </td>
                      <td>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6"  ValidationGroup="aaa"   ControlToValidate="TextBox6"  runat="server" ErrorMessage="*"  ForeColor="Red"></asp:RequiredFieldValidator>
                          </td>
        </tr>
                     
                 <tr>
                       <td>
        Pharmasist Name:<asp:TextBox ID="TextBox7" CssClass="form-control" runat="server" placeholder="Pharmasist Name"></asp:TextBox>
                             </td>
                       <td>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator7"  ValidationGroup="aaa"   ControlToValidate="TextBox7"  runat="server" ErrorMessage="*"  ForeColor="Red"></asp:RequiredFieldValidator>
                          </td>
            </tr>
                     
                 <tr>
                       <td>
           Password:<asp:TextBox ID="TextBox8" CssClass="form-control" TextMode="Password" runat="server" placeholder="Password"></asp:TextBox>
                             </td>
                       <td>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator8"  ValidationGroup="aaa"  ControlToValidate="TextBox8"  runat="server" ErrorMessage="*"  ForeColor="Red"></asp:RequiredFieldValidator>
                          </td>
            </tr>
                     
                 <tr>
                       <td>
        License Image<asp:FileUpload ID="FileUpload1"  CssClass="custom-file" runat="server" />
                             </td>
                       <td>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator9"  ValidationGroup="aaa"  ControlToValidate="FileUpload1"  runat="server" ErrorMessage="*"  ForeColor="Red"></asp:RequiredFieldValidator>
                          </td>
        </tr>
                     
                     </table>            

        <br />
        <asp:Button ID="Button1" CssClass="btn btn-warning"  ValidationGroup="aaa" Enabled="false"  OnClick="Button1_Click" runat="server" Text="Update Account" />
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:HiddenField ID="HiddenField2" runat="server" />
    </div>
        <div>   
            </div>
             </div>    
            <div class="col-3"></div>     
        </div>
        <div class="row" style="padding-left:10px;padding-right:5px;justify-content:center;margin:5px;">
        <div class="card card-body">
            
          <asp:GridView ID="GridView1" DataKeyNames="ID" OnRowCommand="GridView1_RowCommand" style="padding-left:10px;padding-right:10px; justify-content:center" CssClass="table table-bordered"   runat="server">           
              <Columns>
                     <asp:TemplateField HeaderText="Medicines">
            <ItemTemplate>                
                <asp:Button ID="btnMedicines"  CssClass="btn btn-info" CausesValidation="true" ValidationGroup="UpdatingGrid"  CommandArgument='<%# Bind("ID") %>'  CommandName="Button22" runat="server" Text="Medicines" />
            </ItemTemplate>
                         </asp:TemplateField>
        <asp:TemplateField HeaderText="Update">
            <ItemTemplate>                
                <asp:Button ID="btnUpdate" CssClass="btn btn-warning"  CausesValidation="true" ValidationGroup="UpdatingGrid"  CommandArgument='<%# Bind("ID") %>'  CommandName="Button11" runat="server" Text="Update" />
            </ItemTemplate>         
        </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>                
                <asp:Button ID="btnDelete"  CssClass="btn btn-danger" CausesValidation="true" ValidationGroup="UpdatingGrid"  CommandArgument='<%# Bind("ID") %>'  CommandName="Button33" runat="server" Text="Delete" />
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

            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField3" runat="server" />
        </div>
    </div>
</asp:Content>

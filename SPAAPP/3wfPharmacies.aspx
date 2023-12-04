<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="3wfPharmacies.aspx.cs" Inherits="SPAAPP.wfPharmacies1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     <br />
     <div class="row"> 
         <div class="col-3"></div>
         <div class="col-6">
             <div class="card card-body">
                 <div style="text-align:center"><h4>Manage Your Pharmacy Account</h4></div>
                 <br />            
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
        <asp:Button ID="Button1"  CssClass="btn btn-success "  ValidationGroup="aaa"  OnClick="Button1_Click" runat="server" Text="Create Account" />
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>            
    </div>        
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />  
            </div>
            </div>
            <div class="col-3"></div>          
        </div>

</asp:Content>

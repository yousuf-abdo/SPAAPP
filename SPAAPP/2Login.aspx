<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="2Login.aspx.cs" Inherits="SPAAPP.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <br />   
    <div class="row">        
                <div class="col-4"></div>                
                <div class="col-4">
                    <div class="card card-body">
                        <div class="row"  style="justify-content:center">
                        <h3> Login With Your Account</h3>
                            </div>
                        <br />  
            Register ID:
            <asp:TextBox ID="TextBox1" CssClass="form-control" PlaceHolder="Register ID"  runat="server"></asp:TextBox>
            
            Password:
            <asp:TextBox ID="TextBox2" CssClass="form-control"  PlaceHolder="Password"  TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" CssClass="btn btn-info"  OnClick="Button1_Click" runat="server" Text="Login" />
                        <br />
            <asp:Button ID="Button2" CssClass="btn btn-danger"  OnClick="Button2_Click" runat="server" Text="Cancel" />
            <div style="text-align:center">
                
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>      
                        <br />                  
                        <asp:LinkButton ID="LinkButton1" OnClick ="LinkButton1_Click" runat="server"> Create New Account</asp:LinkButton>                        
            <a  href="5wfForgetPassword.aspx"> Forget Password</a>  
                    </div>   
                </div>
                <div class="col-4"></div>                                
        </div>
    <br />
</asp:Content>

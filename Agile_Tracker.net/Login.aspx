<%@ Page Title="" Language="C#" MasterPageFile="~/Notloggedin.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Agile_Tracker.net.Login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding:30px">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Username" Font-Names="Arial" Font-Size="Small"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Password" Font-Names="Arial" Font-Size="Small"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    <br />
                    <asp:Label ID="lblError" runat="server" Text="Error" CssClass="errotext" Visible="false"></asp:Label>                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/secure/LoggedIn.master" AutoEventWireup="true" CodeBehind="edituser.aspx.cs" Inherits="Agile_Tracker.net.secure.edituser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding:30px">
        <asp:Label ID="Label4" runat="server" Text="Add New User" CssClass="headertext"></asp:Label>
        <br />
        <table style="width:30%">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Firstname"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="LastName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>            
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="User Level"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserLevel" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/secure/LoggedIn.master" AutoEventWireup="true" CodeBehind="addUserStory.aspx.cs" Inherits="Agile_Tracker.net.secure.addUserStory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding:30px">
        <asp:Label ID="Label4" runat="server" Text="Add New User Story" CssClass="headertext"></asp:Label>
        <br />
        <table style="width:30%">
            <tr>
                <td style="width:100px">
                    <asp:Label ID="Label5" runat="server" Text="User Role"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserRole" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    <asp:Label ID="Label6" runat="server" Text="Request"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRequest" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Purpose"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPurpose" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Acceptance Criteria"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAceptCriteria" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="MVP"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chkMVP" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>

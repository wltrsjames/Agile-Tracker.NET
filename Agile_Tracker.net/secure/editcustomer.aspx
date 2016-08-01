<%@ Page Title="" Language="C#" MasterPageFile="~/secure/LoggedIn.master" AutoEventWireup="true" CodeBehind="editcustomer.aspx.cs" Inherits="Agile_Tracker.net.secure.editcustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding:30px">
        <asp:Label ID="Label4" runat="server" Text="Add New Customer" CssClass="headertext"></asp:Label>
        <br />
        <table style="width:30%">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Customer Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Company Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Company Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCompanyAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Company Postcode"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCompanyPostcode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Company Phone"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCompanyPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Mobile"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
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

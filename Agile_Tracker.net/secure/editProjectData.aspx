﻿<%@ Page Title="" Language="C#" MasterPageFile="~/secure/LoggedIn.master" AutoEventWireup="true" CodeBehind="editProjectData.aspx.cs" Inherits="Agile_Tracker.net.secure.editProjectData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding:30px">
        <asp:Label ID="Label4" runat="server" Text="Edit Project" CssClass="headertext"></asp:Label>
        <br />
        <table style="width:30%">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Project Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProjectName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="width:100px">
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Definition"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDefinition" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    <asp:Label ID="Label3" runat="server" Text="Outline"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtOutline" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Customer"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownCustomer" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Project Owner"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownOwner" runat="server"></asp:DropDownList>
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

<%@ Page Title="" Language="C#" MasterPageFile="LoggedIn.master" AutoEventWireup="true" CodeBehind="start.aspx.cs" Inherits="Agile_Tracker.net.secure.start" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding:30px">
        <asp:Label ID="Label1" runat="server" Text="List of Projects" CssClass="headertext"></asp:Label>
        <br />
        <asp:Button ID="btnAddProject" runat="server" Text="Add New Project" OnClick="btnAddProject_Click" />
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="Projects_ProjectId" DataSourceID="ObjectDataSource1" ForeColor="Black" GridLines="Vertical" AllowPaging="True">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# String.Format("editproject.aspx?ProjectId={0}", Eval("Projects_ProjectId"))  %>' Text="View"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Projects_ProjectId" HeaderText="ProjectId" InsertVisible="False" ReadOnly="True" SortExpression="Projects_ProjectId" />
                <asp:BoundField DataField="Projects_ProjectName" HeaderText="Project Name" SortExpression="Projects_ProjectName" />
                <asp:BoundField DataField="Projects_Definition" HeaderText="Definition" SortExpression="Projects_Definition" />
                <asp:BoundField DataField="Projects_Outline" HeaderText="Outline" SortExpression="Projects_Outline" />
                <asp:BoundField DataField="Customers_CustomerName" HeaderText="Customer Name" SortExpression="Customers_CustomerName" />
                <asp:BoundField DataField="Users_Firstname" HeaderText="Firstname" SortExpression="Users_Firstname" />
                <asp:BoundField DataField="Users_Lastname" HeaderText="Lastname" SortExpression="Users_Lastname" />
                <asp:BoundField DataField="Projects_CreatedDate" HeaderText="Created Date" SortExpression="Projects_CreatedDate" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetQryGetProjectList" TypeName="JWLTD.API.DatabaseLayer.QryGetProjectList.BusinessLogicLayer"></asp:ObjectDataSource>
        
        <br />
        <asp:Label ID="Label2" runat="server" Text="List of Users" CssClass="headertext"></asp:Label>
        <br />
        <asp:Button ID="btnAddUser" runat="server" Text="Add New User" OnClick="btnAddUser_Click"/>

        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="pkUserId" DataSourceID="ObjectDataSource2" ForeColor="Black" GridLines="Vertical" AllowPaging="True" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# String.Format("edituser.aspx?UserId={0}", Eval("pkUserId"))  %>' Text="Edit"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="pkUserId" HeaderText="pkUserId" InsertVisible="False" ReadOnly="True" SortExpression="pkUserId" />
                <asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname" />
                <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Userlevel" HeaderText="Userlevel" SortExpression="Userlevel" />
                <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllUsers" TypeName="JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer"></asp:ObjectDataSource>

        <br />
        <asp:Label ID="Label3" runat="server" Text="List of Customers" CssClass="headertext"></asp:Label>
        <br />
        <asp:Button ID="btnAddCustomer" runat="server" Text="Add New Customer" OnClick="btnAddCustomer_Click"/>
        

        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="CustomerId" DataSourceID="ObjectDataSource3" ForeColor="Black" GridLines="Vertical" Width="100%" AllowPaging="True">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# String.Format("editcustomer.aspx?CustomerId={0}", Eval("CustomerId"))  %>' Text="Edit"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" InsertVisible="False" ReadOnly="True" SortExpression="CustomerId" />
                <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" SortExpression="CustomerName" />
                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                <asp:BoundField DataField="CompanyAddress" HeaderText="CompanyAddress" SortExpression="CompanyAddress" />
                <asp:BoundField DataField="CompanyPostcode" HeaderText="CompanyPostcode" SortExpression="CompanyPostcode" />
                <asp:BoundField DataField="CompanyPhone" HeaderText="CompanyPhone" SortExpression="CompanyPhone" />
                <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer"></asp:ObjectDataSource>
        

    </div>    
</asp:Content>

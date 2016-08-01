<%@ Page Title="" Language="C#" MasterPageFile="~/secure/LoggedIn.master" AutoEventWireup="true" CodeBehind="editproject.aspx.cs" Inherits="Agile_Tracker.net.secure.editproject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding:30px">
        <asp:Button ID="btnEditProject" runat="server" Text="Edit Project"  OnClick="btnEditProject_Click" />
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="ProjectId" DataSourceID="ObjectDataSource1" ForeColor="Black" GridLines="Vertical" Height="50px" Width="408px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="ProjectId" HeaderText="ProjectId" InsertVisible="False" ReadOnly="True" SortExpression="ProjectId" />
                <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" />
                <asp:BoundField DataField="Definition" HeaderText="Definition" SortExpression="Definition" />
                <asp:BoundField DataField="Outline" HeaderText="Outline" SortExpression="Outline" />
                <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" SortExpression="CustomerId" />
                <asp:BoundField DataField="ProjectOwnerId" HeaderText="ProjectOwnerId" SortExpression="ProjectOwnerId" />
                <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" />
            </Fields>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:DetailsView>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Add Milestone"  OnClick="btnAddMilestone_Click" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="ProjectMilestoneId" DataSourceID="ObjectDataSource2" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# String.Format("editmilestone.aspx?ProjectId={0}&MilestoneId={1}", Eval("ProjectId"), Eval("ProjectMilestoneId"))  %>' Text="Edit"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ProjectMilestoneId" HeaderText="ProjectMilestoneId" InsertVisible="False" ReadOnly="True" SortExpression="ProjectMilestoneId" />
                <asp:BoundField DataField="MilestoneDescription" HeaderText="MilestoneDescription" SortExpression="MilestoneDescription" />
                <asp:BoundField DataField="EstimatedHours" HeaderText="EstimatedHours" SortExpression="EstimatedHours" />
                <asp:BoundField DataField="EstimatedCost" HeaderText="EstimatedCost" SortExpression="EstimatedCost" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="HoursSpent" HeaderText="HoursSpent" SortExpression="HoursSpent" />
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
        <br />
        <asp:Button ID="Button3" runat="server" Text="Add User Story"  OnClick="btnAddUserStory_Click" />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="UserStoryId" DataSourceID="ObjectDataSource3" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# String.Format("edituserstory.aspx?ProjectId={0}&UserStoryId={1}", Eval("ProjectId"), Eval("UserStoryId"))  %>' Text="Edit"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UserStoryId" HeaderText="UserStoryId" InsertVisible="False" ReadOnly="True" SortExpression="UserStoryId" />
                <asp:BoundField DataField="UserRole" HeaderText="UserRole" SortExpression="UserRole" />
                <asp:BoundField DataField="Request" HeaderText="Request" SortExpression="Request" />
                <asp:BoundField DataField="Purpose" HeaderText="Purpose" SortExpression="Purpose" />
                <asp:BoundField DataField="AcceptanceCriteria" HeaderText="AcceptanceCriteria" SortExpression="AcceptanceCriteria" />
                <asp:BoundField DataField="MVP" HeaderText="MVP" SortExpression="MVP" />
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
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetUserStoryByProjectId" TypeName="JWLTD.API.DatabaseLayer.TabUserStories.BusinessLogicLayer">
            <SelectParameters>
                <asp:QueryStringParameter Name="ProjectId" QueryStringField="ProjectId" Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetMilestonesByProject" TypeName="JWLTD.API.DatabaseLayer.TabProjectMilestones.BusinessLogicLayer">
            <SelectParameters>
                <asp:QueryStringParameter Name="ProjectId" QueryStringField="ProjectId" Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProjectById" TypeName="JWLTD.API.DatabaseLayer.TabProjects.BusinessLogicLayer">
            <SelectParameters>
                <asp:QueryStringParameter Name="ProjectId" QueryStringField="ProjectId" Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Back" OnClick="btnBack_Click" />
        <br />
        </div>
</asp:Content>

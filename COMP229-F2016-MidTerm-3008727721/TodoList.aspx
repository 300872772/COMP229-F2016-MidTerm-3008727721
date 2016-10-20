<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP229_F2016_MidTerm_3008727721.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

      <h1>ToDo List</h1>
                <a href="TodoDetails.aspx" class="btn btn-success btn-sm">
                    <i class="fa fa-plus"></i> Add ToDo
                </a>

                <div>
                    <label for="PageSizeDropDownList">Records per Page:</label>
                    <asp:DropDownList ID="PageSizeDropDownList" runat="server"
                        AutoPostBack="true" CssClass="btn btn-default btn-sm dropdown-toggle"
                       >
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="All" Value="10000" />
                    </asp:DropDownList>
                </div>


    <asp:GridView ID="TodoListGridView" runat="server" AutoGenerateColumns="false"
        CssClass="table table-bordered table-striped table-hover" DataKeyNames="TodoID"
        
        PagerStyle-CssClass="pagination-ys">
        <Columns>
            <asp:BoundField DataField="TodoID" HeaderText="Todo ID" Visible="true" SortExpression="TodoID" />
            <asp:BoundField DataField="TodoDescription" HeaderText="Todo Description" Visible="true" SortExpression="TodoDescription" />
            <asp:BoundField DataField="TodoNotes" HeaderText="Todo Notes" Visible="true" SortExpression="TodoNotes" />




            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox
                        ID="chkIsSubscribed" runat="server" HeaderText="IsSubscribed"
                        Checked='<%#Convert.ToBoolean(Eval("Completed")) %>' />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>

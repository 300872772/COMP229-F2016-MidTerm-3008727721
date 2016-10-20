<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP229_F2016_MidTerm_3008727721.TodoDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <label for="todoname">Todo Name</label>

        <asp:TextBox runat="server" placeholder="Enter Todo Name" CssClass="form-control" ID="todoname"></asp:TextBox>

    </div>


    <div class="form-group">
        <label for="todonotes">Todo Note</label>

        <asp:TextBox runat="server" placeholder="Enter Todo Notes" CssClass="form-control" ID="todonotes"></asp:TextBox>

    </div>
    <div class="form-group">
        <label for="completed">Completed</label>

        <asp:CheckBox runat="server" CssClass="form-control" ID="completed"></asp:CheckBox>

    </div>


    <div class="text-right">
        <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server"
            UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
       
        <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server"
            OnClick="SaveButton_Click" />

        </div>
</asp:Content>

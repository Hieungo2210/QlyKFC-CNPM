<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Mater.Master"  CodeBehind="QuanLyTaiKhoan.aspx.cs" Inherits="WebApplication3.QuanLyTaiKhoan" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server"  onrowdatabound="GridView1_RowDataBound" CssClass="table table-bordered"></asp:GridView>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </form>
</asp:Content>
<%@ Page Language="C#" MasterPageFile="~/Views/Mater.Master" AutoEventWireup="true" CodeBehind="ThemTaiKhoan.aspx.cs" Inherits="WebApplication3.WebForm3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="session">
        <div class="left">
            <form id="form1" runat="server">
                <div class="floating-label">
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                    <label for="txtTaiKhoan">Tên tài khoản:</label>
                </div>
                <div class="floating-label">
                    <input id="txtTaiKhoan" name="txtTaiKhoan" type="text" autocomplete="off" readonly onfocus="this.removeAttribute('readonly');"  />
                    <label for="txtTaiKhoan">Tên tài khoản:</label>
                </div>
                <div class="floating-label">            
                    <input id="txtMatKhau" name="txtMatKhau" type="password"autocomplete="off" readonly onfocus="this.removeAttribute('readonly');" />
                    <label for="txtMatKhau">Mật khẩu mới:</label>
                </div>
                <div class="floating-label">            
                    <input id="txtMatKhauNhapLai" name="txtMatKhauNhapLai" type="password" autocomplete="off" readonly  onfocus="this.removeAttribute('readonly');" />
                    <label for="txtMatKhauNhapLai">Nhập lại mật khẩu:</label>
                </div>
                <asp:Button ID="btnThemTaiKhoan" runat="server" Text="Thêm tài khoản"/>
            </form>
        </div>
    </div>
</asp:Content>

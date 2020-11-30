<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Mater.Master"  CodeBehind="DoiMatKhau.aspx.cs" Inherits="WebApplication3.DoiMatKhau" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="session">
    <form class="log-in" autocomplete="off" runat="server"> 
      <div class="floating-label">
        <input id="txtMatKhauCu" name="txtMatKhauCu" type="password" autocomplete="off" />
        <label for="txtMatKhauCu">Mật khẩu cũ:</label>
      </div>
      <div class="floating-label">            
            <input id="txtMatKhau" name="txtMatKhau" type="password"autocomplete="off"  />
            <label for="txtMatKhau">Mật khẩu mới:</label>
      </div>
      <div class="floating-label">            
            <input id="txtMatKhauNhapLai" name="txtMatKhauNhapLai" type="password" autocomplete="off"/>
            <label for="txtMatKhauNhapLai">Nhập lại mật khẩu:</label>
      </div>
        <asp:Button ID="btnDoiMatKhau" runat="server" Text="Đổi Mật Khẩu"/>
    </form>
  </div>
</asp:Content>
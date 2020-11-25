<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaoCao_TK.aspx.cs" Inherits="WebApplication3.BaoCao_TK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Báo Cáo Thống Kê</title>
    <style>
            table, td {
              border: 1px solid black;
              border-collapse: collapse;
            }
            th{
                text-align: left;
                border-left: 1px solid white;
                 border-right: 1px solid white;
            }
            th, td {
              padding: 15px;
            }
        #Text1 {
            height: 21px;
            width: 149px;
            margin-left: 41px;
            margin-top: 0px;
            margin-bottom: 0px;
        }
        
        .tk{
            border: 1px solid black;
            margin-top: 20px;
           

        }
        #inp{
             width: 30%;
             float: left;
             display: block;

        }
        #TK_BC{
            margin-top: 20px;
            padding: 20px 20px;
            width: 65%;
            float:right;
            display: block;
        }

        #Date3 {
            margin-left: 16px;
        }
        #Date2 {
            margin-left: 15px;
        }
        
        .lable{
            text-align: center;
        }
        .ngay{
            margin-left: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="inp">
        <div id="nl" class="tk">
            <p class="lable">
                <asp:Button ID="TK_NL" runat="server" Text="Thống kê nguyên liệu" OnClick="TK_NL_Click" />
            </p>
        </div>

        <div id="dt"class="tk">
            <p class="lable">Thống kê doanh thu</p>
            Ngày bắt đầu <input id="ngaybatdau" class="ngay" type="date" runat="server" />
            <br /><br />Ngày kết thúc<input id="ngayketthuc" class="ngay" type="date" runat="server" />
            <p class="lable">
            <asp:Button ID="TK_DT_Ngay" runat="server" Text="Thống Kê" Width="148px" OnClick="TK_DT_Ngay_Click1" />
            </p>
        </div>

        <div id="tc"class="tk">
            <p class="lable">Thống kê tài chính</p>
            Ngày bắt đầu <input id="ngaybatdau_tc" class="ngay" type="date" runat="server" />
           <br /><br />Ngày kết thúc<input id="ngayketthuc_tc" class="ngay" type="date" runat="server" />
            <p class="lable">
            <asp:Button ID="TK_TC_Thang" runat="server" Text="Tháng" Width="148px" OnClick="TK_TC_Thang_Click" />
            <asp:Button ID="TK_TC_Nam"  runat="server" Text="Năm" Width="148px" OnClick="TK_TC_Nam_Click" />
            </p>
        
        </div>

        <div id="timkiembc" class="tk">
            <p>
            Ngày thống kê <input id="Date3" class="ngay" type="date" runat="server" />
            <p class="lable"> 
               <asp:Button ID="tim" runat="server" Text="Tìm kiếm" Width="148px" OnClick="tim_Click" />
            </p>
            </p>
        </div>

        </div>
        <div id="TK_BC" runat="server">
        </div>
    </form>
</body>
</html>

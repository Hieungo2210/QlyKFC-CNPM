using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var login = Request["btnThemTaiKhoan"];
            if (login != null)
            {
                string txtTenDangNhap = Request["txtTaiKhoan"].ToString();
                string txtMatKhau = Request["txtMatKhau"].ToString();
                string txtMatKhauNhapLai = Request["txtMatKhauNhapLai"].ToString();
                string taiKhoan = DropDownList1.SelectedValue;
                themTaiKhoan(txtTenDangNhap, txtMatKhau, taiKhoan);
                Response.Redirect("QuanLyTaiKhoan.aspx");
            }
            load_dropdown();
        }
        public void themTaiKhoan(string tenDN, string MK, string user)
        {

            string query = "insert into tblTaiKhoan (sMaNV, sUser, sPassword, sTrangthai) values ('"+user+"', '"+ tenDN+"','"+ MK+"', '1')";
            using (System.Data.SqlClient.SqlConnection myConnection = WebApplication3.Models.DAL.SqlConnectionData.connect())
            {
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    myConnection.Open();
                    int t = cmd.ExecuteNonQuery();
                }
            }
        }

        public void load_dropdown()
        {
            System.Data.SqlClient.SqlConnection myConnection = WebApplication3.Models.DAL.SqlConnectionData.connect();
            string com = "select * from tblNhanVien";
            SqlDataAdapter adpt = new SqlDataAdapter(com, myConnection);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "sTenNV";
            DropDownList1.DataValueField = "sMaNV";
            DropDownList1.DataBind();
        }

    }
}
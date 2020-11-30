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
    public partial class QuanLyTaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["khoa"] != null)
            {
                khoaTaiKhoan(Request["khoa"].ToString());
                Response.Redirect("QuanLyTaiKhoan.aspx");
            }
            if (Request["mokhoa"] != null)
            {
                moKhoaTaiKhoan(Request["mokhoa"].ToString());
                Response.Redirect("QuanLyTaiKhoan.aspx");
            }
            loadTaiKhoan();
        }

        public void loadTaiKhoan()
        {
            string query = "SELECT row_number() OVER (ORDER BY sUser) as STT, sMaNV as N'Mã nhân viên', " +
                "sUser as N'Tên đăng nhập', sTrangThai as N'Trạng thái', " +
                "sMaNV as N'Tác vụ'" +
                "FROM tblTaiKhoan";
            using (System.Data.SqlClient.SqlConnection myConnection = WebApplication3.Models.DAL.SqlConnectionData.connect())
            {
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    myConnection.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    BoundField test = new BoundField();
                    test.DataField = "New DATAfield Name";
                    test.HeaderText = "New Header";
                    GridView1.Columns.Add(test);
                }
            }
        }

        public void khoaTaiKhoan(string sMaNV)
        {
            string query = "update tblTaiKhoan set sTrangThai = 0 where sMaNV = '" + sMaNV + "'";
            using (System.Data.SqlClient.SqlConnection myConnection = WebApplication3.Models.DAL.SqlConnectionData.connect())
            {
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    myConnection.Open();
                    int t = cmd.ExecuteNonQuery();
                }
            }
        }

        public void moKhoaTaiKhoan(string sMaNV)
        {
            string query = "update tblTaiKhoan set sTrangThai = 1 where sMaNV = '" + sMaNV + "'";
            using (System.Data.SqlClient.SqlConnection myConnection = WebApplication3.Models.DAL.SqlConnectionData.connect())
            {
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    myConnection.Open();
                    int t = cmd.ExecuteNonQuery();
                }
            }
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if(e.Row.Cells[3].Text == "1")
                {
                    e.Row.Cells[3].Text = "Hoạt động";
                    e.Row.Cells[4].Text =
                        "<button value='" + e.Row.Cells[4].Text + "' name='khoa' type='submit'>Khóa</button>";
                }
                else
                {
                    e.Row.Cells[3].Text = "Đã khóa";
                    e.Row.Cells[4].Text =
                        "<button value='" + e.Row.Cells[4].Text + "' name='mokhoa' type='submit'>Mở khóa</button>";
                }
            }
        }
    }
}
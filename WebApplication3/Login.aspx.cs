using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Models.DAL;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var login = Request["btnLogin"];
            if(login != null)
            {
                string txtTenDangNhap = Request["txtTenDangNhap"].ToString();
                string txtMatKhau = Request["txtMatKhau"].ToString();
                if(dangNhap(txtTenDangNhap, txtMatKhau))
                Response.Redirect("TrangChu.aspx");
            }
        }

        public Boolean dangNhap(string tenDN, string MK)
        {
            System.Data.SqlClient.SqlConnection conn = SqlConnectionData.connect();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spCheckLogin", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TaiKhoanNV", tenDN);
            conn.Open();
            System.Data.SqlClient.SqlDataReader dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    if(dar["sPassword"].ToString() == MK)
                    {
                        Session["user_name"] = tenDN;
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
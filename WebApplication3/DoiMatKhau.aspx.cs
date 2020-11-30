using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class DoiMatKhau : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["txtMatKhauNhapLai"] != null)
            {
                if(Request["txtMatKhauNhapLai"].ToString() != Request["txtMatKhau"].ToString())
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Mật khẩu không khớp!');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + doiMatKhau(Request["txtMatKhauCu"], Request["txtMatKhau"]) + "');window.location.replace(DoiMatKhau.aspx);", true);
                }

            }
        }
        public string doiMatKhau(string mkCu, string mkMoi)
        {
            System.Data.SqlClient.SqlConnection conn = WebApplication3.Models.DAL.SqlConnectionData.connect();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spCheckLogin", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TaiKhoanNV", Session["user_name"].ToString());
            conn.Open();
            System.Data.SqlClient.SqlDataReader dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    if (dar["sPassword"].ToString() == mkCu)
                    {
                        string query = "update tblTaiKhoan set sPassword = '" + mkMoi + "' where sUser = '" + Session["user_name"].ToString() + "'";
                        using (System.Data.SqlClient.SqlConnection myConnection = WebApplication3.Models.DAL.SqlConnectionData.connect())
                        {
                            using (System.Data.SqlClient.SqlCommand cmd1 = new System.Data.SqlClient.SqlCommand(query, myConnection))
                            {
                                myConnection.Open();
                                int t = cmd1.ExecuteNonQuery();
                            }
                        }
                        return "Đổi mật khẩu thành công!";
                    }
                    else
                    {
                        return "Mật khẩu cũ không khớp!";
                    }
                }
            }
            return "Mật khẩu cũ không khớp!";
        }
    }
}
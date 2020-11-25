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
    public partial class BaoCao_TK : System.Web.UI.Page
    {
        string constr = @"Data Source=TRANHAU-PC;Initial Catalog=dbQLNH_KFC;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TK_NL_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    string sql = "select * from tblNguyenlieu";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    SqlDataAdapter data = new SqlDataAdapter(sql, cnn);
                    DataTable abc = new DataTable();
                    data.Fill(abc);
                    string them = @"<table style='width:100%'>
                                        <tr> 
                                            <th>Mã nguyên liệu</th>
                                            <th>Tên Nguyên Liệu</th>
                                            <th>Số lượng</th>
                                            <th>Đơn vị</th>
                                          </tr>";
                    if (abc.Rows.Count > 0)
                    {
                        for (int i = 0; i < abc.Rows.Count; i++)
                        {
                            them += @" <tr>
                                            <td>" + abc.Rows[i]["sManguyenlieu"].ToString() + @"</td>
                                            <td>" + abc.Rows[i]["sTennguyenlieu"].ToString() + @"</td>
                                            <td>" + abc.Rows[i]["iSoluong"].ToString() + @"</td>
                                            <td>" + abc.Rows[i]["sDonvi"].ToString() + @"</td>
                                          </tr>";
                            //them+="<div class='item item1'><p>Không co dữ liệu!</p></div>;
                        }
                        TK_BC.InnerHtml = them;
                    }
                    else
                    {
                        them += "<dic class='item'><p>Không có dữ liệu!</p></div>";
                        TK_BC.InnerHtml = them;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        /*protected void TK_DT_Thang_Click(object sender, EventArgs e)
        {
            string nbd = Request.Form["ngaybatdau"];
            string nkt = Request.Form["ngayketthuc"];
            //int tong = 0;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    string sql = @"select MONTH(dNgaylap) as 'thang', sum(mTienkhachtra) as 'doanhthu'
	                                from tblHoadon
	                                where '" + nbd + @"' <= dNgaylap and dNgaylap <= '" + nkt + @"'
	                                group by  MONTH(dNgaylap)";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    SqlDataAdapter data = new SqlDataAdapter(sql, cnn);
                    DataTable abc = new DataTable();
                    data.Fill(abc);
                    string them = @"<table style='width:50%'>
                                        <tr> 
                                            <th>Tháng</th>
                                            <th>Doanh Thu</th>
                                          </tr>";
                    string dt = "";
                    if (abc.Rows.Count > 0)
                    {
                        for (int i = 0; i < abc.Rows.Count; i++)
                        {
                            them += @" <tr>
                                            <td>" + abc.Rows[i]["thang"].ToString() + @"</td>
                                            <td>" + abc.Rows[i]["doanhthu"].ToString() + @"</td>
                                          </tr>";
                            //them+="<div class='item item1'><p>Không co dữ liệu!</p></div>;
                        }
                        TK_BC.InnerHtml = them;*/
                        /*
                        for (int i = 0; i < abc.Rows.Count; i++)
                        {
                            dt = abc.Rows[i]["doanhthu"].ToString();
                            tong = tong + Int32.Parse(dt);
                            //them+="<div class='item item1'><p>Không co dữ liệu!</p></div>;
                        }
                        them += @" <tr>
                                    <td>Tổng doanh thu </td>
                                    <td>" + tong + @"</td>
                                 </tr>";
                        TK_BC.InnerHtml = them;*//*
                    }
                    else
                    {
                        them += "<dic class='item'><p>Không có dữ liệu!</p></div>";
                        TK_BC.InnerHtml = them;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }*/

        protected void tim_Click(object sender, EventArgs e)
        {

        }

        protected void TK_DT_Ngay_Click1(object sender, EventArgs e)
        {
            string nbd = Request.Form["ngaybatdau"];
            string nkt = Request.Form["ngayketthuc"];
            float tong = 0;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    string sql = @"select dNgaylap, sum(mTienkhachtra) as 'doanhthu'
	                                from tblHoadon
	                                where '" + nbd + @"' <= dNgaylap and dNgaylap <= '" + nkt + @"'
	                                group by dNgaylap";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    SqlDataAdapter data = new SqlDataAdapter(sql, cnn);
                    DataTable abc = new DataTable();
                    data.Fill(abc);
                    string them = @"<table style='width:50%'>
                                        <tr> 
                                            <th>Ngày</th>
                                            <th>Doanh Thu</th>
                                          </tr>";
                    string dt = "";
                    if (abc.Rows.Count > 0)
                    {
                        for (int i = 0; i < abc.Rows.Count; i++)
                        {
                            them += @" <tr>
                                            <td>" + abc.Rows[i]["dNgaylap"].ToString() + @"</td>
                                            <td>" + abc.Rows[i]["doanhthu"].ToString() + @"</td>
                                          </tr>";
                            tong += float.Parse(abc.Rows[i]["doanhthu"].ToString());

                        }
                        them += @" <tr>
                                        <td>Tổng</td>
                                        <td>" + tong + @",000 đồng</td>
                                   </tr>";
                        TK_BC.InnerHtml = them;
                    }
                    else
                    {
                        them += "<dic class='item'><p>Không có dữ liệu!</p></div>";
                        TK_BC.InnerHtml = them;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void TK_TC_Thang_Click(object sender, EventArgs e)
        {
            string nbd = Request.Form["ngaybatdau_tc"];
            string nkt = Request.Form["ngayketthuc_tc"];
            float tong = 0;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    string sql = @"select YEAR(dNgaylap) as 'nam', MONTH(dNgaylap) as 'thang', sum(mTienkhachtra) as 'doanhthu'
	                                from tblHoadon
	                                where '" + nbd + @"' <= dNgaylap and dNgaylap <= '" + nkt + @"'
	                                group by   YEAR(dNgaylap) , MONTH(dNgaylap)
                                	ORDER BY nam ASC";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    SqlDataAdapter data = new SqlDataAdapter(sql, cnn);
                    DataTable abc = new DataTable();
                    data.Fill(abc);
                    string them = "";
                    int nam = 0;
                    if (abc.Rows.Count > 0)
                    {
                        nam = int.Parse(abc.Rows[0]["nam"].ToString());
                        them += @"
                                    <table style='width:50%'>
                                    <tr>
                                        <th colspan='2'>" + nam + @"</td>
                                      </tr>
                                        <tr> 
                                            <td>Tháng</th>
                                            <td>Doanh Thu</th>
                                          </tr>";
                        for (int i = 0; i < abc.Rows.Count; i++)
                        {
                            if (nam != int.Parse(abc.Rows[i]["nam"].ToString())) {
                                nam = int.Parse(abc.Rows[i]["nam"].ToString());
                                them += @"<tr>
                                        <th colspan='2'>"+nam+@"</th>
                                      </tr>
                                         <tr> 
                                            <td>Tháng</th>
                                            <td>Doanh Thu</th>
                                          </tr>";
                            }
                            them += @" <tr>
                                            <td>" + abc.Rows[i]["thang"].ToString() + @"</td>
                                            <td>" + abc.Rows[i]["doanhthu"].ToString() + @"</td>
                                          </tr>";
                            tong += float.Parse(abc.Rows[i]["doanhthu"].ToString());

                        }
                        them += @" <tr>
                                        <td>Tổng</td>
                                        <td>" + tong + @",000 đồng</td>
                                   </tr>";
                        TK_BC.InnerHtml = them;
                    }
                    else
                    {
                        them += "<dic class='item'><p>Không có dữ liệu!</p></div>";
                        TK_BC.InnerHtml = them;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void TK_TC_Nam_Click(object sender, EventArgs e)
        {
            string nbd = Request.Form["ngaybatdau_tc"];
            string nkt = Request.Form["ngayketthuc_tc"];
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    string sql = @"select YEAR(dNgaylap) as 'nam', sum(mTienkhachtra) as 'doanhthu'
	                                from tblHoadon
	                                where '" + nbd + @"' <= dNgaylap and dNgaylap <= '" + nkt + @"'
	                                group by  YEAR(dNgaylap)
                                	ORDER BY nam ASC";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    SqlDataAdapter data = new SqlDataAdapter(sql, cnn);
                    DataTable abc = new DataTable();
                    data.Fill(abc);
                    string them = "";
                    float tong = 0;
                    if (abc.Rows.Count > 0)
                    {
                        them += @" <table style='width:50%'>
                                        <tr> 
                                            <td>Tháng</th>
                                            <td>Doanh Thu</th>
                                          </tr>";
                        for (int i = 0; i < abc.Rows.Count; i++)
                        {
                            them += @" <tr>
                                            <td>" + abc.Rows[i]["nam"].ToString() + @"</td>
                                            <td>" + abc.Rows[i]["doanhthu"].ToString() + @"</td>
                                          </tr>";
                            tong += float.Parse(abc.Rows[i]["doanhthu"].ToString()) ;

                        }
                        them += @" <tr>
                                        <td>Tổng</td>
                                        <td>" + tong + @",000 đồng</td>
                                   </tr>";
                        TK_BC.InnerHtml = them;
                        /*
                        for (int i = 0; i < abc.Rows.Count; i++)
                        {
                               dt = abc.Rows[i]["doanhthu"].ToString();
                            tong = tong + Int32.Parse(dt);
                            //them+="<div class='item item1'><p>Không co dữ liệu!</p></div>;
                        }
                        them += @" <tr>
                                    <td>Tổng doanh thu </td>
                                    <td>" + tong + @"</td>
                                 </tr>";
                        TK_BC.InnerHtml = them;*/
                    }
                    else
                    {
                        them += "<dic class='item'><p>Không có dữ liệu!</p></div>";
                        TK_BC.InnerHtml = them;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}
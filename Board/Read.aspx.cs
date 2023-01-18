using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.OleDb;

namespace 허혜민_인사관리.Board
{
    public partial class Read : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                if(Request.QueryString["id"] == null)
                {
                    Response.Redirect("~/Board");

                }


                View(int.Parse(Request.QueryString["id"].ToString()));
            }
        }

        protected void View(int id)
        {
            string sql = "select * from Board where id = " + id;
            string sql2 = "update Board set read_count = read_count+1 where id =" + id;

            DBConn conn = new DBConn();
            OleDbDataReader dr = conn.ExecuteReader(sql);
            conn.ExecuteReader(sql2);

            if (dr.Read())
            {

                lb_title.Text = dr["title"].ToString();
                lb_writer.Text = dr["writer"].ToString();
                lb_count.Text = dr["read_count"].ToString();
                lbDate.Text = dr["reg_date"].ToString();

                string title = dr["title"].ToString().Replace("\n", "<br />");

                lb_Message.Text = dr["message"].ToString();
                HyperLink7.Text = dr["file1"].ToString();

                if (dr["file1"].ToString() != "")
                {
                    HyperLink7.Text = dr["file1"].ToString();
                    HyperLink7.NavigateUrl = "~/pub/" + dr["file1"].ToString();
                }
                else
                {
                   // Response.Redirect("~/Board/");
                }
            }

            dr.Close();
            conn.Close();
        }
        protected void Imgbt_edit_Click(object sender, ImageClickEventArgs e)
        {
            //수정

            Response.Redirect("~/Board/Write.aspx?id=" + Request.QueryString["id"].ToString() + "&mode=edit");

        }


        protected void Imgbt_reply_Click(object sender, ImageClickEventArgs e)
        {
            //답글

            int id = int.Parse(Request.QueryString["id"]);
            Response.Redirect("~/Board/Reply.aspx?id=" + id);

        }

        protected void Imgbt_del_Click(object sender, ImageClickEventArgs e)
        {
            //삭제 버튼
            if(Session["id"].ToString() != "admin" && 
                Session["id"].ToString() != lb_writer.Text)
            {
                Response.Write("<script>alert('삭제할 권한이 없음')</script>");
                return;
            }


            //삭제
            string sql = "update board set del_flag ='1' where id=" +
                Request.QueryString["id"].ToString();
            DBConn conn = new DBConn();
            conn.ExecuteNonQuery(sql);
            conn.Close();
            Response.Redirect("~/Board/");


        }

        

        protected void Imgbt_list_Click(object sender, ImageClickEventArgs e)
        {
            //리스트
            Response.Redirect("~/Board/");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            //신고
            Response.Redirect("~/complain/");

        }
    }
}
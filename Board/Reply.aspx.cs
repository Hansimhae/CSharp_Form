using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.OleDb;

namespace 허혜민_인사관리.Board
{
    public partial class Reply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["id"].ToString() == "" || Session["id"] == null)
           {
                Response.Redirect("~/");
           }

            //txt_title.Text = Request.QueryString["id"];
        }

        protected void imgbt_save_Click(object sender, ImageClickEventArgs e)
        {
            //저장

            if (txt_title.Text.Trim() == "")
            {
                Response.Write("<script>alert('제목 입력');</script>");
                txt_title.Focus();
                return;
            }

            if (txt_mes.Text.Trim() == "")
            {
                Response.Write("<script>alert('내용 입력');</script>");
                txt_mes.Focus();
                return;
            }


            string sql = "insert into Board(writer, title, message," +
                "ref_id, inner_id, depth, read_count, del_flag, reg_date) " +
                "values(@writer, @title, @message," +
                    "@ref_id, @inner_id, @depth, @read_count, @del_flag, @reg_date)";

           
            string sql_r = "select ref_id, inner_id, depth from board where id =" +
                Request.QueryString["id"];

            int ref_id = 0;
            int inner_id = 0;
            int depth = 0;

            DBConn conn = new DBConn();
            OleDbDataReader dr = conn.ExecuteReader(sql_r);
            
            if (dr.Read())
            {
                ref_id = (int)dr["ref_id"];
                inner_id = (int)dr["inner_id"];
                depth = (int)dr["depth"];
            }
            dr.Close();

            //string sql_i = "update Board set inner_id=inner_id+1 where ref_id=" + ref_id;
            //conn.ExecuteNonQuery(sql_i);

            OleDbCommand cmd = new OleDbCommand(sql, conn.GetConn());

            cmd.Parameters.AddWithValue("@writer", Session["id"].ToString());
            cmd.Parameters.AddWithValue("@title", txt_title.Text);
            cmd.Parameters.AddWithValue("@message", txt_mes.Text);
            cmd.Parameters.AddWithValue("@ref_id", 0);

            cmd.Parameters.AddWithValue("@inner_id", ++inner_id);
            cmd.Parameters.AddWithValue("@depth", ++depth);
            cmd.Parameters.AddWithValue("@read_count", 0);
            cmd.Parameters.AddWithValue("@del_flag", "0");
            cmd.Parameters.AddWithValue("@ref_id", DateTime.Now.ToString());

            string sql_u = "update Board set ref_id = " + ref_id + " where ref_id=0";

            try
            {
                cmd.ExecuteNonQuery();
                Response.Write("script>alert('저장됨')</script>");
                conn.ExecuteNonQuery(sql_u);
            }

            catch
            { }
            
            finally
            {
                conn.Close();
            }
            Response.Redirect("~/Board");

        }

    }
}

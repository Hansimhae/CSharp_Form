using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 허혜민_인사관리.Board
{
    public partial class complain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session["id"].ToString() == "" || Session["id"] == null)
                {
                    Response.Redirect("~/Board");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //저장
            if(TextBoxtitle.Text.Trim() == "")
            {
                Response.Write("<script>alert('제목 입력');</script>");
                TextBoxtitle.Focus();
                return;
            }

            if (TextBoxMes.Text.Trim() == "")
            {
                Response.Write("<script>alert('내용 입력');</script>");
                TextBoxMes.Focus();
                return;
            }

            string sql = "";

            sql = "insert into Complain(writer, title, message," +
                "ref_id, reg_date) " +
                "values(@writer, @title, @message," +
                "@ref_id, @reg_date)";


            DBConn conn = new DBConn();
            OleDbCommand cmd = new OleDbCommand(sql, conn.GetConn());

            cmd.Parameters.AddWithValue("@writer", Session["id"].ToString());
            cmd.Parameters.AddWithValue("@title", TextBoxtitle.Text.Trim());
            cmd.Parameters.AddWithValue("@message", TextBoxMes.Text);

            cmd.Parameters.AddWithValue("@ref_id", 0);
            cmd.Parameters.AddWithValue("@reg_date", DateTime.Now.ToString());

            string sql_i = "update Complain set ref_id=id where ref_id=0";

            //try
            {
                cmd.ExecuteNonQuery();
                Response.Write("script>alert('저장됨')</script>");
                conn.ExecuteNonQuery(sql_i);
            }
            //catch
            { }
            //finally
            {
                conn.Close();
            }
            Response.Write("script>alert('저장됨')</script>");
            Response.Redirect("~/Board");


        }
    }
}
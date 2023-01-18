using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.OleDb;
using System.IO;

namespace 허혜민_인사관리.Board
{
    public partial class Write : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["id"].ToString() == "" || Session["id"] == null)
                {
                    Response.Redirect("~/Board");
                }
                if (!IsPostBack)
                {
                    if(Request.QueryString["mode"] != null)
                    {
                        if(Request.QueryString["mode"].ToString() == "edit")
                        {
                            lbTitle.Text = "글수정";

                            string sql = "select title, message from board " +
                                "where id =" + Request.QueryString["id"];

                            DBConn conn = new DBConn();
                            OleDbDataReader dr = conn.ExecuteReader(sql);

                            if (dr.Read())
                            {
                                txttitle.Text = dr["title"].ToString();
                                txtmes.Text = dr["message"].ToString();
                                FileUpload1.FileName.ToString();
                            }
                            dr.Close();
                            conn.Close();
                        }
                    }
                }
            }
        }
        public string DuplicateFile(string dir, string filename)
        {
            string file = Path.GetFileNameWithoutExtension(filename);
            string ext = Path.GetExtension(filename);
            string new_filename = filename;
            int cnt = 1;
            while (File.Exists(new_filename))
            {
                string temp_filename = String.Format("{0}({1})", file, cnt++);
                new_filename = Path.Combine(dir + "\\" + temp_filename + ext);
            }
            return new_filename;
        }
        

        protected void ibtsave_Click(object sender, ImageClickEventArgs e)
        {
            if(txttitle.Text.Trim() == "")
            {
                Response.Write("<script>alert('제목 입력');</script>");
                txttitle.Focus();
                return;
            }

            if(txtmes.Text.Trim() == "")
            {
                Response.Write("<script>alert('내용 입력');</script>");
                txttitle.Focus();
                return;
            }

            string sql = "";

            if (Request.QueryString["mode"] != "edit") {
                sql = "insert into Board(writer, title, file1, file1_size, message," +
                "ref_id, inner_id, depth, read_count, del_flag, reg_date) " +
                "values(@writer, @title, @file1, @file1_size, @message," +
                "@ref_id, @inner_id, @depth, @read_count, @del_flag, @reg_date)";
            }
            else
            {
                sql="update Board set " +
                    "writer=@writer, title=@title, file1=@file1, file1_size=@file1_size, message=@message," +
                    "ref_id=@ref_id, inner_id=@inner_id, depth=@depth, read_count=@read_count, del_flag=@del_flag, reg_date=@reg_date "+
                    "where id=" + Request.QueryString["id"];
            }
            string sql_i = "update Board set ref_id=id where ref_id=0";

            //파일 첨부
            string filename = "";
            int file_size = 0;

            if (FileUpload1.HasFile) //첨부 파일 있으면
            {
                string filename2 = Server.MapPath("~/pub") + @"\" +
                    FileUpload1.FileName;
                if (File.Exists(filename2))
                    filename2 = DuplicateFile(Server.MapPath("~/pub"), FileUpload1.FileName);

                FileUpload1.SaveAs(filename2);
                file_size = FileUpload1.PostedFile.ContentLength; //바이트
                filename = FileUpload1.FileName;
            }


            DBConn conn = new DBConn();
            OleDbCommand cmd = new OleDbCommand(sql, conn.GetConn());

            cmd.Parameters.AddWithValue("@writer", Session["id"].ToString());
            cmd.Parameters.AddWithValue("@title", txttitle.Text.Trim());
            cmd.Parameters.AddWithValue("@file1", filename);
            cmd.Parameters.AddWithValue("@file1_size", file_size);
            cmd.Parameters.AddWithValue("@message", txtmes.Text);

            cmd.Parameters.AddWithValue("@ref_id", 0);
            cmd.Parameters.AddWithValue("@inner_id", 0);
            cmd.Parameters.AddWithValue("@depth", 0);
            cmd.Parameters.AddWithValue("@read_count", 0); 
            cmd.Parameters.AddWithValue("@del_flag", "0");
            cmd.Parameters.AddWithValue("@reg_date", DateTime.Now.ToString());

            //try
            {
                cmd.ExecuteNonQuery();
                Response.Write("script>alert('저장됨')</script>");
                conn.ExecuteNonQuery(sql_i);
            }
            //catch
            {}
            //finally
            {
                conn.Close();
            }
            Response.Redirect("~/Board");

        }

        protected void ibt_rt_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
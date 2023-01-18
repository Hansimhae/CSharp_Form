using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;

namespace 허혜민_인사관리
{
    public partial class Insa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["id"].ToString()=="" || Session["id"] == null)
                {
                    Response.Redirect("~/");
                }

                lbInsert.Text = "insert";

                재직상태();
                직급();
                부서();
            }
        }

        protected void 부서()
        {
            DBConn conn = new DBConn();
            //Response.Write("<script>alert('DB에 연결');</script>");

            string sql = "select 부서명 from 부서";
            OleDbDataReader dr = conn.ExecuteReader(sql);
            while (dr.Read())
            {
                DropDownList부서.Items.Add(dr["부서명"].ToString());

            }
            DropDownList부서.SelectedIndex = 0;
            dr.Close();
            conn.Close();
        }

        protected void 재직상태()
        {
            DropDownList재직상태.Items.Add("재직");
            DropDownList재직상태.Items.Add("휴직");
            DropDownList재직상태.Items.Add("퇴사");
            DropDownList재직상태.SelectedIndex = 0;
        }


        protected void 직급()
        {
            DropDownList직급.Items.Add("사장");
            DropDownList직급.Items.Add("부장");
            DropDownList직급.Items.Add("과장");
            DropDownList직급.Items.Add("대리");
            DropDownList직급.Items.Add("사원");
            DropDownList직급.SelectedIndex = 4;
        }

        protected void Button_save_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (lbInsert.Text == "insert")
            {
                sql = "insert into 인사 (이름,성별,생년월일,재직상태," +
                    "입사일자,퇴사일자,부서명,직급,사진파일명," + 
                    "전화,주소, isDel,사원번호)" +
                    "values(@이름,@성별,@생년월일,@재직상태," +
                    "@입사일자,@퇴사일자,@부서명,@직급,@사진파일명," +
                    "@전화,@주소,@isDel ,@사원번호)";
            }
            else
            {
                sql = "update 인사 set 이름=@이름, 성별=@성별, 생년월일=@생년월일, 재직상태=@재직상태," +
                    "입사일자=@입사일자, 퇴사일자=@퇴사일자, 부서명=@부서명, 직급=@직급, 사진파일명=@사진파일명," +
                    "전화=@전화, 주소=@주소, isDel=@isDel where 사원번호=@사원번호";

            }

            if(TextBox사원번호.Text.Trim() == "")
            {
                Response.Write("<script>alert('사원번호를 입력하시오');</script>");
                TextBox사원번호.Focus();
                return;
            }
            if(TextBox이름.Text.Trim() == "")
            {
                Response.Write("<script>alert('이름을 입력하시오');</script>");
                TextBox이름.Focus();
                return;
            }

            string 성별 = "0";
            if (rd_f.Checked == true) 성별 = "1";
            else if (rb_m.Checked == true) 성별 = "2";

            string picFile = "";

            if (FileUpload1.HasFile)
            {
                string file1 = Server.MapPath("/pic") +
               "\\" + FileUpload1.FileName;

                // 파일명 중복 체크
                if (File.Exists(file1))
                    file1 = Server.MapPath("/pic") +
               "\\" + TextBox사원번호.Text + "_" + FileUpload1.FileName;

                FileUpload1.SaveAs(file1);
                picFile = TextBox사원번호.Text + "_" + FileUpload1.FileName;


            }


            DBConn conn = new DBConn();
            OleDbCommand cmd = new OleDbCommand(sql, conn.GetConn());

            cmd.Parameters.AddWithValue(" @이름", TextBox이름.Text.Trim());
            cmd.Parameters.AddWithValue("@성별", 성별);
            cmd.Parameters.AddWithValue("@생년월일", TextBox생년월일.Text);
            cmd.Parameters.AddWithValue("@재직상태", DropDownList재직상태.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@입사일자", TextBox입사일자.Text);
            cmd.Parameters.AddWithValue("@퇴사일자", "");
            cmd.Parameters.AddWithValue("@부서명", DropDownList부서.SelectedItem.ToString());
            cmd.Parameters.AddWithValue(",@직급", DropDownList직급.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@사진파일명", picFile);
            cmd.Parameters.AddWithValue("@전화", TextBox전화.Text.Trim());
            cmd.Parameters.AddWithValue("@주소", TextBox주소.Text.Trim());
            cmd.Parameters.AddWithValue(",@isDel", "0");
            cmd.Parameters.AddWithValue(",@사원번호", TextBox사원번호.Text.Trim());

            try
            {
                cmd.ExecuteNonQuery();
                Response.Write("< script > alert('저장됨')</script >");
            }
            catch(Exception ee)
            {
                Response.Write("< script > alert('" + ee.Message + "')</script >");
            }
            finally
            {
                conn.Close();
            }

        }
        
        protected void TextClear()
        {
            TextBox사원번호.Text = "";
            TextBox이름.Text = "";
            TextBox생년월일.Text = "";
            TextBox입사일자.Text = "";
            TextBox퇴사일자.Text = "";
            TextBox전화.Text = "";
            TextBox주소.Text = "";
            rd_f.Checked = false;
            rb_m.Checked = false;

            ImgPic.ImageUrl = "";

            lbInsert.Text = "insert";
        }

        protected void Button_clear_Click(object sender, EventArgs e)
        {
            TextClear();
        }

        protected void Button_search_Click(object sender, EventArgs e)
        {
            if (TextBox사원번호.Text.Trim() == "")
            {
                Response.Write("<script>alert('사원번호를 입력하시오');</script>");
                TextBox사원번호.Focus();
                return;
            }

            string sql = "select * from 인사 where 사원번호='" + TextBox사원번호.Text.Trim() + "'";
            DBConn conn = new DBConn();
            OleDbDataReader dr = conn.ExecuteReader(sql);
            if (dr.Read())
            {
                if (dr["isDel"].ToString() == "1")
                {
                    Response.Write("<script>alert('삭제된 사원') </script>");
                }
                else
                {

                    TextBox이름.Text = dr["이름"].ToString();

                    if (dr["성별"].ToString() == "1") rd_f.Checked = true;
                    else if (dr["성별"].ToString() == "2") rb_m.Checked = true;

                    //사진파일 출력
                    if (dr["사진파일명"].ToString() != "")
                    {
                        try
                        {
                            ImgPic.ImageUrl = "~/pic/" + dr["사진파일명"].ToString();
                        }
                        catch
                        {

                        }
                        finally
                        {

                        }
                    }


                    TextBox생년월일.Text = dr["생년월일"].ToString();
                    TextBox입사일자.Text = dr["입사일자"].ToString();
                    TextBox퇴사일자.Text = dr["퇴사일자"].ToString();
                    TextBox전화.Text = dr["전화"].ToString();
                    TextBox주소.Text = dr["주소"].ToString();

                    DropDownList부서.Text = dr["부서명"].ToString();
                    DropDownList직급.Text = dr["직급"].ToString();
                    DropDownList재직상태.Text = dr["재직상태"].ToString();

                    lbInsert.Text = "update";

                }
            }
            else
            {
                Response.Write("<script>alert('등록 사원이 아님') </script>");
                TextClear();
            }
            dr.Close();
            conn.Close();
        }

        protected void Button_delete_Click(object sender, EventArgs e)
        {

            if(lbInsert.Text != "update")
            {
                Response.Write("<script>alert('삭제할 자료를 먼저 조회하세요') </script>");
                TextBox사원번호.Focus();
                return;
            }

            string sql = "update 인사 set isDel = '1' where 사원번호='" +
                TextBox사원번호.Text + "'";

            DBConn conn = new DBConn();
            conn.ExecuteNonQuery(sql);
            conn.Close();
            TextClear();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;

namespace 허혜민_인사관리
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Panel2.Visible = false;

                //
                //txt_id.Text = "abc";
            }
            if (Session["id"] == null || Session["id"].ToString() == "")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
            }
            else
            {
                LabelId.Text = Session["id"].ToString();
                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = true;
            }

            lbCounter.Text = String.Format("{0:N0}", (int)Application["counter"]);
        }

        protected void Button_login_Click(object sender, EventArgs e)
        {
            //로그인
            if(txt_id.Text.Trim() == "")
            {
                MessageBox.Show("로그인 아이디를 입력하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_id.Focus();
                return;
            }
            if (txt_pw.Text.Trim() == "")
            {
                MessageBox.Show("로그인 비밀번호를 입력하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_pw.Focus();
                return;
            }

            string sql = "select m_pwd from member where m_id='" +
                txt_id.Text + "'";
            string pwd = Util.MD5Hash(txt_pw.Text);

            DBConn conn = new DBConn();
            OleDbCommand cmd = new OleDbCommand(sql, conn.GetConn());
            cmd.Parameters.AddWithValue("@id", txt_id.Text);

            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if(dr["m_pwd"].ToString() == pwd)
                {
                    Session["id"] = txt_id.Text;
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel3.Visible = true;
                }
                else
                {
                    //암호가 틀린 경우
                    MessageBox.Show("비밀번호 틀림", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               
            }
            else //ID가 등록 X 
            {
                return;
            }

            Session["id"] = txt_id.Text.Trim();
            LabelId.Text = txt_id.Text.Trim();

            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = true;
        }

        protected void Button_logout_Click(object sender, EventArgs e)
        {
            Session.Abandon(); //모든 세션 정보 삭제

            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel2.Visible = false;

        }
    }
}
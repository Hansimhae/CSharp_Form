using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 허혜민_인사관리.member
{
    public partial class MemberAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btsave_Click(object sender, ImageClickEventArgs e)
        {
            if (txtID.Text.Trim() == "")
            {
                Label1.Text = "ID 입력 필요";
                txtID.Focus();
                return;
            }

            string sql = "insert into member(m_id, m_name, m_pwd," +
                "m_email, m_reg_date, f_del_flag) " +
                "values(@m_id,  @m_name, @m_pwd, @m_email, @m_reg_date, @f_del_flag)";

            string pwd = Util.MD5Hash(txtPwd.Text.Trim()); //암호화된 문자

            DBConn conn = new DBConn();

            OleDbCommand cmd = new OleDbCommand(sql, conn.GetConn());

            cmd.Parameters.AddWithValue("@m_id", txtID.Text.Trim());
            cmd.Parameters.AddWithValue("@m_name", txtname.Text);
            cmd.Parameters.AddWithValue("@m_pwd", pwd);
            cmd.Parameters.AddWithValue("@m_email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@m_reg_date", 
                DateTime.Now.ToString("yyy-MM-dd hh:mm;ss"));
            cmd.Parameters.AddWithValue("@f_del_flag", "0");
            cmd.ExecuteNonQuery();
            try
            {
                
                Label1.Text = "가입 됨";
            }
            catch(Exception ee)
            {
                Label1.Text = ee.Message + "회원가입 실패";
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
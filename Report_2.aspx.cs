using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 허혜민_인사관리
{
    public partial class Report_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"].ToString() == "" || Session["id"] == null)
            {

            }
            if (!IsPostBack)
            {
                Report2();
            }
        }

        private void Report2()
        {

            string sql = "select * from 인사 where isDel ='1' order by 사원번호";
            DBConn conn = new DBConn();
            OleDbDataReader dr = conn.ExecuteReader(sql);

            Response.Write("<span id='table_title'>사원 리스트(삭제 사원)</span>");

            Response.Write("<table>");

            Response.Write("<tr id=''>");
            Response.Write("<th>사원번호</th>");
            Response.Write("<th>이름</th>");
            Response.Write("<th>성별</th>  ");
            Response.Write("<th>생년월일</th>     ");
            Response.Write("<th>부서명</th>   ");
            Response.Write("<th>직급</th>   ");
            Response.Write("<th>전화</th>   ");
            Response.Write("</tr>");

            while (dr.Read())
            {
                Response.Write("<tr>");
                Response.Write("<td id='col1' class='center'> " + dr["사원번호"].ToString() + "</td> ");
                Response.Write("<td id='col2'>" + dr["이름"].ToString() + "</td>");
                Response.Write("<td id='col3'>" + dr["성별"].ToString() + "</td>");
                Response.Write("<td id='col4'>" + dr["생년월일"].ToString() + "</td>");
                Response.Write("<td id='col7'>" + dr["부서명"].ToString() + "</td>");
                Response.Write("<td id='col7'>" + dr["직급"].ToString() + "</td>");
                Response.Write("<td id='col7'>" + dr["전화"].ToString() + "</td>");
                Response.Write("</tr>");
            }
            Response.Write("</table>");
        }
    }    
}

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 허혜민_인사관리.Board
{
    public partial class Complain_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"].ToString() == "" || Session["id"] == null)
            {

            }
            if (!IsPostBack)
            {
                Complain_report();
            }
        }

        private void Complain_report()
        {
            string sql = "select * from Complain order by writer";

            DBConn conn = new DBConn();
            OleDbDataReader dr = conn.ExecuteReader(sql);

            Response.Write("<span id='table_title'>신고 목록</span>");

            Response.Write("<table>");

            Response.Write("<tr id=''>");
            Response.Write("<th>신고자</th>");
            Response.Write("<th>제목</th>");
            Response.Write("<th>내용</th>  ");
            Response.Write("<th>작성일</th>     ");
            Response.Write("</tr>");

            while (dr.Read())
            {

                Response.Write("<tr>");
                Response.Write("<td id='col1' class='center'> " +dr["writer"].ToString() + "</td>");
                Response.Write("<td id='col3'>" + dr["title"].ToString() + "</td>");
                Response.Write("<td id='col8'>" + dr["message"].ToString() + "</td>");
                Response.Write("<td id='col7'>" + dr["reg_date"].ToString() + "</td>");
                Response.Write("</tr>");


            }
            Response.Write("</table>");
        }
    }
}
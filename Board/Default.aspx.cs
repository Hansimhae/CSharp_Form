using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2012118_허혜민_인사관리.Board
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string ShowDepth(int depth)
        {
            string s = "";
            for (int i = 0; i < depth; i++)
                s += "&nbsp;&nbsp;&nbsp;&nbsp;";
            return s;
        }

        protected string ShowReplayIcon(int inner_id)
        {
            string s = "";
            if(inner_id != 0)
                s += "<img src = '../img/reply_icon.gif' />";
            return s;

        }

        protected string ShowTitle(int id, string title, string del_flag)
        {
            string s = "";
            if (del_flag == "0")
            {
                s += "<a href ='Read.aspx?id=" + id;
                s += "' class='a01'>" + title + " </a>";
            }
            else
                s += " 삭제된 게시물";

            return  s;
        }

        protected string ShowDate(string reg_date)
        {
            return "<span style='font-size:12px'>" + reg_date.Substring(0,10);
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
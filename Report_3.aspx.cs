using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 허혜민_인사관리
{
    public partial class Report_3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"].ToString() == "" || Session["id"] == null)
            {

            }
            if (!IsPostBack)
            {
               
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Ch9Demo
{
    public partial class BookList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.GetRecordCount();
                this.BindGridView(0);
            }
        }
        string strCn = "Data Source=DESKTOP-59QO6AC;Initial Catalog=db_LibraryMS;Integrated Security=True;User ID=sa;Password=123456";
        protected void GetRecordCount()
        {
            
            SqlConnection cn = new SqlConnection(strCn);
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "select count(*) from tb_bookinfo where bookname like @BookName";
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar, 30).Value = "%" + txtSelect.Text.Trim() + "%";
            cn.Open();
            this.AspNetPager1.RecordCount = (int)cmd.ExecuteScalar();
            cn.Close();
        }
        protected void BindGridView(int pageIndex)
        {
            
            SqlConnection cn = new SqlConnection(strCn);
            string strSql = "select * from tb_bookinfo where bookname like @BookName order by bookcode offset " + pageIndex * this.AspNetPager1.PageSize
                + " rows fetch next " + this.AspNetPager1.PageSize + " rows only";
            SqlDataAdapter da = new SqlDataAdapter(strSql, cn);
            da.SelectCommand.Parameters.Add("@BookName", SqlDbType.NVarChar, 30).Value = "%" + txtSelect.Text.Trim() + "%";
            DataSet ds = new DataSet();
            da.Fill(ds, "bookinfo");
            cn.Close();
            this.GridView1.DataSource = ds.Tables["bookinfo"].DefaultView;
            this.GridView1.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            this.GetRecordCount();
            this.BindGridView(0);
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("BookDetail.aspx?State=Edit&bookcode=" + GridView1.DataKeys[e.NewEditIndex].Value);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DeleteBook(GridView1.DataKeys[e.RowIndex].Value.ToString());
            this.GetRecordCount();
            this.BindGridView(this.AspNetPager1.CurrentPageIndex-1);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName =="Detail")
            {
                Response.Redirect("BookDetail.aspx?State=Detail&BookCode="+e.CommandArgument.ToString());
            }
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            this.BindGridView(this.AspNetPager1.CurrentPageIndex-1);
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookDetail.aspx?State=Insert");
        }

        private void DeleteBook(string bookCode)
        {
            lblMessage.Text = "";
            
            SqlConnection cn = new SqlConnection(strCn);
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "delete from tb_bookinfo where bookcode=@BookCode";
            cmd.Parameters.Add("@BookCode", SqlDbType.NVarChar, 50).Value = bookCode;
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('删除成功！')</script>");
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
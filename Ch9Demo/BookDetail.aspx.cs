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
    public partial class BookDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string state="";
                string bookCode="";
                if (Request["State"] != null)
                { 
                    state = Request["State"].ToString();
                    this.ViewState["State"] = state;
                }
                if ((state == "Edit") || (state == "Detail"))
                {
                    if (Request["BookCode"] != null)
                    {
                        bookCode = Request["BookCode"].ToString();
                        this.BindControl(bookCode);
                    }
                    EnableControl(state == "Edit");
                }
            }
        }

        private void EnableControl(bool flag)
        {
            txtBookCode.Enabled = flag;
            txtBookName.Enabled = flag;
            txtType.Enabled = flag;
            txtAuthor.Enabled = flag;
            txtTranslator.Enabled = flag;
            txtPubName.Enabled = flag;
            txtPrice.Enabled = flag;
            txtPage.Enabled = flag;
            btnOK.Visible = flag;
            lblBookCodeRequied.Visible = flag;
            lblBookNameRequied.Visible = flag;
            lblPriceRequied.Visible = flag;
            lblPageRequied.Visible = flag;
        }
        private void BindControl(string bookCode)
        {
            string strCn = "Data Source=.;Initial Catalog=db_LibraryMS;Persist Security Info=True;User ID=sa;Password=cmscxlctx!@#";
            SqlConnection cn = new SqlConnection(strCn);
            string strSql = "select * from tb_bookinfo where bookcode = @BookCode";
            SqlCommand cmd = new SqlCommand(strSql, cn);
            cmd.Parameters.Add("@BookCode", SqlDbType.NVarChar, 50).Value = bookCode;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    hfBookCode.Value = bookCode;
                    txtBookCode.Text = bookCode;
                    txtBookName.Text = dr["bookname"].ToString();
                    txtType.Text = dr["type"].ToString();
                    txtAuthor.Text = dr["author"].ToString();
                    txtTranslator.Text = dr["translator"].ToString();
                    txtPubName.Text = dr["pubname"].ToString();
                    txtPrice.Text = dr["price"].ToString();
                    txtPage.Text = dr["page"].ToString();
                }
                dr.Close();
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
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (this.ViewState["State"].ToString() == "Insert")
            { 
                InsertBook();
            }
            else if (this.ViewState["State"].ToString() == "Edit")
            {
                UpdateBook();
            }
        }

        private void UpdateBook()
        {
            lblMessage.Text = "";
            string strCn = "Data Source=.;Initial Catalog=db_LibraryMS;Persist Security Info=True;User ID=sa;Password=cmscxlctx!@#";
            SqlConnection cn = new SqlConnection(strCn);
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "update tb_bookinfo set bookcode=@BookCode,bookname=@BookName,type=@Type,author=@Author,translator=@Translator,"
                + "pubname=@PubName,price=@Price,page=@Page where bookcode = @OldBookCode";
            cmd.Parameters.Add("@BookCode", SqlDbType.NVarChar, 50).Value = txtBookCode.Text.Trim();
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar, 50).Value = txtBookName.Text.Trim();
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = txtType.Text.Trim();
            cmd.Parameters.Add("@Author", SqlDbType.NVarChar, 50).Value = txtAuthor.Text.Trim();
            cmd.Parameters.Add("@Translator", SqlDbType.NVarChar, 50).Value = txtTranslator.Text.Trim();
            cmd.Parameters.Add("@PubName", SqlDbType.NVarChar, 100).Value = txtPubName.Text.Trim();
            cmd.Parameters.Add("@Price", SqlDbType.Money).Value = decimal.Parse(txtPrice.Text.Trim());
            cmd.Parameters.Add("@Page", SqlDbType.Int).Value = int.Parse(txtPage.Text.Trim());
            cmd.Parameters.Add("@OldBookCode", SqlDbType.NVarChar, 50).Value = hfBookCode.Value.ToString();
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('修改成功！')</script>");
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
        private void InsertBook()
        {
            lblMessage.Text = "";
            string strCn = "Data Source=.;Initial Catalog=db_LibraryMS;Persist Security Info=True;User ID=sa;Password=cmscxlctx!@#";
            SqlConnection cn = new SqlConnection(strCn);
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "insert into tb_bookinfo(bookcode,bookname,type,author,translator,pubname,price,page) "
                + "values(@BookCode,@BookName,@Type,@Author,@Translator,@PubName,@Price,@Page)";
            cmd.Parameters.Add("@BookCode", SqlDbType.NVarChar, 30).Value = txtBookCode.Text.Trim();
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar, 50).Value = txtBookName.Text.Trim();
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = txtType.Text.Trim();
            cmd.Parameters.Add("@Author", SqlDbType.NVarChar, 50).Value = txtAuthor.Text.Trim();
            cmd.Parameters.Add("@Translator", SqlDbType.NVarChar, 50).Value = txtTranslator.Text.Trim();
            cmd.Parameters.Add("@PubName", SqlDbType.NVarChar, 100).Value = txtPubName.Text.Trim();
            cmd.Parameters.Add("@Price", SqlDbType.Money).Value = decimal.Parse(txtPrice.Text.Trim());
            cmd.Parameters.Add("@Page", SqlDbType.Int).Value = int.Parse(txtPage.Text.Trim());
            try
            { 
                cn.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('添加成功！')</script>");
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

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookList.aspx");
        }
    }
}
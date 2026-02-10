using RentalRoom.DataAccess;
using RentalRoom.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentalRoom.Login
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Errorlbl.Text = "";
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    Response.Redirect("../HomePage.aspx");
                }

            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SignInBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Username.Text) || string.IsNullOrEmpty(Password.Text))
            {
                Errorlbl.Text = "Please enter valid username and password.";
                return;
            }
            using (SqlConnection con = DbHelper.GetConnection())
            {
                string query = "insert into Users (Username, PasswordHash, Role) values (@Username, @Password, @Role)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", Username.Text);
                cmd.Parameters.AddWithValue("@Password", PasswordHelper.HashPassword(Password.Text));
                string str1 = PasswordHelper.HashPassword(Password.Text);
                cmd.Parameters.AddWithValue("@Role", RoleButtonList1.SelectedValue);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            Errorlbl.Text = "Successfully Signed In, Please login";
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
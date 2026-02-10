using RentalRoom.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentalRoom.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ErrorTextlogin.Text = "";
            }
        }

        protected void LoginId_Click(object sender, EventArgs e)
        {
            using(SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "select Username, PasswordHash, Role from Users where Username = @Username and PasswordHash = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", UsernameBox.Text);
                cmd.Parameters.AddWithValue("@Password", Utilities.PasswordHelper.HashPassword(PasswordBox.Text.Trim()));
                string str = Utilities.PasswordHelper.HashPassword(Password.Text);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Session["User"] = reader["Username"].ToString();
                    Session["Role"] = reader["Role"].ToString();

                    if (Session["Role"].ToString() == "Admin")
                    {
                        Response.Redirect("/Admin/Room.aspx");
                    }
                    else
                    {
                        Response.Redirect("/User/PriceCalculator.aspx");
                    }
                }
                else
                {
                    ErrorTextlogin.Text = "Invalid credentials";
                }
            }
        }
    }
}
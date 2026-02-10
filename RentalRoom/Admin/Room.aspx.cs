using RentalRoom.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentalRoom.Admin
{
    public partial class Room : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRooms();
            }
        }

        private void LoadRooms()
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "SELECT RoomId, Room_Name, Base_Price, isActive FROM Room";
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(GridView1.SelectedRow != null)
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    string query = "SELECT RoomId, Room_Name, Base_Price, isActive FROM Room where RoomId = @Id";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        RoomTextBox.Text = reader["Room_Name"].ToString();
                        BasePriceTxtBox.Text = reader["Base_Price"].ToString();
                        bool isActive = (bool)reader["isActive"];
                        isActiveRadioBtn.SelectedValue = isActive ? "1":"0";
                    }
                }
            }
            
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            using(SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "INSERT INTO Room (Room_Name, Base_Price, isActive) VALUES (@RoomName, @BasePrice, @IsActive)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomName", RoomTextBox.Text);
                cmd.Parameters.AddWithValue("@BasePrice", decimal.Parse(BasePriceTxtBox.Text));
                cmd.Parameters.AddWithValue("@IsActive", isActiveRadioBtn.SelectedValue);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadRooms();
            ClearInputs();
        }

        protected void DeleteId_Click1(object sender, EventArgs e)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "delete from Room where RoomId = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadRooms();
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "update Room set Room_Name = @RoomName, isActive = @isActive where RoomId = @RoomId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomId", Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text));
                cmd.Parameters.AddWithValue("@RoomName", RoomTextBox.Text);
                cmd.Parameters.AddWithValue("@isActive", isActiveRadioBtn.SelectedValue);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadRooms();
            ClearInputs();
        }

        protected void ClearInputs()
        {
            RoomTextBox.Text = "";
            BasePriceTxtBox.Text = "";
            isActiveRadioBtn.ClearSelection();
        }

        protected void DiscountTierBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/DiscountTier.aspx");
        }
    }
}
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
    public partial class DiscountTier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDiscountTiers();
            }
        }

        protected void LoadDiscountTiers()
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "select DiscountId, MinDays, MaxDays, GuestCount, PricePerPerson from DiscountRule";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void ClearInputFields()
        {
            MinDaysTxt.Text = "";
            MaxDaysTxt.Text = "";
            GuestCountBox.Text = "";
            PricePerPersonTxt.Text = "";
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "INSERT INTO DiscountRule (MinDays, MaxDays, GuestCount, PricePerPerson) VALUES (@MinDays, @MaxDays, @GuestCount, @PricePerPerson)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MinDays", MinDaysTxt.Text);
                cmd.Parameters.AddWithValue("@MaxDays", MaxDaysTxt.Text);
                cmd.Parameters.AddWithValue("@GuestCount", GuestCountBox.Text);
                cmd.Parameters.AddWithValue("@PricePerPerson", decimal.Parse(PricePerPersonTxt.Text));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadDiscountTiers();
            ClearInputFields();
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "update DiscountRule set MinDays = @MinDays, MaxDays = @MaxDays, GuestCount = @GuestCount, PricePerPerson = @PricePerPerson where DiscountId = @DiscountId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DiscountId", Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text));
                cmd.Parameters.AddWithValue("@MinDays", MinDaysTxt.Text);
                cmd.Parameters.AddWithValue("@MaxDays", MaxDaysTxt.Text);
                cmd.Parameters.AddWithValue("@GuestCount", GuestCountBox.Text);
                cmd.Parameters.AddWithValue("@PricePerPerson", decimal.Parse(PricePerPersonTxt.Text));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadDiscountTiers();
            ClearInputFields();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow != null)
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    string query = "SELECT DiscountId, MinDays, MaxDays, GuestCount, PricePerPerson from DiscountRule where DiscountId = @Id";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MinDaysTxt.Text = reader["MinDays"].ToString();
                        MaxDaysTxt.Text = reader["MaxDays"].ToString();
                        GuestCountBox.Text = reader["GuestCount"].ToString();
                        PricePerPersonTxt.Text = reader["PricePerPerson"].ToString();
                    }
                }
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "delete from DiscountRule where DiscountId = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadDiscountTiers();
        }
    }
}
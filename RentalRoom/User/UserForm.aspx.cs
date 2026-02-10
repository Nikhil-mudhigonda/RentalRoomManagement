using RentalRoom.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentalRoom.User
{
    public partial class UserForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PriceDescriptionlbl.Text = "Enter the number of days and guests to calculate the price.";
            }
            LoadRooms();
        }

        protected void LoadRooms()
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "SELECT RoomId, Room_Name FROM Room where isActive = 1";
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DropDownRoomList.DataSource = dt;
                DropDownRoomList.DataTextField = "Room_Name";
                DropDownRoomList.DataValueField = "RoomId";
                DropDownRoomList.DataBind();
            }
        }
        protected void GetPricelbl_Click(object sender, EventArgs e)
        {
            using(SqlConnection conn = DbHelper.GetConnection())
            {
                int roomid = DropDownRoomList.SelectedIndex;
                int GuestCount = int.Parse(SelectedGuestTxt.Text);
                int Duration = int.Parse(DurationTxt.Text);

                string query = "select dr.priceperperson from discountrule dr join rdr.roomdiscountrule on dr.discountid = rdr.discountid where rdr.roomid = @roomid and dr.mindays <= @days and(dr.maxdays = 0 or dr.MaxDays >= @days) and guestcount = @guestcount";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@roomid", roomid);
                cmd.Parameters.AddWithValue("@guestcount", GuestCount);
                cmd.Parameters.AddWithValue("@days", Duration);
                conn.Open();
                decimal CalculatedPrice = (decimal)cmd.ExecuteScalar();
                
                if (CalculatedPrice > 0)
                {
                    PriceDescriptionlbl.Text = $"The price for {GuestCount} guests for {Duration} days is: \"\\u20AC \"{CalculatedPrice}";
                }
                else
                {
                    PriceDescriptionlbl.Text = "No price found for the selected criteria.";
                }
            }
        }
    }
}
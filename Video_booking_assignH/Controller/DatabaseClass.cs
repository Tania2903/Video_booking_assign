using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_booking_assignH.Controller
{
    public class DatabaseClass
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LTQK306;Initial Catalog=VideoDest;Integrated Security=True");

        public Boolean addClient(String name, String age, String phone, String address)
        {
            //Replaced Parameters with Value
            string query = "INSERT INTO Client(Name,Age,Contact,Address) VALUES(@Name, @Age,@Contact,@Address)";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@Contact", phone);
            cmd.Parameters.AddWithValue("@Address", address);



            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public Boolean editClient(int ID, String name, String age, String phone, String address)
        {
            //Replaced Parameters with Value
            string query = "update  Client set Name=@Name,Age=@Age,Contact=@Contact,Address=@Address where id=@CID";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@CID", ID);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@Contact", phone);
            cmd.Parameters.AddWithValue("@Address", address);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public Boolean delClient(int ID)
        {
            //Replaced Parameters with Value
            string query = "delete from Client where id=@CID";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@CID", ID);



            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public Boolean addVideo(String name, String ratting, String year, String plot, String Cost, String copies, String genre)
        {
            //Replaced Parameters with Value
            string query = "INSERT INTO Video(title,Plot,Ratting,Year,Cost,Copies,Genre) VALUES(@Name, @plot,@ratting,@year,@cost,@copies,@genre)";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@plot", plot);
            cmd.Parameters.AddWithValue("@ratting", ratting);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@cost", Cost);
            cmd.Parameters.AddWithValue("@copies", copies);
            cmd.Parameters.AddWithValue("@genre", genre);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }


        public Boolean UpdateVideo(int MID, String name, String ratting, String year, String plot, String Cost, String copies, String genre)
        {
            //Replaced Parameters with Value
            string query = "Update  Video set title=@Name,Plot=@plot,Ratting=@ratting,Year=@year,Cost=@cost,Copies=@copies,Genre=@genre where id=@ID";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@ID", MID);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@plot", plot);
            cmd.Parameters.AddWithValue("@ratting", ratting);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@cost", Cost);
            cmd.Parameters.AddWithValue("@copies", copies);
            cmd.Parameters.AddWithValue("@genre", genre);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }


        public Boolean delVideo(int MID)
        {
            //Replaced Parameters with Value
            string query = "delete from  Video  where id=@ID";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@ID", MID);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }


        public Boolean bookVideo(int MID, int CID, String BookingDate)
        {
            //Replaced Parameters with Value
            string query = "INSERT INTO Rental(V_ID,C_ID,BookDate,ReturnDate) VALUES(@MID, @CID,@Bdate,@Rdate)";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@MID", MID);
            cmd.Parameters.AddWithValue("@CID", CID);
            cmd.Parameters.AddWithValue("@Bdate", BookingDate);
            cmd.Parameters.AddWithValue("@Rdate", "Book");


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }


        public Boolean returnVideo(int RID, int MID, int CID, String BookingDate, String Rdate)
        {
            //Replaced Parameters with Value
            string query = "update  Rental set V_ID=@MID,C_ID=@CID,BookDate=@Bdate,ReturnDate=@Rdate where id=@RID";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@RID", RID);
            cmd.Parameters.AddWithValue("@MID", MID);
            cmd.Parameters.AddWithValue("@CID", CID);
            cmd.Parameters.AddWithValue("@Bdate", BookingDate);
            cmd.Parameters.AddWithValue("@Rdate", Rdate);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public Boolean delRentalVideo(int RID)
        {
            //Replaced Parameters with Value
            string query = "delete from Rental  where id=@RID";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@RID", RID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        SqlCommand sqlCmd;
        SqlDataReader sqlDatareader;


        public DataTable SelectQuery(String qry)
        {
            DataTable tbl = new DataTable();



            con.Open();
            sqlCmd = new SqlCommand(qry, con);

            sqlDatareader = sqlCmd.ExecuteReader();

            tbl.Load(sqlDatareader);

            con.Close();

            return tbl;
        }

    }

}

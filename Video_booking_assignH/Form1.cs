using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_booking_assignH
{
    public partial class Form1 : Form
    {
        Controller.DatabaseClass database = new Controller.DatabaseClass();
        int rent = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void add_mov_Click(object sender, EventArgs e)
        {
            if (!vName.Text.Equals("") && ! rating.Text.Equals("") && ! year.Text.Equals("") && ! plot.Text.Equals("") && !genreTxt.Text.Equals("") && !Cost_txt.Text.Equals("") && ! copies.Text.Equals("") ) {
                database.addVideo(vName.Text,rating.Text,year.Text,plot.Text,Cost_txt.Text,copies.Text,genreTxt.Text);
                MessageBox.Show("Record of Movie is stored ");
                vName.Text = "";
                rating.Text = "";
                year.Text = "";
                plot.Text = "";
                genreTxt.Text = "";
                Cost_txt.Text = "";
                copies.Text = "";


            }
        }
        // cs addd
        private void add_cs_btn_Click(object sender, EventArgs e)
        {
            if (!cname.Text.Equals("") && !cAge.Text.Equals("") && !cPhone.Text.Equals("") && !caddress.Text.Equals("")) {
                database.addClient(cname.Text,cAge.Text,cPhone.Text,caddress.Text);
                MessageBox.Show("CLient is Registered ");
                cname.Text = "";
                cAge.Text = "";
                cPhone.Text = "";
                caddress.Text = "";
                rental_cs_name.Text = "";
            }
        }
        //update cs

        private void update_cs_btn_Click(object sender, EventArgs e)
        {
            if (!rental_cs_name.Text.Equals("") && !cname.Text.Equals("") && !cAge.Text.Equals("") && !cPhone.Text.Equals("") && !caddress.Text.Equals(""))
            {
                database.editClient(Convert.ToInt32(rental_cs_name.Text),cname.Text, cAge.Text, cPhone.Text, caddress.Text);
                MessageBox.Show("CLient is Updated ");
                cname.Text = "";
                cAge.Text = "";
                cPhone.Text = "";
                caddress.Text = "";
                rental_cs_name.Text = "";
            }
        }

        private void del_cs_btn_Click(object sender, EventArgs e)
        {
            if (!rental_cs_name.Text.Equals("") && !cname.Text.Equals("") && !cAge.Text.Equals("") && !cPhone.Text.Equals("") && !caddress.Text.Equals(""))
            {
                database.delClient(Convert.ToInt32(rental_cs_name.Text));
                MessageBox.Show("CLient is Removed ");
                cname.Text = "";
                cAge.Text = "";
                cPhone.Text = "";
                caddress.Text = "";
                rental_cs_name.Text = "";
            }
        }

        private void vName_TextChanged(object sender, EventArgs e)
        {

        }
        // update video 
        private void update_vd_Click(object sender, EventArgs e)
        {
            if (!rental_mov_name.Text.Equals("") && !vName.Text.Equals("") && !rating.Text.Equals("") && !year.Text.Equals("") && !plot.Text.Equals("") && !lbl.Text.Equals("") && !Cost_txt.Text.Equals("") && !copies.Text.Equals(""))
            {
                database.UpdateVideo(Convert.ToInt32(rental_mov_name.Text),vName.Text, rating.Text, year.Text, plot.Text, Cost_txt.Text, copies.Text, genreTxt.Text);
                MessageBox.Show("Record of Movie is Updated  ");
                vName.Text = "";
                rating.Text = "";
                year.Text = "";
                plot.Text = "";
                genreTxt.Text = "";
                Cost_txt.Text = "";
                copies.Text = "";
                rental_mov_name.Text = "";

            }
        }

        private void del_mov_Click(object sender, EventArgs e)
        {
            if (!rental_mov_name.Text.Equals("") && !vName.Text.Equals("") && !rating.Text.Equals("") && !year.Text.Equals("") && !plot.Text.Equals("") && !lbl.Text.Equals("") && !Cost_txt.Text.Equals("") && !copies.Text.Equals(""))
            {
                database.delVideo(Convert.ToInt32(rental_mov_name.Text));
                MessageBox.Show("Record of Movie is Removed  ");
                vName.Text = "";
                rating.Text = "";
                year.Text = "";
                plot.Text = "";
                genreTxt.Text = "";
                Cost_txt.Text = "";
                copies.Text = "";
                rental_mov_name.Text = "";

            }
        }

        private void Issue_btn_Click(object sender, EventArgs e)
        {
            if (!rental_cs_name.Text.Equals("") && !rental_mov_name.Text.Equals("")) {

                database.bookVideo(Convert.ToInt32(rental_mov_name.Text), Convert.ToInt32(rental_cs_name.Text),dateTimePicker1.Text);
                MessageBox.Show("Movie is Issued on rent ");
                vName.Text = "";
                rating.Text = "";
                year.Text = "";
                plot.Text = "";
                lbl.Text = "";
                Cost_txt.Text = "";
                copies.Text = "";
                rental_mov_name.Text = "";


                cname.Text = "";
                cAge.Text = "";
                cPhone.Text = "";
                caddress.Text = "";
                rental_cs_name.Text = "";


            }
        }

        private void return_btn_Click(object sender, EventArgs e)
        {
            if (!rental_cs_name.Text.Equals("") && !rental_mov_name.Text.Equals(""))
            {
                String qry = "";
                int cost = 0;
                qry = "";
                qry = "select * from Video where id=" + Convert.ToInt32(rental_mov_name.Text.ToString()) + "";
                DataTable tbl = new DataTable();
                tbl = database.SelectQuery(qry);
                if (tbl.Rows.Count > 0)
                {
                    cost = Convert.ToInt32(tbl.Rows[tbl.Rows.Count - 1]["Cost"].ToString());

                }
                DateTime Current_date = DateTime.Now;


                DateTime Old_date = Convert.ToDateTime(dateTimePicker1.Value.ToString());



               String diff = (Current_date - Old_date).TotalDays.ToString();



                Double dif = Math.Round(Convert.ToDouble(diff));
                if (dif <= 0)
                {
                    dif = 1;
                }

               int  bill = cost * Convert.ToInt32(dif);



                database.returnVideo(rent,Convert.ToInt32(rental_mov_name.Text), Convert.ToInt32(rental_cs_name.Text), dateTimePicker1.Text,dateTimePicker2.Text);
                MessageBox.Show("Movie is returned and bill is $"+bill);
                vName.Text = "";
                rating.Text = "";
                year.Text = "";
                plot.Text = "";
                lbl.Text = "";
                Cost_txt.Text = "";
                copies.Text = "";
                rental_mov_name.Text = "";


                cname.Text = "";
                cAge.Text = "";
                cPhone.Text = "";
                caddress.Text = "";
                rental_cs_name.Text = "";


            }
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            if (rent>0 && !rental_cs_name.Text.Equals("") && !rental_mov_name.Text.Equals(""))
            {

                database.delRentalVideo(rent);
                MessageBox.Show("Movie is removed on rent ");
                vName.Text = "";
                rating.Text = "";
                year.Text = "";
                plot.Text = "";
                lbl.Text = "";
                Cost_txt.Text = "";
                copies.Text = "";
                rental_mov_name.Text = "";


                cname.Text = "";
                cAge.Text = "";
                cPhone.Text = "";
                caddress.Text = "";
                rental_cs_name.Text = "";


            }
        }

        private void all_customers_CheckedChanged(object sender, EventArgs e)
        {
            if (all_customers.Checked==true) {
                DataTable tbl = new DataTable();
                tbl = database.SelectQuery("select * from Client");
                dataGridView1.DataSource = tbl;
            }
            
        }

        private void allmovies_CheckedChanged(object sender, EventArgs e)
        {
            if (allmovies.Checked==true) {
                DataTable tbl = new DataTable();
                tbl = database.SelectQuery("select * from Video");
                dataGridView1.DataSource = tbl;
            }
            
        }

        private void allrented_CheckedChanged(object sender, EventArgs e)
        {
            if (allrented.Checked==true) {
                DataTable tbl = new DataTable();
                tbl = database.SelectQuery("select * from Rental");
                dataGridView1.DataSource = tbl;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (all_customers.Checked==true) {
                rental_cs_name.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cname.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cAge.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
                cPhone.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
                caddress.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
                
            }

            if (allmovies.Checked==true) { 
                rental_mov_name.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
                vName.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
                plot.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
                rating.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
                year.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
                Cost_txt.Text= dataGridView1.CurrentRow.Cells[5].Value.ToString();
                copies.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                genreTxt.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }

            if (allrented.Checked==true) {
                rent = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                rental_mov_name.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
                rental_cs_name.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
              //  dateTimePicker1.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();

            }



        }

        private void Pop_mov_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dataTable = database.SelectQuery("select * from Video");
            int rowIndex = 0;
            string Title = "";
            while (rowIndex < dataTable.Rows.Count)
            {
                DataTable Rental = database.SelectQuery("select * from Rental where V_ID=" + Convert.ToInt32(dataTable.Rows[rowIndex]["id"]) + "");

                int length = 0;
                if (Rental.Rows.Count > length)
                {
                    Title = dataTable.Rows[rowIndex]["title"].ToString();
                    length = Rental.Rows.Count;
                }
                rowIndex++;
            }
            MessageBox.Show(Title + " is the best Video, Good Luck");




        }

        private void year_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;

                int yr = now.Year;
                int diff = yr - Convert.ToInt32(year.Text.ToString());
                // MessageBox.Show(diff.ToString());
                if (diff >= 5)
                {
                    Cost_txt.Text = "2";
                }
                if (diff >= 0 && diff < 5)
                {
                    Cost_txt.Text = "5";
                }

            }
            catch (Exception ex)
            {

            }

        }

        private void pop_cs_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dataTable = database.SelectQuery("select * from Client");
            int rowIndex = 0;
            string Title = "";
            while (rowIndex < dataTable.Rows.Count)
            {
                DataTable Rental = database.SelectQuery("select * from Rental where C_ID=" + Convert.ToInt32(dataTable.Rows[rowIndex]["id"]) + "");

                int length = 0;
                if (Rental.Rows.Count > length)
                {
                    Title = dataTable.Rows[rowIndex]["Name"].ToString();
                    length = Rental.Rows.Count;
                }
                rowIndex++;
            }
            MessageBox.Show(Title + " is the best Video, Good Luck");

        }
    }
}

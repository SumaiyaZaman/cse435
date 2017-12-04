using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace Hotel_Management_System
{
    public partial class Admin_option : Form
    {
        public Admin_option()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            New_user_add nw = new New_user_add();
            nw.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeAdminUserNamePassoword cp = new ChangeAdminUserNamePassoword();
            cp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReservedRoomView rv = new ReservedRoomView();
            rv.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User_login ul = new User_login();
            ul.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Connection cv = new Connection();
            cv.thisConnection.Open();

            OracleCommand thiscommand1 = cv.thisConnection.CreateCommand();

            thiscommand1.CommandText = "delete New_User_add where RoomNUmber = '" + textBox1.Text + "'";

            thiscommand1.Connection = cv.thisConnection;
            thiscommand1.CommandType = CommandType.Text;

            try
            {
                thiscommand1.ExecuteNonQuery();
                MessageBox.Show("CheckOut Successfully");
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        
    }
}

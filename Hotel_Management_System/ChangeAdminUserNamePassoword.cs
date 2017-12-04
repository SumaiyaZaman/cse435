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
    public partial class ChangeAdminUserNamePassoword : Form
    {
        public ChangeAdminUserNamePassoword()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_option nw = new Admin_option();
            nw.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection sv = new Connection();
            sv.thisConnection.Open();
            OracleCommand thiscommand = sv.thisConnection.CreateCommand();
            thiscommand.CommandText = "update admin set username = '" + textBox3.Text + "',password = '" + textBox4.Text + "' where password = '" + textBox2.Text + "'";

            thiscommand.Connection = sv.thisConnection;
            thiscommand.CommandType = CommandType.Text;

            try
            {
                int a = thiscommand.ExecuteNonQuery();
                if  (a == 1)
                {
                    MessageBox.Show("Updated Successfully"); 
                }

                else
                {
                    MessageBox.Show("Not Updated... Insert your old password Perfectly");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Uddated");
            }

            sv.thisConnection.Close();
            this.Close();

            Admin_option ob = new Admin_option();
            ob.Show();
            this.Hide();
        }

        private void ChangeAdminUserNamePassoword_Load(object sender, EventArgs e)
        {

        }
    }
}

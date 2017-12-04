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
    public partial class User_login : Form
    {
        public User_login()
        {
            InitializeComponent();
        }

        private void button1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Connection cn = new Connection();
            cn.thisConnection.Open();

            OracleCommand thisCommand = cn.thisConnection.CreateCommand();

            thisCommand.CommandText = "select * from Hotel_Room_info order by RoomNumber";

            OracleDataReader thisReader = thisCommand.ExecuteReader();

            while (thisReader.Read())
            {
                ListViewItem lvsitm = new ListViewItem();
                lvsitm.Text = thisReader["RoomNumber"].ToString();
                lvsitm.SubItems.Add(thisReader["Type"].ToString());
                lvsitm.SubItems.Add(thisReader["Rent"].ToString());

                listView1.Items.Add(lvsitm);
            }
            cn.thisConnection.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Room_Info RM = new Room_Info();
            RM.Show();
            this.Hide();
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Room_Info : Form
    {
        public Room_Info()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection cn = new Connection();
            cn.thisConnection.Open();

            OracleCommand thisCommand = cn.thisConnection.CreateCommand();

            thisCommand.CommandText = "select RoomNumber,Type,Rent* "+ textBox1.Text + " as Rent from Hotel_Room_info where RoomNumber = " +textBox2.Text+" order by RoomNumber";

            OracleDataReader thisReader = thisCommand.ExecuteReader();
            listView1.Items.Clear();

            while(thisReader.Read())
            {
                ListViewItem lvsitm = new ListViewItem();
                lvsitm.Text = thisReader["RoomNumber"].ToString();
                lvsitm.SubItems.Add(thisReader["Type"].ToString());
                lvsitm.SubItems.Add(thisReader["Rent"].ToString());

                listView1.Items.Add(lvsitm);
            }
            cn.thisConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_login us = new User_login();
            us.Show();
            this.Hide();
        }

        private void Room_Info_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

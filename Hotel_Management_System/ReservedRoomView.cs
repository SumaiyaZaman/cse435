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
    public partial class ReservedRoomView : Form
    {
        public ReservedRoomView()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("Fiil Up all Fields and Press OK");
                    return;
                }

                if (comboBox1.SelectedIndex !=0)
                {
                    Connection CN = new Connection();
                    CN.thisConnection.Open();
                    OracleCommand thisCommand = new OracleCommand("select Name,PhoneNumber,Email,Address,Profession,Gender,EntryDate,ExitDate,RoomNumber from New_User_add where " + comboBox1.Text + " like'%" + textBox1.Text + "%'order by Name");

                    thisCommand.Connection = CN.thisConnection;
                    thisCommand.CommandType = CommandType.Text;

                    OracleDataReader thisReader = thisCommand.ExecuteReader();

                    listView1.Items.Clear();

                    while (thisReader.Read())
                    {

                        ListViewItem lsvItem = new ListViewItem();
                        lsvItem.Text = thisReader["Name"].ToString();
                        lsvItem.SubItems.Add(thisReader["PhoneNumber"].ToString());
                        lsvItem.SubItems.Add(thisReader["Email"].ToString());
                        lsvItem.SubItems.Add(thisReader["Address"].ToString());
                        lsvItem.SubItems.Add(thisReader["Profession"].ToString());
                        lsvItem.SubItems.Add(thisReader["Gender"].ToString());
                        lsvItem.SubItems.Add(thisReader["EntryDate"].ToString());
                        lsvItem.SubItems.Add(thisReader["ExitDate"].ToString());
                        lsvItem.SubItems.Add(thisReader["RoomNumber"].ToString());
                        listView1.Items.Add(lsvItem);
                    }
                    CN.thisConnection.Close();

                }
            }
            catch (Exception dx)
            {
                MessageBox.Show(dx.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Text = "";

                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thiscommand = new OracleCommand("select Name,PhoneNumber,Email,Address,Profession,Gender,Entrydate,ExitDate,RoomNumber from New_User_add where RoomNumber>0 and RoomNumber in (select RoomNumber from Hotel_Room_info )");
                thiscommand.Connection = CN.thisConnection;
                thiscommand.CommandType = CommandType.Text;

                OracleDataReader thisReader = thiscommand.ExecuteReader();

                listView1.Items.Clear();

                while (thisReader.Read())
                {
                    ListViewItem lsvitm = new ListViewItem();
                    lsvitm.Text = thisReader["Name"].ToString();
                    lsvitm.SubItems.Add(thisReader["PhoneNumber"].ToString());
                    lsvitm.SubItems.Add(thisReader["Email"].ToString());
                    lsvitm.SubItems.Add(thisReader["Address"].ToString());
                    lsvitm.SubItems.Add(thisReader["Profession"].ToString());
                    lsvitm.SubItems.Add(thisReader["Gender"].ToString());
                    lsvitm.SubItems.Add(thisReader["EntryDate"].ToString());
                    lsvitm.SubItems.Add(thisReader["ExitDate"].ToString());
                    lsvitm.SubItems.Add(thisReader["RoomNumber"].ToString());
                    //lsvitm.SubItems.Add(thisReader["Type"].ToString());

                    listView1.Items.Add(lsvitm);


                }
                CN.thisConnection.Close();


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_option ado = new Admin_option();
            ado.Show();
            this.Hide();
        }

        private void ReservedRoomView_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class New_user_add : Form
    {
        public New_user_add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection sv = new Connection();
            sv.thisConnection.Open();

            OracleCommand thisCommand = sv.thisConnection.CreateCommand();
            thisCommand.CommandText = "select RoomNumber from New_User_add where RoomNumber = '" + textBox5.Text + "'";

            thisCommand.Connection = sv.thisConnection;
            thisCommand.CommandType = CommandType.Text;

            try
            {
                OracleDataReader thisReader = thisCommand.ExecuteReader();
                while(thisReader.Read())
                {
                    string sp = thisReader["RoomNumber"].ToString();

                    try
                    {
                        if(sp != "")
                        {
                            MessageBox.Show("This Room has Already Booked!!!");
                            sv.thisConnection.Close();
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Failure");
                    }
                }
                thisReader.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Fill up fields then press ok");
                return;
            }

            OracleDataAdapter thisAdaptor = new OracleDataAdapter("select * from New_User_add", sv.thisConnection);
            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdaptor);

            DataSet thisDataSet = new DataSet();
            thisAdaptor.Fill(thisDataSet, "New_user_add");

            DataRow thisRow = thisDataSet.Tables["New_User_add"].NewRow();
            try
            {
                thisRow["Name"] = textBox1.Text;
                thisRow["PhoneNumber"] = textBox2.Text;
                thisRow["Email"] = textBox3.Text;
                thisRow["Address"] = textBox4.Text;
                thisRow["Profession"] = comboBox1.Text;
                thisRow["Gender"] = comboBox2.Text;
                thisRow["entryDate"] = dateTimePicker1.Value.Date.ToString();
                thisRow["exitDate"] = dateTimePicker2.Value.Date.ToString();
                thisRow["RoomNumber"] = textBox5.Text;

                thisDataSet.Tables["New_User_add"].Rows.Add(thisRow);

                thisAdaptor.Update(thisDataSet, "New_User_add");

                MessageBox.Show("Add");

                Admin_option ad = new Admin_option();
                ad.Show();
                  this.Hide();


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Fill up all fiels.Exceptation Occour !!!");

            }
            sv.thisConnection.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_option op = new Admin_option();
            op.Show();
            this.Hide();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

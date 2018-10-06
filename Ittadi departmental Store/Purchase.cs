using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Ittadi_departmental_Store
{
    public partial class Purchase : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=G:\Database\Ittadi departmental Store\Ittadi departmental Store\PasswordDatabase.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd;
        string n;
        float last_total=0;
        float quan;
        string amount;
        float owing_amount;
        public Purchase()
        {
            InitializeComponent();
            cmd.Connection = cn;
            fill_combobox1();
            nameofcustomer();

        }
        void fill_combobox1() {

            try
            {
                cn.Open();
                cmd.CommandText = "SELECT prdtName FROM tbl_product";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string name = rd["prdtName"].ToString();
                    comboBox1.Items.Add(name);
                }
                cn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Close();
        }
        void quantity()
        {
            try
            {
                cn.Open();
                cmd.CommandText = "SELECT quantity FROM tbl_product WHERE prdtName = '" + comboBox1.Text + "'";
                rd = cmd.ExecuteReader();
                rd.Read();
                n = rd["quantity"].ToString();
                //int num = Int32.Parse(n);
                label2.Text = "Available : ";
                label3.Text = n;
                cn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
 
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            quantity();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                cn.Open();
                cmd.CommandText = "SELECT mrp FROM tbl_product WHERE prdtName = '" + comboBox1.Text + "'";
                rd = cmd.ExecuteReader();
                rd.Read();
                string num = rd["mrp"].ToString();
                float mrp = float.Parse(num);
                quan = float.Parse(textBox2.Text);
                float total_price = mrp * quan;
                last_total += total_price; 
                string text = comboBox1.Text;
                listBox1.Items.Add(text+"\t\t"+quan+"\t\t\t"+mrp+"\t\t"+total_price);

                cn.Close();

                if (textBox2.Text =="") {
              //   textBox2.Text = "Input a value";
                 float a =float.Parse(textBox2.Text);
                
            }
            else if(float.Parse(textBox2.Text) > float.Parse(n))
            {
                label3.Text = "Only : " + n;
                label2.BackColor = Color.Red;
                label3.BackColor = Color.Red;
            }
                else if (float.Parse(textBox2.Text) <= float.Parse(n))
                {
                    label3.Text = n;
                    label2.BackColor = Color.Green;
                    label3.BackColor = Color.Green;
                }
                    

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex);
                cn.Close();
            }

            try
            {
                float b = (float.Parse(n) - quan);
                cn.Open();
                cmd.CommandText = "UPDATE tbl_product SET quantity = '" + b+ "' WHERE prdtName = '" + comboBox1.Text + "'";
                cmd.ExecuteReader();
                label3.Text = (float.Parse(n) - quan).ToString();
                cn.Close();
                n = b.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
             /*if (textBox2.Text == null) {
                 textBox2.Text = "Input a value";
                 float a =float.Parse(textBox2.Text);
                
            }
            else if(float.Parse(textBox2.Text) > float.Parse(n))
            {
                label3.Text = "Only : " + n;
                label2.BackColor = Color.Red;
                label3.BackColor = Color.Red;
            }
            else if (float.Parse(textBox2.Text) <= float.Parse(n))
            {
                label3.Text =   n;
                label2.BackColor = Color.Green;
                label3.BackColor = Color.Green;
            }*/
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            float amon = owing_amount + last_total;
            try
            {
                
                cn.Open();
                cmd.CommandText = "UPDATE tbl_owingBuyer SET owingamount ='"+amon+"' WHERE Fullname = '"+comboBox2.Text+"' ";
                cn.Close();

            }
            catch (Exception ex) 
            {
                MessageBox.Show(""+ex);
            }
            listBox1.Items.Add("________________________________________________________________________________________");
            listBox1.Items.Add("\t\t\t\t\tTotal amount :\t\t"+last_total);
            label8.Text = amon.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string filepath = listBox1.Items[listBox1.SelectedIndex].ToString();
                if (File.Exists(filepath))
                    File.Delete(filepath);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cmd.CommandText = "SELECT Id , Fullname ,phoneNo ,company ,owingamount FROM tbl_owingBuyer WHERE Fullname = '" + comboBox2.Text + "'";
                rd = cmd.ExecuteReader();
                rd.Read();
                label4.Text = rd["Id"].ToString();
                label5.Text = rd["Fullname"].ToString();
                label6.Text = rd["phoneNo"].ToString();
                label7.Text = rd["company"].ToString();
                label8.Text = rd["owingamount"].ToString();
                amount = rd["owingamount"].ToString();
                owing_amount = float.Parse(amount);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }
        void nameofcustomer()
        {
            try
            {
                cn.Open();
                cmd.CommandText = "SELECT Fullname FROM tbl_owingBuyer";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string name = rd["Fullname"].ToString();
                    comboBox2.Items.Add(name);
                }
                cn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox1.Show();
            }
            else {
                groupBox1.Hide();
            }
        }
    }
}

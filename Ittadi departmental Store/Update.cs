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

namespace Ittadi_departmental_Store
{
    public partial class Update : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=G:\Database\Ittadi departmental Store\Ittadi departmental Store\PasswordDatabase.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd;
        public Update()
        {
           
            InitializeComponent();
            cmd.Connection = cn;
            fill_combobox1();
        }

        void fill_combobox1()
        {

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
        private void button4_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cmd.CommandText = "SELECT * FROM tbl_product WHERE prdtName = '"+comboBox1.Text+"'";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    textBox9.Text= rd["prdtName"].ToString();
                    
                    textBox4.Text =rd["company"].ToString(); 
                    textBox5.Text =rd["buyprice"].ToString(); 
                    textBox6.Text = rd["wholesellPrice"].ToString();
                    textBox7.Text = rd["quantity"].ToString();
                    textBox8.Text = rd["mrp"].ToString(); 
                    //comboBox1.Items.Add(name);
                }
                cn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cmd.CommandText = "UPDATE tbl_product SET prdtName = '" + textBox9.Text + "' , company = '" + textBox4.Text + "', buyprice = '" + textBox5.Text + "', wholesellPrice = '" + textBox6.Text + "', quantity = '" + textBox7.Text + "', mrp = '" + textBox8.Text + "' WHERE prdtName ='"+comboBox1.Text+"' ";
                rd = cmd.ExecuteReader();
                MessageBox.Show("Update Successfull !!");
               /* while (rd.Read())
                {
                    textBox9.Text = rd["prdtName"].ToString();

                    textBox4.Text = rd["company"].ToString();
                    textBox5.Text = rd["buyprice"].ToString();
                    textBox6.Text = rd["wholesellPrice"].ToString();
                    textBox7.Text = rd["quantity"].ToString();
                    textBox8.Text = rd["mrp"].ToString();
                    //comboBox1.Items.Add(name);
                }*/
                cn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

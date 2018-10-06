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
    public partial class Delete : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=G:\Database\Ittadi departmental Store\Ittadi departmental Store\PasswordDatabase.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd;

        public Delete()
        {
            InitializeComponent();
            cmd.Connection = cn;
            fill_combobox1();
        }

        private void Delete_Load(object sender, EventArgs e)
        {

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
                MessageBox.Show("" + ex);
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
                cmd.CommandText = "SELECT * FROM tbl_product WHERE prdtName = '" + comboBox1.Text + "'";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    textBox9.Text = rd["prdtName"].ToString();

                    textBox4.Text = rd["company"].ToString();
                    textBox5.Text = rd["buyprice"].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cmd.CommandText = "DELETE FROM tbl_product WHERE prdtName ='" + comboBox1.Text + "' ";
                rd = cmd.ExecuteReader();

                MessageBox.Show("Delete Successfull !!");
                comboBox1.Text = "";
                     textBox9.Text = "";

                     textBox4.Text ="";
                     textBox5.Text = "";
                     textBox6.Text = "";
                     textBox7.Text = "";
                     textBox8.Text = "";

                
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
            comboBox1.Items.Clear();
            fill_combobox1();
            
        }
    }
}

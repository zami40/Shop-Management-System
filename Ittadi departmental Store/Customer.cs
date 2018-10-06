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
    public partial class Customer : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=G:\Database\Ittadi departmental Store\Ittadi departmental Store\PasswordDatabase.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd;
        public Customer()
        {
            InitializeComponent();
            cmd.Connection = cn;
            customer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Close();
        }
        void customer()
        {
            try
            {
                //string connectionString = @"Data Source=" + textBox4.Text + ";" + "Initial Catalog=" + textBox1.Text + ";" + "User ID=" + textBox2.Text + ";" + "Password=" + textBox3.Text;
                string sql = "SELECT * FROM tbl_owingBuyer";
                SqlDataAdapter dataadapter = new SqlDataAdapter(sql, cn);
                DataSet ds = new DataSet();
                cn.Open();
                dataadapter.Fill(ds, "Fullname");
                cn.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Fullname";



            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}

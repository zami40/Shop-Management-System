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
    public partial class InStock : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=G:\Database\Ittadi departmental Store\Ittadi departmental Store\PasswordDatabase.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd;
        public InStock()
        {

            InitializeComponent();
            cmd.Connection = cn;
            stock();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Close();
        }
        void stock()
        {
            try{
                    //string connectionString = @"Data Source=" + textBox4.Text + ";" + "Initial Catalog=" + textBox1.Text + ";" + "User ID=" + textBox2.Text + ";" + "Password=" + textBox3.Text;
                    string sql = "SELECT * FROM tbl_product WHERE quantity >0";
                    SqlDataAdapter dataadapter = new SqlDataAdapter(sql, cn);
                    DataSet ds = new DataSet();
                    cn.Open();
                    dataadapter.Fill(ds, "prdtName");
                    cn.Close();
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "prdtName";
             

                
            }catch(Exception ex)
            {
                MessageBox.Show(""+ex);
            }
        }
    }
}

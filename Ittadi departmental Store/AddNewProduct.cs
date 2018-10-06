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
    public partial class AddNewProduct : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=G:\Database\Ittadi departmental Store\Ittadi departmental Store\PasswordDatabase.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public AddNewProduct()
        {
            cmd.Connection = cn;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                cn.Open();
                cmd.CommandText = "INSERT INTO tbl_product(Id , prdtName , company , wholesellPrice , buyprice ,  quantity , mrp ) VALUES('" + txtId.Text + "','" + txtpdtname.Text + "','" + txtcompany.Text + "' , '" + txtwholesellprice.Text + "' , '" + txtpurchaseprice.Text + "', '" + txtquantity.Text + "' , '" + txtmrp.Text + "')";
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Data Saved Successfully!!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex);
                //Console.WriteLine(ex);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}

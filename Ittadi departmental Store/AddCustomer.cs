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
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=G:\Database\Ittadi departmental Store\Ittadi departmental Store\PasswordDatabase.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Form1()
        {
            InitializeComponent();
            cmd.Connection = cn;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void registerbutton_Click(object sender, EventArgs e)
        {
            try
            {

                cn.Open();
                cmd.CommandText = "INSERT INTO tbl_owingBuyer(Id , Fullname , company , phoneNo ,present_address , permanent_address , reference , owingamount ) VALUES('" + idtxt.Text + "','" + nametxt.Text+ "','" + companytextBox.Text + "' , '" + mobiletxt.Text + "' , '" + presentaddtextBox.Text + "', '" + permanentaddtextBox.Text + "' , '" + referencetextBox.Text + "','"+owingAmounttxt.Text+"')";
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Data Saved Successfully!!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                //Console.WriteLine(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer cs = new Customer();
            cs.Show();
            this.Hide();
        }
    }
}

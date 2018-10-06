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
using System.Security.Cryptography;

namespace Ittadi_departmental_Store
{
    public partial class EmployeeResister : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=G:\Database\Ittadi departmental Store\Ittadi departmental Store\PasswordDatabase.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string pass;
        string usnm;
        bool passwordseen;
        Encryption encrypt = new Encryption();
        EmployeeLogIn eml = new EmployeeLogIn();
        private static string key = "adhiurthcnvmfkroplkiordewajrfjtg";
        private static string IV = "xyzabcdfhsdjkfhs";
        public EmployeeResister()
        {
            cmd.Connection = cn;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       private static string Encrypt(string text)
        {
            byte[] plaintextbytes = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted = crypto.TransformFinalBlock(plaintextbytes, 0, plaintextbytes.Length);
            crypto.Dispose();
            return Convert.ToBase64String(encrypted);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            try
            {
                cn.Open();
                cmd.CommandText = "SELECT username FROM tbl_login WHERE username = '" + txtusername.Text + "'";
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                     usnm = dr["username"].ToString();
                }
                cn.Close();
                if (txtusername.Text == usnm)
                {
                    MessageBox.Show("There Exist a Username that you enter !! please Try another");
                }
                else
                {
                    if (txtpassword.Text == "" || txtpassword.TextLength < 6)
                    {
                        MessageBox.Show("You must enter at least six character as password!!");
                    }
                    else
                    {
                        if (txtpassword.Text == txtpasswordconfirm.Text)
                        {
                            try
                            {
                                cn.Open();
                                pass = Encrypt(txtpassword.Text);
                                cmd.CommandText = "INSERT INTO tbl_login (username, password , first_name , last_name , mobile , address) VALUES ('" + txtusername.Text + "' , '" + pass + "','" + txtfirstname.Text + "' , '" + txtlastname.Text + "','" + txtmobile.Text + "' , '" + txtaddress.Text + "')";
                                cmd.ExecuteNonQuery();
                                //  cn.Close();

                                txtusername.Text = "";
                                txtpassword.Text = "";
                                txtfirstname.Text = "";
                                txtlastname.Text = "";
                                txtmobile.Text = "";
                                txtaddress.Text = "";
                                cn.Close();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                            MessageBox.Show("Data Saved Successfully!!");
                            eml.Show();
                            this.Close();
                        }
                        else
                        {

                            MessageBox.Show("Password doesn't match!! Please enter same password.");
                        }
                    }
                }
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eml.Show();
            this.Close();

        }

        private void btn_passwordseen_Click(object sender, EventArgs e)
        {
            if (passwordseen == false)
            {
                txtpassword.UseSystemPasswordChar = true;
                passwordseen = true;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = false;
                passwordseen = false;

            }
        }

        private void EmployeeResister_Load(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = true;
        }
    }
}

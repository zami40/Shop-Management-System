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
    public partial class EmployeeLogIn : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=G:\Database\Ittadi departmental Store\Ittadi departmental Store\PasswordDatabase.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader sdr;
        string pass;
        string usnm;
        Home hm = new Home();
        bool passwordseen = true;

        private static string key = "adhiurthcnvmfkroplkiordewajrfjtg";
        private static string IV = "xyzabcdfhsdjkfhs";
        public EmployeeLogIn()
        {
            cmd.Connection = cn;
            InitializeComponent();
        }
        public static string Decrypt(string encrypted)
        {
            byte[] encryptedbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);

            byte[] secret = crypto.TransformFinalBlock(encryptedbytes, 0, encryptedbytes.Length);
            crypto.Dispose();
            return System.Text.ASCIIEncoding.ASCII.GetString(secret);
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cmd.CommandText = "SELECT username FROM tbl_login WHERE username = '" + txtusername.Text + "'";
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    usnm = sdr["username"].ToString();
                }
                cn.Close();
                if (txtusername.Text != usnm)
                {
                    MessageBox.Show("Username doesn't exist !!");
               }
                else
                {
                    try
                    {
                        string st = txtusername.Text;
                        cn.Open();
                        cmd.CommandText = "SELECT password FROM tbl_login WHERE  username ='" + st + "'";
                        Console.WriteLine(cmd.CommandText);
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            pass = Decrypt(sdr["password"].ToString());
                        }
                        cn.Close();

                        if (txtpassword.Text == pass)
                        {
                            hm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrcet Password!! try the Right one");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

    private void btnresister_Click(object sender, EventArgs e)
        {
            EmployeeResister eml = new EmployeeResister();
            eml.Show();
            this.Hide();
        }

        private void EmployeeLogIn_Load(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = true;
        }

        private void btn_passwordseen_Click(object sender, EventArgs e)
        {
            if(passwordseen == false)
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
    }
}

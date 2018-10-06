using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ittadi_departmental_Store
{
    public partial class Home : Form
    {
        Update ud = new Update();
        AddNewProduct anp = new AddNewProduct();
        InStock st = new InStock();
        Delete dt = new Delete();
        Purchase pr = new Purchase();
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            anp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ud.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            st.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dt.Show();
            this.Hide();

        }

      
        private void button6_Click(object sender, EventArgs e)
        {
            Customer cs = new Customer();
            cs.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pr.Show();
            this.Hide();
        }
    }
}

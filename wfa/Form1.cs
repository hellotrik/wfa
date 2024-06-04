using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wt001.ran.crypt;

namespace wfa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void en_Click(object sender, EventArgs e)
        {
           var mi=  new Aes(key.Text).Encrypt(mingwen.Text);
            miwen.Text = mi;
        }

        private void de_Click(object sender, EventArgs e)
        {
            var ming = new Aes(key.Text).Decrypt(miwen.Text);
            mingwen.Text = ming;
        }
    }
}

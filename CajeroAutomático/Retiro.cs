using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajeroAutomático
{
    public partial class Retiro : Form
    {
        public Retiro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Retiro3 r3 = new Retiro3();
            r3.Show();
            this.Hide();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            Retiro2 r2 = new Retiro2();
            r2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

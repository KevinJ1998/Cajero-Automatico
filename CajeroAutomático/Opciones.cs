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
    public partial class Opciones : Form
    {
        public Opciones()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consulta consulta = new Consulta();
            consulta.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Retiro ret = new Retiro();
            ret.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Transferencia trans = new Transferencia();
            trans.Show();
            this.Hide();
        }
    }
}

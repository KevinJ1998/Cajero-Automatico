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

namespace CajeroAutomático
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Opciones opc = new Opciones();
            opc.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-8CSIPAS\TEW_SQLEXPRESS;Initial Catalog=cajero;User ID=Kevin;Password=123456");
                SqlCommand cmd = new SqlCommand("_login @userci,@pwd", sqlcon);

            } catch (Exception error)
            {

            }
        }
    }
}

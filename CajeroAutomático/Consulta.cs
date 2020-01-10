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
                formLogin user = new formLogin();
                SqlConnection sqlcon = new SqlConnection(@"Data Source=MSI;Initial Catalog=cajero;User ID=team;Password=12345");
                SqlCommand cmd = new SqlCommand("select accAvMoney from account where userIdFK=2 and accTypeFK=1", sqlcon);
                saldo.Text.Replace("",cmd.ToString());

            } catch (Exception error)
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /*private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbTipoCuenta.Items.Add("Ahorro");
            

        }*/
    }
}

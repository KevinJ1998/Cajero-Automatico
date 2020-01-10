using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajeroAutomático
{
    public partial class Retiro : Form
    {
        public int valor;

        public Retiro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.valor = 10;
            }
            if (radioButton2.Checked)
            {
                this.valor = 20;
            }
            if (radioButton3.Checked)
            {
                this.valor = 30;
            }
            if (radioButton4.Checked)
            {
                this.valor = 100;
            }
            if (radioButton5.Checked)
            {
                this.valor = 200;
            }
            try
            {
                formLogin user = new formLogin();
                SqlConnection sqlcon = new SqlConnection(@"Data Source=MSI;Initial Catalog=cajero;User ID=team;Password=12345");
                SqlCommand cmd = new SqlCommand("update account set accAvMoney = accAvMoney-"+(valor), sqlcon);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                               
            } catch (Exception error)
            {
                MessageBox.Show("Saldo insuficiente" + error);
            }
            
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}

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
    public partial class formLogin : Form
    {
 
        public formLogin()
        {
            InitializeComponent();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-8CSIPAS\TEW_SQLEXPRESS;Initial Catalog=cajero;User ID=Kevin;Password=123456");
                SqlCommand cmd = new SqlCommand("_login @userci,@pwd", sqlcon);
                cmd.Parameters.AddWithValue("@userci", txtUser.Text);
                cmd.Parameters.AddWithValue("@pwd", txtPassword.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                sqlcon.Open();
                int i = cmd.ExecuteNonQuery();
                sqlcon.Close();
                if (dtbl.Rows.Count == 1)
                {
                    Opciones opc = new Opciones();
                    opc.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("verifica tu usuario o contraseña");
                }
            } catch (Exception error)
            {
                MessageBox.Show("Error: " + error,"",MessageBoxButtons.OK);
            }
        }
    }
}

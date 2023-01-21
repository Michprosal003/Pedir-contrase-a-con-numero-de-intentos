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

namespace Github_Rosales_Proyecto
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        int Intentos = 3;
        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Usuario\source\repos\Github_Rosales_Proyecto\Github_Rosales_Proyecto\Connection\Connection.mdf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Login WHERE Username='" + textBox1.Text + "' AND Password='" + textBox2.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString()=="1")
            {
                this.Hide();
                new Formulario().Show();
            }


            else
            {
                Intentos--;
                MessageBox.Show("Usuario y/o clave incorrectos.");
                if(Intentos==0)
                {
                    MessageBox.Show("Ha llegado al numero maximo de intentos.Contactar a Administrador para reiniciar");

                    Application.Exit();
                }
            }






        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

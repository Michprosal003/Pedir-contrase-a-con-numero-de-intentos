using Github_Rosales_Proyecto.proyectoclasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Github_Rosales_Proyecto
{
    public partial class Formulario : Form
    {
        public Formulario()
        {
            InitializeComponent();
        }

        proyectoclass c = new proyectoclass();

        private void button1_Click(object sender, EventArgs e)
        {

            c.Nombre = textBox2.Text;
            c.Apellido = textBox3.Text;
            c.Codigo = textBox4.Text;
            c.Materia = comboBox1.Text;
            c.Nota = textBox5.Text;
            c.Grupo = comboBox2.Text;
            c.Jornada = comboBox3.Text;
            c.Estado = comboBox4.Text;
            c.Nivel_Estudios = comboBox5.Text;
            c.Genero = comboBox6.Text;


            bool Success = c.insert(c);
            if(Success==true)
            {
                MessageBox.Show("El registro ha sido agregado correctamente");
                DataTable dt = c.Select();
                dataGridView1.DataSource = dt;
            }

            else
            {
                MessageBox.Show("El registro no ha podido agregar correctamente");

            }


        }

        private void Formulario_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int Rowindex = e.RowIndex;

            textBox1.Text = dataGridView1.Rows[Rowindex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[Rowindex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[Rowindex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[Rowindex].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[Rowindex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[Rowindex].Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[Rowindex].Cells[6].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[Rowindex].Cells[7].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[Rowindex].Cells[8].Value.ToString();
            comboBox5.Text = dataGridView1.Rows[Rowindex].Cells[9].Value.ToString();
            comboBox6.Text = dataGridView1.Rows[Rowindex].Cells[10].Value.ToString();















        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.ID = int.Parse(textBox1.Text);
            c.Nombre = textBox2.Text;
            c.Apellido = textBox3.Text;
            c.Codigo = textBox4.Text;
            c.Materia = comboBox1.Text;
            c.Nota = textBox5.Text;
            c.Grupo = comboBox2.Text;
            c.Jornada = comboBox3.Text;
            c.Estado = comboBox4.Text;
            c.Nivel_Estudios = comboBox5.Text;
            c.Genero = comboBox6.Text;


            bool Success = c.update(c);
            if (Success == true)
            {
                MessageBox.Show("El registro ha sido actualizado correctamente");
                DataTable dt = c.Select();
                dataGridView1.DataSource = dt;
            }
            else

            {
                MessageBox.Show("El registro no ha podido actualizar correctamente");

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            c.ID = Convert.ToInt32(textBox1.Text);
           


            bool Success = c.delete(c);
            if (Success == true)
            {
                MessageBox.Show("El registro ha sido eliminado exitosamente");
                DataTable dt = c.Select();
                dataGridView1.DataSource = dt;
            }
            else

            {
                MessageBox.Show("El registro no ha podido eliminar correctamente");

            }


        }

        static string Programador = ConfigurationManager.ConnectionStrings["Programador"].ConnectionString;
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox6.Text;
            SqlConnection conn = new SqlConnection(Programador);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Universidad WHERE Nombre LIKE'%" + keyword + "%' OR Apellido LIKE'%" + keyword + "%' OR Codigo LIKE'%" + keyword + "%' OR Materia LIKE'%" + keyword + "%' OR Nota LIKE'%" + keyword + "%' ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}

// Integrantes: María Lizeth Del Pino Morales 22887026
//Karen moguel cruz 22887050
//Brenda Rosales de Lucio 22887040
//A5.3- Desarrollo de una aplicacion para la gestion de datos
//4E


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace CRUD1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            MessageBox.Show("Conexion Exitosa");

            dataGridView1.DataSource = llenar_grid();
        }
        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            String consulta = "SELECT * FROM Table_ALUMNOS"; 
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = CreateSqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }


        private SqlDataAdapter CreateSqlDataAdapter(SqlCommand cmd)
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            return da;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = Conexion.Conectar();
            string insertar = "INSERT INTO Table_ALUMNOS (MATRICULA, NOMBRE, APELLIDOS, DIRECCION, CARRERA, NO_MOVIL) VALUES (@MATRICULA, @NOMBRE, @APELLIDOS, @DIRECCION, @CARRERA, @NO_MOVIL)";
            SqlCommand cmd1 = new SqlCommand(insertar, connection);
        
            cmd1.Parameters.AddWithValue("@MATRICULA", textBox1.Text);
            cmd1.Parameters.AddWithValue("@NOMBRE", textBox2.Text);
            cmd1.Parameters.AddWithValue("@APELLIDOS", textBox3.Text);
            cmd1.Parameters.AddWithValue("@DIRECCION", textBox4.Text);
            cmd1.Parameters.AddWithValue("@CARRERA", textBox5.Text);
            cmd1.Parameters.AddWithValue("@NO_MOVIL", textBox6.Text);

            cmd1.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron agragdos con exito");
            dataGridView1.DataSource = llenar_grid();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }


            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE Table_ALUMNOS SET MATRICULA=@MATRICULA, NOMBRE=@NOMBRE, APELLIDOS=@APELLIDOS, DIRECCION=@DIRECCION, CARRERA=@CARRERA, NO_MOVIL=@NO_MOVIL WHERE MATRICULA=@MATRICULA";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@MATRICULA", textBox1.Text);
            cmd2.Parameters.AddWithValue("@NOMBRE", textBox2.Text);
            cmd2.Parameters.AddWithValue("@APELLIDOS", textBox3.Text);
            cmd2.Parameters.AddWithValue("@DIRECCION", textBox4.Text);
            cmd2.Parameters.AddWithValue("@CARRERA", textBox5.Text);
            cmd2.Parameters.AddWithValue("@NO_MOVIL", textBox6.Text);

            cmd2.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron actualizados con exito");
            dataGridView1.DataSource = llenar_grid();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "DELETE FROM Table_ALUMNOS WHERE MATRICULA = @MATRICULA";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@MATRICULA", textBox1.Text);

            cmd3.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron eliminados con exito");
            dataGridView1.DataSource = llenar_grid();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Focus();
        }
    }
}

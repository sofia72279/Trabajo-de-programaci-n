using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Autores
{
    public partial class Form1 : Form
    {
        private string conexion = "Server=localhost;Database=Libreris;Trusted_Connetion=True;";
        private object textNombre;
        private object textNacionalidad;
        private object btnMostrar;

        public Form1()
        {
            InitializeComponent();
        }
        //EVENTO BOTÓN MOSTRAR//
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SlqDataAdapter("SELECT * FROM AUTOR", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        //EVENTO BOTÓN INSERTAR//
        private void btninsertar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();

                string query = "INSERT INTO AUTOR (Nombre, Nacionalidad) VALUES(@n,@na)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@n", textNombre.Text);
                cmd.Parameters.AddWithValue("@na", textNacionalidad.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Insertado");

                btnMostrar.PerformClick();
            }
        }

        // EVENTO BOTÓN ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
      
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdAutor"].Value);

                using (SqlConnection con = new SqlConnection(conexion))
                {
                    con.Open();

                    string query = "DELETE FROM AUTOR WHERE IdAutor = @id";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Eliminado");

                    btnMostrar.PerformClick();
                }
        
            }
        
        }
        

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

namespace FormAutor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
  public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        public void buscar()
        {
            int id_autor = Convert.ToInt32(textBox1.Text);
            SqlCommand busca = new SqlCommand(
                "select * from autor where IdAutor like (" + id_autor + ")", conexion);
            conexion.Open();
            busca.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Dato encontrado", "Encontrado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void actualizar()
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select * from autor", conexion);
            DataSet ds = new DataSet();
            adp.Fill(ds, "autor");
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        public void insertar()
        {
            try
            {
                int id_autor = Convert.ToInt32(textBox1.Text);
                string nombre = "'" + this.textBox2.Text + "'";
                string apellido = "'" + this.textBox3.Text + "'";
                string nacionalidad = "'" + this.textBox4.Text + "'";
                string fechaNac = "'" + this.textBox5.Text + "'";
                string bibliografia = "'" + this.textBox6.Text + "'";
                string categoria = "'" + this.textBox7.Text + "'";

                SqlCommand comando = new SqlCommand(
                    "INSERT INTO autor VALUES (" +
                    id_autor + "," + nombre + "," + apellido + "," +
                    nacionalidad + "," + fechaNac + "," + bibliografia + "," + categoria + ")",
                    conexion);

                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Autor guardado correctamente", "Agregar Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Asegurese de llenar todos los campos requeridos", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void eliminar()
        {
            int id_autor = Convert.ToInt32(textBox1.Text);

            DialogResult respuesta = MessageBox.Show(
                "Esta seguro de eliminar este registro", "Datos Irrecuperables",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                SqlCommand eliminar = new SqlCommand(
                    "delete from autor where IdAutor like (" + id_autor + ")", conexion);
                conexion.Open();
                eliminar.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Autor eliminado correctamente", "Eliminado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Modificar()
        {
            try
            {
                int id_autor = Convert.ToInt32(textBox1.Text);
                string nombre = textBox2.Text;
                string apellido = textBox3.Text;
                string nacionalidad = textBox4.Text;
                string fechaNac = textBox5.Text;
                string bibliografia = textBox6.Text;
                string categoria = textBox7.Text;

                SqlCommand comando = new SqlCommand(
                    "UPDATE autor SET " +
                    "nombre = @nombre, " +
                    "apellido = @apellido, " +
                    "nacionalidad = @nacionalidad, " +
                    "fechanacimiento = @fechaNac, " +
                    "bibliografia = @bibliografia, " +
                    "idcategoria = @categoria " +
                    "WHERE IdAutor = @id",
                    conexion);

                comando.Parameters.AddWithValue("@id", id_autor);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", apellido);
                comando.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                comando.Parameters.AddWithValue("@fechaNac", fechaNac);
                comando.Parameters.AddWithValue("@bibliografia", bibliografia);
                comando.Parameters.AddWithValue("@categoria", categoria);

                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();

                if (filasAfectadas > 0)
                    MessageBox.Show("Autor modificado correctamente", "Modificar",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se encontró el autor con ese ID", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── EVENTOS DE BOTONES ───────────────────────

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            insertar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void btnActualiza_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
        }
    }
}

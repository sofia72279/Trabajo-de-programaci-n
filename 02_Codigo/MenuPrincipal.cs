using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBiblioteca
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnAutor_Click(object sender, EventArgs e)
        {
            FormAutor autor = new FormAutor();
            autor.ShowDialog();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FormCategoria categoria = new FormCategoria();
            categoria.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

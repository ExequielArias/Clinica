using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmdGrabar_Click(object sender, EventArgs e)
        {
            Especialidades oEspecialidad = new Especialidades();
            oEspecialidad.Especialidad = Convert.ToInt32(txtEspecialidad.Text);
            oEspecialidad.Nombre = txtNombre.Text; 
            oEspecialidad.Grabar();
            txtEspecialidad.Text = "";
            txtNombre.Text = ""; 
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            Especialidades oEspecialidad = new Especialidades();
            oEspecialidad.Especialidad = Convert.ToInt32(txtEspecialidad.Text);
            oEspecialidad.Borrar();
            txtEspecialidad.Text = ""; 
        }
    }
}

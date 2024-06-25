using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Abstraccion.Extensiones;
using UI_LUGIntegrador.Extensiones;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;

namespace LUGIntegrador
{
    public partial class Form_Persona : Form
    {
        BLLPersona bllPersona;
        Persona itemActual;


        public Form_Persona()
        {
            InitializeComponent();
            bllPersona = new BLLPersona();  
            // Campos y sus encabezados
            dataGridView1.ConfigurarGrids();
            dataGridView1.CargarGrid(new List<string> { "Nombre", "Apellido", "DNI", "Telefono", "Tipo", "Email" }, bllPersona.ListarTodo());
        }
      
        //Guardar
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                itemActual = dataGridView1.VerificarYRetornarSeleccion<Persona>();
                VerificarDatos();
                var response = bllPersona.Guardar(itemActual);
                if (response)
                    MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerificarDatos()
        {
            // Verificar si el nombre del campeonato está vacío
            if (string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(contraseña.Text))
                throw new Exception("Complete todos los campos para continuar.");

        }

        //Click en datagrid
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            itemActual = dataGridView1.VerificarYRetornarSeleccion<Persona>();
            email.Text = itemActual.Email;
            contraseña.Text = "";
        }
    }
}

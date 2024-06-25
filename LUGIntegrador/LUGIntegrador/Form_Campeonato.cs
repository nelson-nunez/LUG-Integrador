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
using LUGIntegrador;

namespace UI_LUGIntegrador
{
    public partial class Form_Campeonato : Form
    {
        BLLCampeonato bllCampeonato;
        Campeonato campeonatoActual;
        public event EventHandler<CampeonatoEventArgs> AbrirForm_Partidos;
        public Form_Campeonato()
        {
            InitializeComponent();
                      
            bllCampeonato = new BLLCampeonato();
            campeonatoActual = new Campeonato();
            dataGridView1.ConfigurarGrids();
            dataGridView1.CargarGrid(new List<string> { "Nombre", "FechaInicio", "FechaFin", "CantidadPartidos", "CantidadJugadores"}, bllCampeonato.ListarTodo(true));
        }

        #region Botones

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            campeonatoActual = new Campeonato();
            CargarDatos(campeonatoActual);
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                campeonatoActual = dataGridView1.VerificarYRetornarSeleccion<Campeonato>();
                VerificarDatos();
                InputsExtensions.PedirConfirmacion();
                var response = bllCampeonato.Guardar(campeonatoActual);
                if (response)
                    MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataGridView1.CargarGrid(new List<string> { "Nombre", "FechaInicio", "FechaFin", "CantidadPartidos", "CantidadJugadores" }, bllCampeonato.ListarTodo(true));
                button1.Visible = false;
                button3.Visible = false;
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                VerificarDatos();
                InputsExtensions.PedirConfirmacion();
                var response = bllCampeonato.Guardar(campeonatoActual);
                if (response)
                    MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataGridView1.CargarGrid(new List<string> { "Nombre", "FechaInicio", "FechaFin", "CantidadPartidos", "CantidadJugadores" }, bllCampeonato.ListarTodo(true));
                button1.Visible = false;
            }
        }

        //Generar fixture
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var response = bllCampeonato.GuardarGenerandoFixture(campeonatoActual);
                button1.Visible = true;
                button3.Visible = false;
            }
            catch (Exception ex)
            {
                button1.Visible = false;
                button3.Visible = true;
                MessageBox.Show(ex.Message);
            }      
        }

        #endregion

        //Click en datagrid
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            campeonatoActual = dataGridView1.VerificarYRetornarSeleccion<Campeonato>();
            CargarDatos(campeonatoActual);
            if (campeonatoActual.Partidos.IsNOTNullOrEmpty())
            {
                button3.Visible = false;
                button1.Visible = true;
            }
            else
            {
                button3.Visible = true;
                button1.Visible = false;
            }
        }
 
        //Ver partidos        
        private void button1_Click(object sender, EventArgs e)
        {
            campeonatoActual = dataGridView1.VerificarYRetornarSeleccion<Campeonato>();
            AbrirForm_Partidos?.Invoke(this, new CampeonatoEventArgs(campeonatoActual));
        }

        #region Metodos

        private void CargarDatos(Campeonato item)
        {
            campeonatoActual.Id = item.Id;
            textBox1.Text = item.Nombre;
            dateTimePicker1.Value = item.FechaInicio < new DateTime(2022, 1, 1) ? new DateTime(2022, 1, 1) : item.FechaInicio;
            dateTimePicker2.Value = item.FechaFin < new DateTime(2022, 1, 1) ? new DateTime(2022, 1, 1) : item.FechaFin;
            numericUpDown1.Value = item.CantidadPartidos;
            numericUpDown2.Value = item.CantidadJugadores;
        }

        private void VerificarDatos()
        {
            // Verificar si el nombre del campeonato está vacío
            if (string.IsNullOrEmpty(textBox1.Text)
            || (dateTimePicker1.Value == DateTime.MinValue)
            || (dateTimePicker2.Value == DateTime.MinValue)
            || (numericUpDown1.Value <= 0)
            || (numericUpDown2.Value <= 0))
            {
                throw new Exception("Complete todos los campos para continuar");
            }
            campeonatoActual.Nombre= textBox1.Text;
            campeonatoActual.FechaInicio = dateTimePicker1.Value;
            campeonatoActual.FechaFin = dateTimePicker2.Value;
            campeonatoActual.CantidadPartidos = (int)numericUpDown1.Value;
            campeonatoActual.CantidadJugadores= (int)numericUpDown2.Value;
        }

        #endregion

    }

    public class CampeonatoEventArgs : EventArgs
    {
        public Campeonato campeonato { get; }

        public CampeonatoEventArgs(Campeonato campeonato)
        {
            this.campeonato = campeonato;
        }
    }
}

using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Abstraccion.Extensiones;

namespace LUGIntegrador
{
    public partial class Form_Convocatorias : Form
    {
        #region Blls

        BLLCampeonato bllCampeonato;
        BLLPartido bllPartidos;
        BLLConvocatoria bllConvocatoria;
        BLLEquipo bLLEquipo;

        Campeonato campeonatoActual;
        Equipo equipoActual;
        Partido partidoActual;

        #endregion

        public Form_Convocatorias()
        {
            InitializeComponent();

            bllCampeonato = new BLLCampeonato();
            bllPartidos = new BLLPartido();
            bllConvocatoria = new BLLConvocatoria();
            bLLEquipo = new BLLEquipo();

            CargarCombos();
            dataGridView1.ConfigurarGrids();
            dataGridView1.CargarGrid(new List<string> { "Posicion", "Fecha", "Ubicacion", "NombreJugador", "Confirmacion" }, bllConvocatoria.ListarTodo(true));
        }

        #region Buttons
        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            try
            {
                campeonatoActual = null;
                equipoActual = null;
                partidoActual = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CargarCombos();
            }
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            var lista = bllConvocatoria.ListarConFiltros(campeonatoActual,equipoActual,null, partidoActual );
            dataGridView1.CargarGrid(new List<string> { "Posicion", "Fecha", "Ubicacion", "NombreJugador", "Confirmacion" }, lista);
        }

        private void button_Imprimir_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void CargarCombos()
        {
            if (campeonatoActual==null)
            {
                var items = bllCampeonato.ListarTodo(true);
                comboBox_Campeonatos.DataSource = items;
                comboBox_Campeonatos.DisplayMember = "Nombre";
                comboBox_Campeonatos.SelectedItem = items.FirstOrDefault();
            }
            if (equipoActual == null) 
            {
                var items = bLLEquipo.ListarTodo(false);
                comboBox_Equipos.DataSource = items;
                comboBox_Equipos.DisplayMember = "Nombre";
                comboBox_Equipos.SelectedItem = items.FirstOrDefault();
            }
            if (partidoActual == null)
            {
                comboBox_Partidos.DataSource = campeonatoActual?.Partidos;
                comboBox_Partidos.DisplayMember = "Fecha";
                comboBox_Partidos.SelectedItem = campeonatoActual?.Partidos.FirstOrDefault();
            }
        }

        private void comboBox_Campeonatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            campeonatoActual = comboBox_Campeonatos.SelectedItem as Campeonato;
            var items = bLLEquipo.ListarTodo(false);
            comboBox_Equipos.DataSource = items;
            comboBox_Equipos.DisplayMember = "Nombre";
            comboBox_Equipos.SelectedItem = items.FirstOrDefault();

            comboBox_Partidos.DataSource = campeonatoActual?.Partidos;
            comboBox_Partidos.DisplayMember = "Fecha";
            comboBox_Partidos.SelectedItem = campeonatoActual?.Partidos.FirstOrDefault();
        }

        private void comboBox_Equipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipoActual = comboBox_Equipos.SelectedItem as Equipo;
            
            comboBox_Partidos.DataSource = campeonatoActual?.Partidos;
            comboBox_Partidos.DisplayMember = "Fecha";
            comboBox_Partidos.SelectedItem = campeonatoActual?.Partidos.FirstOrDefault();
        }

        private void comboBox_Partidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            partidoActual = comboBox_Partidos.SelectedItem as Partido;
        }
    }
}

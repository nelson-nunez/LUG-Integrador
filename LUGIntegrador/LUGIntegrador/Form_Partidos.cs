using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL;
using Abstraccion.Extensiones;

namespace LUGIntegrador
{
    public partial class Form_Partidos : Form
    {
        #region Blls

        BLLCampeonato bllCampeonato;
        BLLPartido bllPartidos;
        BLLConvocatoria bllConvocatoria;
        BLLEquipo bLLEquipo;

        Equipo equipoActual;
        Campeonato campeonatoActual;
        Partido partidoActual;

        #endregion

        public Form_Partidos(Campeonato campeonato)
        {
            InitializeComponent();

            bllCampeonato = new BLLCampeonato();
            bllPartidos = new BLLPartido();
            bllConvocatoria = new BLLConvocatoria();
            bLLEquipo = new BLLEquipo();

            equipoActual = new Equipo();
            campeonatoActual = campeonato!= null ? campeonato : new Campeonato();
            partidoActual = new Partido();

            dataGridView1.ConfigurarGrids();
            comboBox1.DataSource = bLLEquipo.ListarTodo(false);
            comboBox1.DisplayMember = "Nombre";
            lbl_campeonato.Text = campeonatoActual.Nombre;

            dataGridView1.ConfigurarGrids();
            dataGridView1.CargarGrid(new List<string> { "Fecha", "Duracion", "NumeroCancha", "Ubicacion", "Categoria" }, campeonatoActual.Partidos.ToList());
        }

        //Combobox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                equipoActual = comboBox1.SelectedItem as Equipo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Mostrar();
            }
        }

        //Click partidos
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                partidoActual = dataGridView1.VerificarYRetornarSeleccion<Partido>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Mostrar();
            }
        }
     
        //Convocatoria
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (equipoActual?.Id == 0 || partidoActual?.Id == 0 || campeonatoActual?.Id == 0)
                    throw new Exception("Seleccione un equipo, capeonato y partido para continuar.");

                var response = bllConvocatoria.GenerarConvocatoriasParaPartido(partidoActual, equipoActual);
                if (response)
                    MessageBox.Show("Se generó la convocatoria para el equipo correctamente.");
                else
                    MessageBox.Show("Error. Intente nuevamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Mostrar();
            }
        }

        private void Mostrar()
        {
            lbl_campeonato.Text = "Campeonato: " + campeonatoActual?.Nombre;
            lbl_equipo.Text = "Equipo: " + equipoActual?.Nombre;
            lbl_partido.Text = "Fecha: " + partidoActual?.Fecha.ToShortDateString();
        }
    }
}
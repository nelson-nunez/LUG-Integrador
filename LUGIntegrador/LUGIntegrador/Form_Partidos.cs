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
using static BE.Campeonato;

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

        public Form_Partidos()
        {
            InitializeComponent();

            bllCampeonato = new BLLCampeonato();
            bllPartidos = new BLLPartido();
            bllConvocatoria = new BLLConvocatoria();
            bLLEquipo = new BLLEquipo();

            equipoActual = new Equipo();
            campeonatoActual = new Campeonato();
            partidoActual = new Partido();

            dataGridView1.ConfigurarGrids();
            dataGridView2.ConfigurarGrids();

            dataGridView1.Mostrar(bllCampeonato.ListarTodoConFixture());
            comboBox1.DataSource = bLLEquipo.ListarTodo(false);
            comboBox1.DisplayMember = "Nombre";
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
                label1.Text = "Equipo: " + equipoActual.Nombre;
            }
        }
        //Click en datagrid1 Campeonatos
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                campeonatoActual = dataGridView1.VerificarYRetornarSeleccion<Campeonato>();
                //dataGridView2.Mostrar(campeonatoActual.RetornarVista());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                label2.Text = "Campeonato: " + campeonatoActual.Nombre;
            }
        }
        //Click partidos
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //var item = dataGridView2.VerificarYRetornarSeleccion<PartidoView>();
                //partidoActual = bllPartidos.ListarObjeto(item.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                label3.Text = "Partido: " + partidoActual.Fecha.ToShortDateString();
            }
        }
        //Convocatoria
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //campeonatoActual = dataGridView1.VerificarYRetornarSeleccion<Campeonato>();
                ////var item = dataGridView2.VerificarYRetornarSeleccion<PartidoView>();
                //partidoActual = bllPartidos.ListarObjeto(item.Id);
                //equipoActual = comboBox1.SelectedItem as Equipo;
                //if (equipoActual == null || partidoActual == null || campeonatoActual==null)
                //    throw new Exception("Seleccione un equipo, capeonato y partido para continuar.");

                //var response = bllConvocatoria.GenerarConvocatoriasParaPartido(partidoActual, equipoActual);
                //if (response)
                //    MessageBox.Show("Se generó la convocatoria correctamente.");
                //else
                //    MessageBox.Show("Error. Intente nuevamente.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
    }
}
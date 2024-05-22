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
        #endregion

        public Form_Partidos()
        {
            InitializeComponent();

            bllCampeonato = new BLLCampeonato();

            dataGridView1.ConfigurarGrids();
            dataGridView2.ConfigurarGrids();
            dataGridView1.Mostrar(bllCampeonato.ListarTodoConFixture());
            comboBox1.DataSource = bLLEquipo.ListarTodo();
        }

        //Click en datagrid1 Campeonatos
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var campeonatoActual = dataGridView1.VerificarYRetornarSeleccion<Campeonato>();
                dataGridView2.Mostrar(campeonatoActual.RetornarVista());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Convocatoria
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var campeonatoActual = dataGridView1.VerificarYRetornarSeleccion<Campeonato>();
                var partidoactual = dataGridView2.VerificarYRetornarSeleccion<Partido>();
                equipoActual = comboBox1.SelectedItem as Equipo;
                if ( equipoActual == null )
                {
                    MessageBox.Show("Seleccione un equipo para continuar.");
                    return;
                }

                bllConvocatoria.GenerarConvocatoriasParaPartido(partidoactual, equipoActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
ASfafsaSDFGASDGAG
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
    public partial class Form_Equipo : Form
    {
        BLLEquipo  bLLEquipo;
        BLLJugador  bLLJugador;
        Equipo equipoActual;


        public Form_Equipo()
        {
            InitializeComponent();
            bLLEquipo = new BLLEquipo();
            bLLJugador = new BLLJugador();  
            equipoActual = new Equipo();
            
            dataGridView1.ConfigurarGrids();
            dataGridView2.ConfigurarGrids();
            dataGridView3.ConfigurarGrids();

            dataGridView1.Mostrar(bLLEquipo.ListarTodo(true));
        }
    
        #region Buttons
        //Borrar
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                equipoActual = dataGridView1.VerificarYRetornarSeleccion<Equipo>();
                VerificarDatos();
                var response = bLLEquipo.Baja(equipoActual.Id);
                if (response)
                    MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataGridView3.Mostrar(bLLEquipo.ListarTodo(false));
            }
        }

        //Limpiar campos
        private void button6_Click(object sender, EventArgs e)
        {
            equipoActual = new Equipo();
            CargarDatos(equipoActual);
        }
        //Guardar
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                VerificarDatos();
                var response = bLLEquipo.Guardar(equipoActual);
                if (response)
                    MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataGridView3.Mostrar(bLLEquipo.ListarTodo(false));
            }
        }

        //Click en lista equipos
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                equipoActual = dataGridView1.VerificarYRetornarSeleccion<Equipo>();
                CargarDatos(equipoActual);
                dataGridView2.Mostrar(bLLJugador.ListarJugadoresPorEquipo(equipoActual.Id));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataGridView3.Mostrar(bLLJugador.ListarJugadoresDisponibles());
            }
        }

        //Elimnar jugadores
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var jugadorborrar = dataGridView2.VerificarYRetornarSeleccion<JugadorView>();
                if (jugadorborrar != null)
                {
                    var response = bLLEquipo.EliminarJugador(equipoActual.Id, jugadorborrar.Id);
                    if (response)
                        MessageBox.Show("Se eliminó de la plantilla con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataGridView2.Mostrar(bLLJugador.ListarJugadoresPorEquipo(equipoActual.Id));
                dataGridView3.Mostrar(bLLJugador.ListarJugadoresDisponibles());
            }
        }
   
        //Asignar jugador
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var jugadorborrar = dataGridView3.VerificarYRetornarSeleccion<JugadorView>();
                if (jugadorborrar != null)
                {
                    var response = bLLEquipo.AñadirJugador(equipoActual.Id, jugadorborrar.Id);
                    if (response)
                        MessageBox.Show("Se asignó al equipo con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataGridView2.Mostrar(bLLJugador.ListarJugadoresPorEquipo(equipoActual.Id));
                dataGridView3.Mostrar(bLLJugador.ListarJugadoresDisponibles());
            }
        }

        #endregion      
        
        private void CargarDatos(Equipo item)
        {
            textBox1.Text = item.Nombre;
            textBox2.Text = item.Descripcion;            
        }

        private void VerificarDatos()
        {
            equipoActual.Nombre = textBox1.Text;
            equipoActual.Descripcion = textBox2.Text;
            // Verificar si el nombre del campeonato está vacío
            if (string.IsNullOrEmpty(textBox1.Text)|| string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Complete todos los campos para continuar");
                return;
            }
        }


    }
}

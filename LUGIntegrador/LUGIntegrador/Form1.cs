using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI_LUGIntegrador
{
    public partial class Form1 : Form
    {
        #region Blls

        //BLLEntrenador bllEntrenador;

        #endregion


        public Form1()
        {
            InitializeComponent();
            //bllEntrenador = new BLLEntrenador();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BLLPrueba oBLLPrueba = new BLLPrueba();
            //uso el metodo testconnection que me dice el estado de la conexion., Y USO EL CONSTRUCTOR DE MessageBox
            MessageBox.Show(oBLLPrueba.TestCX(), "PROBANDO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //var tt = bllEntrenador.ListarTodo();
            MessageBox.Show("asdasd");
        }
    }
}

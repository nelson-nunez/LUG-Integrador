using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_LUGIntegrador;

namespace LUGIntegrador
{
    public partial class Form_Menu : Form
    {
        private Form_Campeonato formcampeonatos;
        private Form_Equipo formequipo;
        private Form_Partidos formpartidos ;
        private Form_Persona formpersonas;

        public Form_Menu()
        {
            InitializeComponent();
            // Hacer que esta ventana sea un contenedor MDI
            this.IsMdiContainer = true;
            //Abro por defecto el mp3
            //AbrirFormGeneral(ref );
        }

        private void AbrirFormCampeonato(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref formcampeonatos);
        }
        private void AbrirFormEquipo(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref formequipo);
        }
        private void AbrirFormPartido(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref formpartidos);
        }
        private void AbrirFormPersona(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref formpersonas);
        }

        private void AbrirFormGeneral<T>(ref T formulario) where T : Form, new()
        {
            if (formulario == null || formulario.IsDisposed)
            {
                T nuevoFormulario = new T();
                //Dentro del padre
                nuevoFormulario.MdiParent = this;
                //Sin controles de cerrar
                nuevoFormulario.ControlBox = false;
                //Sin bordes
                nuevoFormulario.FormBorderStyle = FormBorderStyle.None;
                // Establecer la ubicación centrada
                nuevoFormulario.StartPosition = FormStartPosition.CenterScreen;
                formulario = nuevoFormulario;
            }

            formulario.Show();
            formulario.BringToFront();
        }

        private void CerrarTodosLosFormulariosHijos(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }
    }
}

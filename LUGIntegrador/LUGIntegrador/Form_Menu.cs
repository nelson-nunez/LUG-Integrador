using BE;
using BLL;
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
        private Form_Persona formpersonas;
        private UC_Login uc_login;

        public Form_Menu()
        {
            InitializeComponent();
            // Hacer que esta ventana sea un contenedor MDI
            this.IsMdiContainer = true;
            
            // Ocultar el menú hasta que se inicie sesión correctamente
            menuStrip1.Visible = false;
           
            // Crear y centrar el UC_Login
            uc_login = new UC_Login();
            uc_login.Anchor = AnchorStyles.None;
            uc_login.Left = (this.ClientSize.Width - uc_login.Width) / 2;
            uc_login.Top = (this.ClientSize.Height - uc_login.Height) / 2;
            this.Controls.Add(uc_login);
            uc_login.LoginSuccess += Uc_Login_LoginSuccess;
        }

        private void Uc_Login_LoginSuccess(object sender, PersonaEventArgs e)
        {
            Persona persona = e.Persona;
            MessageBox.Show($"Bienvenido, {persona.Nombre} {persona.Apellido}!");
            menuStrip1.Visible = true;  
            uc_login.Visible = false;  
        }
        private void AbrirFormCampeonato(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref formcampeonatos);
            formcampeonatos.AbrirForm_Partidos += AbrirFormPartido;
        }
        private void AbrirFormPartido(object sender, CampeonatoEventArgs e)
        {
            Campeonato campeonato = e.campeonato;
            var formPartidos = new Form_Partidos(campeonato);
            formPartidos.MdiParent = this;
            formPartidos.ControlBox = false;
            formPartidos.FormBorderStyle = FormBorderStyle.None;
            formPartidos.StartPosition = FormStartPosition.CenterScreen;
            formPartidos.Show();
            formPartidos.BringToFront();
        }
        private void AbrirFormEquipo(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref formequipo);
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

            menuStrip1.Visible = false; 
            uc_login.Visible = true;
        }
    }
}

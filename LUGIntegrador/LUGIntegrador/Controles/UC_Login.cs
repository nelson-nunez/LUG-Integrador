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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BE;
using UI_LUGIntegrador.Extensiones;
using System.Reflection.Emit;


namespace LUGIntegrador
{
    public partial class UC_Login : UserControl
    {
        BLLPersona bllPersona;
        BLLPrueba bllPrueba;
        PersonaView loggedperson;
        public event EventHandler<PersonaEventArgs> LoginSuccess;
        public UC_Login()
        {
            InitializeComponent();

            bllPrueba = new BLLPrueba();
            //var tt = bllPrueba.TestCX();
            //MessageBox.Show(tt);


            bllPersona = new BLLPersona();
            //Prueba borrar
            email.Text = "carlos.ramirez@example.com";
            password.Text = "password4";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                VerificarDatos();
                loggedperson = bllPersona.Login(email.Text, password.Text);
                if (loggedperson != null)
                {
                    MessageBox.Show("Ingresó con éxito");
                    OnLoginSuccess(loggedperson);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //
            }
        }

        private void OnLoginSuccess(PersonaView persona)
        {
            LoginSuccess?.Invoke(this, new PersonaEventArgs(persona));
        }

        private void VerificarDatos()
        {
            if (string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("Complete todos los campos para continuar");
                return;
            }
            if (!email.Text.IsValidEmail())
            {
                MessageBox.Show("Ingrese un email válido para continuar");
                return;
            }
        }
    }

    public class PersonaEventArgs : EventArgs
    {
        public PersonaView Persona { get; }

        public PersonaEventArgs(PersonaView persona)
        {
            Persona = persona;
        }
    }
}

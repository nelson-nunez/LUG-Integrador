﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_LUGIntegrador.Extensiones
{
    public static class InputsExtensions
    {
        public static int InputBoxNumeric(this string title)
        {
            var valor = Interaction.InputBox(title);
            if (!int.TryParse(valor, out int valorsal))
                throw new Exception("El valor ingresado debe ser numérico.");

            return valorsal;
        }

        public static DateTime InputBoxDateNumeric(this string title)
        {
            var fechaStr = Interaction.InputBox(title);
            DateTime fechaVencimiento;
            if (!DateTime.TryParseExact(fechaStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaVencimiento))
                throw new Exception("Formato de fecha incorrecto. Use DD/MM/AAAA.");

            return fechaVencimiento;
        }

        public static bool IsNOTNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }
        public static bool IsNOTNullOrEmpty<T>(this ICollection<T> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }

        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            try
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                return regex.IsMatch(email);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static void PedirConfirmacion()
        {
            DialogResult result = MessageBox.Show("Desea continuar con la operación?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                throw new Exception("Se canceló la operación");
        }
    }
}

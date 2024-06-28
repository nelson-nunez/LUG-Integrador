using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUGIntegrador
{
    public partial class Form_Reporte : Form
    {
        public Form_Reporte()
        {
            InitializeComponent();
        }

        private void Form_Reporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'lUGDataSet1.sp_reporte' Puede moverla o quitarla según sea necesario.
            this.sp_reporteTableAdapter.Fill(this.lUGDataSet1.sp_reporte);
            // TODO: esta línea de código carga datos en la tabla 'lUGDataSet.Convocatoria' Puede moverla o quitarla según sea necesario.
            this.convocatoriaTableAdapter.Fill(this.lUGDataSet.Convocatoria);

            this.reportViewer1.RefreshReport();
        }
    }
}

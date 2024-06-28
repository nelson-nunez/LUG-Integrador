namespace LUGIntegrador
{
    partial class Form_Reporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.lUGDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lUGDataSet = new LUGIntegrador.LUGDataSet();
            this.convocatoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.convocatoriaTableAdapter = new LUGIntegrador.LUGDataSetTableAdapters.ConvocatoriaTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lUGDataSet1 = new LUGIntegrador.LUGDataSet1();
            this.spreporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_reporteTableAdapter = new LUGIntegrador.LUGDataSet1TableAdapters.sp_reporteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.lUGDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.convocatoriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUGDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreporteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lUGDataSetBindingSource
            // 
            this.lUGDataSetBindingSource.DataSource = this.lUGDataSet;
            this.lUGDataSetBindingSource.Position = 0;
            // 
            // lUGDataSet
            // 
            this.lUGDataSet.DataSetName = "LUGDataSet";
            this.lUGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // convocatoriaBindingSource
            // 
            this.convocatoriaBindingSource.DataMember = "Convocatoria";
            this.convocatoriaBindingSource.DataSource = this.lUGDataSetBindingSource;
            // 
            // convocatoriaTableAdapter
            // 
            this.convocatoriaTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spreporteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LUGIntegrador.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(734, 612);
            this.reportViewer1.TabIndex = 0;
            // 
            // lUGDataSet1
            // 
            this.lUGDataSet1.DataSetName = "LUGDataSet1";
            this.lUGDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spreporteBindingSource
            // 
            this.spreporteBindingSource.DataMember = "sp_reporte";
            this.spreporteBindingSource.DataSource = this.lUGDataSet1;
            // 
            // sp_reporteTableAdapter
            // 
            this.sp_reporteTableAdapter.ClearBeforeFill = true;
            // 
            // Form_Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 612);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form_Reporte";
            this.Text = "Form_Reporte";
            this.Load += new System.EventHandler(this.Form_Reporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lUGDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.convocatoriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUGDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreporteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private LUGDataSet lUGDataSet;
        private System.Windows.Forms.BindingSource lUGDataSetBindingSource;
        private System.Windows.Forms.BindingSource convocatoriaBindingSource;
        private LUGDataSetTableAdapters.ConvocatoriaTableAdapter convocatoriaTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private LUGDataSet1 lUGDataSet1;
        private System.Windows.Forms.BindingSource spreporteBindingSource;
        private LUGDataSet1TableAdapters.sp_reporteTableAdapter sp_reporteTableAdapter;
    }
}
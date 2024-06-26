namespace LUGIntegrador
{
    partial class Form_Convocatorias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_Campeonatos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Equipos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Partidos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.button_Imprimir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 588);
            this.groupBox1.TabIndex = 150;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Convocatorias";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 184);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(696, 398);
            this.dataGridView1.TabIndex = 124;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Buscar);
            this.groupBox2.Controls.Add(this.comboBox_Partidos);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button_Limpiar);
            this.groupBox2.Controls.Add(this.button_Imprimir);
            this.groupBox2.Controls.Add(this.comboBox_Equipos);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBox_Campeonatos);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(696, 157);
            this.groupBox2.TabIndex = 156;
            this.groupBox2.TabStop = false;
            // 
            // comboBox_Campeonatos
            // 
            this.comboBox_Campeonatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Campeonatos.FormattingEnabled = true;
            this.comboBox_Campeonatos.Location = new System.Drawing.Point(107, 15);
            this.comboBox_Campeonatos.Name = "comboBox_Campeonatos";
            this.comboBox_Campeonatos.Size = new System.Drawing.Size(268, 23);
            this.comboBox_Campeonatos.TabIndex = 151;
            this.comboBox_Campeonatos.SelectedIndexChanged += new System.EventHandler(this.comboBox_Campeonatos_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 150;
            this.label5.Text = "Campeonato";
            // 
            // comboBox_Equipos
            // 
            this.comboBox_Equipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Equipos.FormattingEnabled = true;
            this.comboBox_Equipos.Location = new System.Drawing.Point(107, 44);
            this.comboBox_Equipos.Name = "comboBox_Equipos";
            this.comboBox_Equipos.Size = new System.Drawing.Size(268, 23);
            this.comboBox_Equipos.TabIndex = 153;
            this.comboBox_Equipos.SelectedIndexChanged += new System.EventHandler(this.comboBox_Equipos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 152;
            this.label1.Text = "Equipo";
            // 
            // comboBox_Partidos
            // 
            this.comboBox_Partidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Partidos.FormattingEnabled = true;
            this.comboBox_Partidos.Location = new System.Drawing.Point(107, 73);
            this.comboBox_Partidos.Name = "comboBox_Partidos";
            this.comboBox_Partidos.Size = new System.Drawing.Size(268, 23);
            this.comboBox_Partidos.TabIndex = 155;
            this.comboBox_Partidos.SelectedIndexChanged += new System.EventHandler(this.comboBox_Partidos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 154;
            this.label2.Text = "Partido";
            // 
            // button_Buscar
            // 
            this.button_Buscar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button_Buscar.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Buscar.ForeColor = System.Drawing.Color.White;
            this.button_Buscar.Location = new System.Drawing.Point(305, 108);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(82, 36);
            this.button_Buscar.TabIndex = 159;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = false;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_Limpiar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Limpiar.ForeColor = System.Drawing.Color.White;
            this.button_Limpiar.Location = new System.Drawing.Point(217, 109);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(82, 36);
            this.button_Limpiar.TabIndex = 157;
            this.button_Limpiar.Text = "Limpiar Campos";
            this.button_Limpiar.UseVisualStyleBackColor = false;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click);
            // 
            // button_Imprimir
            // 
            this.button_Imprimir.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_Imprimir.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Imprimir.ForeColor = System.Drawing.Color.White;
            this.button_Imprimir.Location = new System.Drawing.Point(393, 108);
            this.button_Imprimir.Name = "button_Imprimir";
            this.button_Imprimir.Size = new System.Drawing.Size(82, 36);
            this.button_Imprimir.TabIndex = 158;
            this.button_Imprimir.Text = "Imprimir";
            this.button_Imprimir.UseVisualStyleBackColor = false;
            this.button_Imprimir.Click += new System.EventHandler(this.button_Imprimir_Click);
            // 
            // Form_Convocatorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 612);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Convocatorias";
            this.Text = "Form_Convocatorias";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_Campeonatos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_Partidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Equipos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.Button button_Imprimir;
    }
}
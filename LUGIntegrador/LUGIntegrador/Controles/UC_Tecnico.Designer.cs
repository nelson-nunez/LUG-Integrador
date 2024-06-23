namespace LUGIntegrador.Controles
{
    partial class UC_Tecnico
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dni = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.fechanacimiento = new System.Windows.Forms.DateTimePicker();
            this.button11 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.titulo = new System.Windows.Forms.TextBox();
            this.licencia = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.licencia)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox6.Controls.Add(this.licencia);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.titulo);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.dni);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.apellido);
            this.groupBox6.Controls.Add(this.button10);
            this.groupBox6.Controls.Add(this.fechanacimiento);
            this.groupBox6.Controls.Add(this.button11);
            this.groupBox6.Controls.Add(this.button13);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.nombre);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(708, 164);
            this.groupBox6.TabIndex = 145;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Técnico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(235, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 15);
            this.label2.TabIndex = 154;
            this.label2.Text = "DNI";
            // 
            // dni
            // 
            this.dni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dni.Location = new System.Drawing.Point(271, 77);
            this.dni.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(125, 21);
            this.dni.TabIndex = 149;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(45, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Fec. Nac";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 152;
            this.label1.Text = "Apellido";
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(105, 49);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(291, 22);
            this.apellido.TabIndex = 151;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(610, 106);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(82, 36);
            this.button10.TabIndex = 148;
            this.button10.Text = "Guardar";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // fechanacimiento
            // 
            this.fechanacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechanacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechanacimiento.Location = new System.Drawing.Point(105, 77);
            this.fechanacimiento.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.fechanacimiento.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.fechanacimiento.Name = "fechanacimiento";
            this.fechanacimiento.Size = new System.Drawing.Size(117, 20);
            this.fechanacimiento.TabIndex = 10;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.IndianRed;
            this.button11.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(610, 22);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(82, 36);
            this.button11.TabIndex = 147;
            this.button11.Text = "Borrar";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.SystemColors.Highlight;
            this.button13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(610, 64);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(82, 36);
            this.button13.TabIndex = 145;
            this.button13.Text = "Limpiar Campos";
            this.button13.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(48, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 15);
            this.label13.TabIndex = 1;
            this.label13.Text = "Nombre";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(105, 21);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(291, 22);
            this.nombre.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 157;
            this.label4.Text = "Título";
            // 
            // titulo
            // 
            this.titulo.Location = new System.Drawing.Point(105, 103);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(291, 22);
            this.titulo.TabIndex = 156;
            // 
            // licencia
            // 
            this.licencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licencia.Location = new System.Drawing.Point(105, 131);
            this.licencia.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.licencia.Name = "licencia";
            this.licencia.Size = new System.Drawing.Size(117, 21);
            this.licencia.TabIndex = 158;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 159;
            this.label3.Text = "Licencia";
            // 
            // UC_Tecnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox6);
            this.Name = "UC_Tecnico";
            this.Size = new System.Drawing.Size(717, 170);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.licencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown dni;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DateTimePicker fechanacimiento;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.NumericUpDown licencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox titulo;
    }
}

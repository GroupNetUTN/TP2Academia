namespace UI.Desktop
{
    partial class PermisosPersonas
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
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAlta = new System.Windows.Forms.CheckBox();
            this.chkBaja = new System.Windows.Forms.CheckBox();
            this.chkConsulta = new System.Windows.Forms.CheckBox();
            this.chkModificacion = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(295, 197);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(100, 30);
            this.btnSiguiente.TabIndex = 10;
            this.btnSiguiente.Text = "Siguiente   >>";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAlta);
            this.groupBox1.Controls.Add(this.chkBaja);
            this.groupBox1.Controls.Add(this.chkConsulta);
            this.groupBox1.Controls.Add(this.chkModificacion);
            this.groupBox1.Location = new System.Drawing.Point(17, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 136);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione las actividades que se le permitiran realizar al usuario";
            // 
            // chkAlta
            // 
            this.chkAlta.AutoSize = true;
            this.chkAlta.Location = new System.Drawing.Point(6, 29);
            this.chkAlta.Name = "chkAlta";
            this.chkAlta.Size = new System.Drawing.Size(135, 17);
            this.chkAlta.TabIndex = 0;
            this.chkAlta.Text = "Crear nuevas personas";
            this.chkAlta.UseVisualStyleBackColor = true;
            // 
            // chkBaja
            // 
            this.chkBaja.AutoSize = true;
            this.chkBaja.Location = new System.Drawing.Point(6, 52);
            this.chkBaja.Name = "chkBaja";
            this.chkBaja.Size = new System.Drawing.Size(108, 17);
            this.chkBaja.TabIndex = 1;
            this.chkBaja.Text = "Eliminar personas";
            this.chkBaja.UseVisualStyleBackColor = true;
            // 
            // chkConsulta
            // 
            this.chkConsulta.AutoSize = true;
            this.chkConsulta.Location = new System.Drawing.Point(6, 100);
            this.chkConsulta.Name = "chkConsulta";
            this.chkConsulta.Size = new System.Drawing.Size(158, 17);
            this.chkConsulta.TabIndex = 3;
            this.chkConsulta.Text = "Acceso a personas creadas";
            this.chkConsulta.UseVisualStyleBackColor = true;
            // 
            // chkModificacion
            // 
            this.chkModificacion.AutoSize = true;
            this.chkModificacion.Location = new System.Drawing.Point(6, 76);
            this.chkModificacion.Name = "chkModificacion";
            this.chkModificacion.Size = new System.Drawing.Size(99, 17);
            this.chkModificacion.TabIndex = 2;
            this.chkModificacion.Text = "Editar personas";
            this.chkModificacion.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Asignación de permisos relacionados con la gestión de las personas de la \r\nacadem" +
    "ia.";
            // 
            // PermisosPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 242);
            this.ControlBox = false;
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "PermisosPersonas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de Permisos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAlta;
        private System.Windows.Forms.CheckBox chkBaja;
        private System.Windows.Forms.CheckBox chkConsulta;
        private System.Windows.Forms.CheckBox chkModificacion;
        private System.Windows.Forms.Label label1;
    }
}
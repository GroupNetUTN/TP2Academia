namespace UI.Desktop
{
    partial class EditorDePermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorDePermisos));
            this.label1 = new System.Windows.Forms.Label();
            this.cbxModulos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkConsulta = new System.Windows.Forms.CheckBox();
            this.chkModificacion = new System.Windows.Forms.CheckBox();
            this.chkBaja = new System.Windows.Forms.CheckBox();
            this.chkAlta = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // cbxModulos
            // 
            this.cbxModulos.FormattingEnabled = true;
            this.cbxModulos.Items.AddRange(new object[] {
            "",
            "Usuarios",
            "Personas",
            "Planes",
            "Materias",
            "Especialidades",
            "Cursos",
            "Comisiones",
            "Inscripciones"});
            this.cbxModulos.Location = new System.Drawing.Point(12, 94);
            this.cbxModulos.Name = "cbxModulos";
            this.cbxModulos.Size = new System.Drawing.Size(150, 21);
            this.cbxModulos.TabIndex = 1;
            this.cbxModulos.SelectionChangeCommitted += new System.EventHandler(this.cbxModulos_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Modulos de acciones:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkConsulta);
            this.groupBox1.Controls.Add(this.chkModificacion);
            this.groupBox1.Controls.Add(this.chkBaja);
            this.groupBox1.Controls.Add(this.chkAlta);
            this.groupBox1.Location = new System.Drawing.Point(182, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 133);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones permitidas";
            // 
            // chkConsulta
            // 
            this.chkConsulta.AutoSize = true;
            this.chkConsulta.Location = new System.Drawing.Point(6, 102);
            this.chkConsulta.Name = "chkConsulta";
            this.chkConsulta.Size = new System.Drawing.Size(80, 17);
            this.chkConsulta.TabIndex = 3;
            this.chkConsulta.Text = "checkBox4";
            this.chkConsulta.UseVisualStyleBackColor = true;
            this.chkConsulta.Visible = false;
            // 
            // chkModificacion
            // 
            this.chkModificacion.AutoSize = true;
            this.chkModificacion.Location = new System.Drawing.Point(6, 78);
            this.chkModificacion.Name = "chkModificacion";
            this.chkModificacion.Size = new System.Drawing.Size(80, 17);
            this.chkModificacion.TabIndex = 2;
            this.chkModificacion.Text = "checkBox3";
            this.chkModificacion.UseVisualStyleBackColor = true;
            this.chkModificacion.Visible = false;
            // 
            // chkBaja
            // 
            this.chkBaja.AutoSize = true;
            this.chkBaja.Location = new System.Drawing.Point(6, 54);
            this.chkBaja.Name = "chkBaja";
            this.chkBaja.Size = new System.Drawing.Size(80, 17);
            this.chkBaja.TabIndex = 1;
            this.chkBaja.Text = "checkBox2";
            this.chkBaja.UseVisualStyleBackColor = true;
            this.chkBaja.Visible = false;
            // 
            // chkAlta
            // 
            this.chkAlta.AutoSize = true;
            this.chkAlta.Location = new System.Drawing.Point(6, 30);
            this.chkAlta.Name = "chkAlta";
            this.chkAlta.Size = new System.Drawing.Size(80, 17);
            this.chkAlta.TabIndex = 0;
            this.chkAlta.Text = "checkBox1";
            this.chkAlta.UseVisualStyleBackColor = true;
            this.chkAlta.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 156);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(330, 219);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 5;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // EditorDePermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 254);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxModulos);
            this.Controls.Add(this.label1);
            this.Name = "EditorDePermisos";
            this.Text = "Editor de Permisos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxModulos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkConsulta;
        private System.Windows.Forms.CheckBox chkModificacion;
        private System.Windows.Forms.CheckBox chkBaja;
        private System.Windows.Forms.CheckBox chkAlta;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnFinalizar;
    }
}
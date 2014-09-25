namespace UI.Desktop
{
    partial class UsuarioDesktop
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
            this.tlUsuarioDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtConfirmarClave = new System.Windows.Forms.TextBox();
            this.btnSeleccionarPersona = new System.Windows.Forms.Button();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.tlUsuarioDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlUsuarioDesktop
            // 
            this.tlUsuarioDesktop.ColumnCount = 4;
            this.tlUsuarioDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlUsuarioDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlUsuarioDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlUsuarioDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlUsuarioDesktop.Controls.Add(this.lblID, 0, 0);
            this.tlUsuarioDesktop.Controls.Add(this.btnCancelar, 3, 3);
            this.tlUsuarioDesktop.Controls.Add(this.btnAceptar, 2, 3);
            this.tlUsuarioDesktop.Controls.Add(this.txtID, 1, 0);
            this.tlUsuarioDesktop.Controls.Add(this.label6, 0, 1);
            this.tlUsuarioDesktop.Controls.Add(this.txtUsuario, 1, 1);
            this.tlUsuarioDesktop.Controls.Add(this.lblClave, 0, 2);
            this.tlUsuarioDesktop.Controls.Add(this.label7, 2, 2);
            this.tlUsuarioDesktop.Controls.Add(this.txtClave, 1, 2);
            this.tlUsuarioDesktop.Controls.Add(this.txtConfirmarClave, 3, 2);
            this.tlUsuarioDesktop.Controls.Add(this.btnSeleccionarPersona, 3, 1);
            this.tlUsuarioDesktop.Controls.Add(this.chkHabilitado, 3, 0);
            this.tlUsuarioDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlUsuarioDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlUsuarioDesktop.Name = "tlUsuarioDesktop";
            this.tlUsuarioDesktop.RowCount = 4;
            this.tlUsuarioDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.92593F));
            this.tlUsuarioDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.69136F));
            this.tlUsuarioDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tlUsuarioDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.54321F));
            this.tlUsuarioDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlUsuarioDesktop.Size = new System.Drawing.Size(584, 162);
            this.tlUsuarioDesktop.TabIndex = 1;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(381, 121);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(294, 121);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(90, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(198, 20);
            this.txtID.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsuario.Location = new System.Drawing.Point(90, 45);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(198, 20);
            this.txtUsuario.TabIndex = 4;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(3, 82);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(34, 13);
            this.lblClave.TabIndex = 3;
            this.lblClave.Text = "Clave";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Confirmar Clave";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(90, 85);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(198, 20);
            this.txtClave.TabIndex = 5;
            this.txtClave.UseSystemPasswordChar = true;
            // 
            // txtConfirmarClave
            // 
            this.txtConfirmarClave.Location = new System.Drawing.Point(381, 85);
            this.txtConfirmarClave.Name = "txtConfirmarClave";
            this.txtConfirmarClave.Size = new System.Drawing.Size(200, 20);
            this.txtConfirmarClave.TabIndex = 6;
            this.txtConfirmarClave.UseSystemPasswordChar = true;
            // 
            // btnSeleccionarPersona
            // 
            this.btnSeleccionarPersona.Location = new System.Drawing.Point(381, 45);
            this.btnSeleccionarPersona.Name = "btnSeleccionarPersona";
            this.btnSeleccionarPersona.Size = new System.Drawing.Size(128, 23);
            this.btnSeleccionarPersona.TabIndex = 18;
            this.btnSeleccionarPersona.Text = "Seleccionar Persona";
            this.btnSeleccionarPersona.UseVisualStyleBackColor = true;
            this.btnSeleccionarPersona.Click += new System.EventHandler(this.btnSeleccionarPersona_Click);
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Location = new System.Drawing.Point(381, 3);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitado.TabIndex = 7;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // UsuarioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 162);
            this.Controls.Add(this.tlUsuarioDesktop);
            this.Name = "UsuarioDesktop";
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.UsuarioDesktop_Load);
            this.tlUsuarioDesktop.ResumeLayout(false);
            this.tlUsuarioDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlUsuarioDesktop;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnSeleccionarPersona;
    }
}
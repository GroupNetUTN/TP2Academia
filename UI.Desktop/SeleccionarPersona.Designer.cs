namespace UI.Desktop
{
    partial class SeleccionarPersona
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
            this.dgvSeleccionarPersona = new System.Windows.Forms.DataGridView();
            this.tblSeleccionarPersona = new System.Windows.Forms.TableLayoutPanel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbxTipoPersona = new System.Windows.Forms.ComboBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionarPersona)).BeginInit();
            this.tblSeleccionarPersona.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSeleccionarPersona
            // 
            this.dgvSeleccionarPersona.AllowUserToAddRows = false;
            this.dgvSeleccionarPersona.AllowUserToDeleteRows = false;
            this.dgvSeleccionarPersona.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeleccionarPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeleccionarPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Apellido,
            this.Nombre,
            this.tipoPersona});
            this.tblSeleccionarPersona.SetColumnSpan(this.dgvSeleccionarPersona, 2);
            this.dgvSeleccionarPersona.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSeleccionarPersona.Location = new System.Drawing.Point(3, 32);
            this.dgvSeleccionarPersona.MultiSelect = false;
            this.dgvSeleccionarPersona.Name = "dgvSeleccionarPersona";
            this.dgvSeleccionarPersona.ReadOnly = true;
            this.dgvSeleccionarPersona.RowHeadersVisible = false;
            this.dgvSeleccionarPersona.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeleccionarPersona.Size = new System.Drawing.Size(354, 263);
            this.dgvSeleccionarPersona.TabIndex = 0;
            // 
            // tblSeleccionarPersona
            // 
            this.tblSeleccionarPersona.ColumnCount = 2;
            this.tblSeleccionarPersona.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSeleccionarPersona.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSeleccionarPersona.Controls.Add(this.dgvSeleccionarPersona, 0, 0);
            this.tblSeleccionarPersona.Controls.Add(this.btnAgregar, 0, 2);
            this.tblSeleccionarPersona.Controls.Add(this.btnCancelar, 1, 2);
            this.tblSeleccionarPersona.Controls.Add(this.cbxTipoPersona, 0, 0);
            this.tblSeleccionarPersona.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSeleccionarPersona.Location = new System.Drawing.Point(0, 0);
            this.tblSeleccionarPersona.Name = "tblSeleccionarPersona";
            this.tblSeleccionarPersona.RowCount = 3;
            this.tblSeleccionarPersona.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblSeleccionarPersona.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tblSeleccionarPersona.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSeleccionarPersona.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblSeleccionarPersona.Size = new System.Drawing.Size(360, 328);
            this.tblSeleccionarPersona.TabIndex = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(201, 301);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(282, 301);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbxTipoPersona
            // 
            this.cbxTipoPersona.FormattingEnabled = true;
            this.cbxTipoPersona.Items.AddRange(new object[] {
            "Todos",
            "Alumnos",
            "Docentes",
            "No docentes"});
            this.cbxTipoPersona.Location = new System.Drawing.Point(3, 3);
            this.cbxTipoPersona.Name = "cbxTipoPersona";
            this.cbxTipoPersona.Size = new System.Drawing.Size(121, 21);
            this.cbxTipoPersona.TabIndex = 3;
            this.cbxTipoPersona.Text = "Mostrar:";
            this.cbxTipoPersona.SelectedIndexChanged += new System.EventHandler(this.cbxTipoPersona_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "Apellido";
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // tipoPersona
            // 
            this.tipoPersona.DataPropertyName = "TipoPersona";
            this.tipoPersona.HeaderText = "TipoPersona";
            this.tipoPersona.Name = "tipoPersona";
            this.tipoPersona.ReadOnly = true;
            // 
            // SeleccionarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 328);
            this.Controls.Add(this.tblSeleccionarPersona);
            this.Name = "SeleccionarPersona";
            this.Text = "Personas";
            this.Load += new System.EventHandler(this.SeleccionarPersona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionarPersona)).EndInit();
            this.tblSeleccionarPersona.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSeleccionarPersona;
        private System.Windows.Forms.TableLayoutPanel tblSeleccionarPersona;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbxTipoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoPersona;
    }
}
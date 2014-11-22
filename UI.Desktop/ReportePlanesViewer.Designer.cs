namespace UI.Desktop
{
    partial class ReportePlanesViewer
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
            this.CRViewerPlanes = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRViewerPlanes
            // 
            this.CRViewerPlanes.ActiveViewIndex = -1;
            this.CRViewerPlanes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRViewerPlanes.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRViewerPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRViewerPlanes.Location = new System.Drawing.Point(0, 0);
            this.CRViewerPlanes.Name = "CRViewerPlanes";
            this.CRViewerPlanes.Size = new System.Drawing.Size(949, 530);
            this.CRViewerPlanes.TabIndex = 0;
            this.CRViewerPlanes.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReportePlanesViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 530);
            this.Controls.Add(this.CRViewerPlanes);
            this.Name = "ReportePlanesViewer";
            this.Text = "ReportePlanesViewer";
            this.Load += new System.EventHandler(this.ReportePlanesViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRViewerPlanes;
    }
}
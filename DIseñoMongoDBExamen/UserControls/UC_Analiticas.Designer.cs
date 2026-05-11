namespace DIseñoMongoDBExamen.UserControls
{
    partial class UC_Analiticas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvAnalisis = new DataGridView();
            btnExportarExcel = new Button();
            btnExportarPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAnalisis).BeginInit();
            SuspendLayout();
            // 
            // dgvAnalisis
            // 
            dgvAnalisis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnalisis.Location = new Point(78, 33);
            dgvAnalisis.Name = "dgvAnalisis";
            dgvAnalisis.Size = new Size(671, 291);
            dgvAnalisis.TabIndex = 0;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Location = new Point(154, 354);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(166, 70);
            btnExportarExcel.TabIndex = 1;
            btnExportarExcel.Text = "Exportar a Excel";
            btnExportarExcel.UseVisualStyleBackColor = true;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.Location = new Point(488, 354);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(166, 70);
            btnExportarPDF.TabIndex = 2;
            btnExportarPDF.Text = "Exportar a PDF";
            btnExportarPDF.UseVisualStyleBackColor = true;
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // UC_Analiticas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnExportarPDF);
            Controls.Add(btnExportarExcel);
            Controls.Add(dgvAnalisis);
            Name = "UC_Analiticas";
            Size = new Size(825, 444);
            ((System.ComponentModel.ISupportInitialize)dgvAnalisis).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvAnalisis;
        private Button btnExportarExcel;
        private Button btnExportarPDF;
    }
}

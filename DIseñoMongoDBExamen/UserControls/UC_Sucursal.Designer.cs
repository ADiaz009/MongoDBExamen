namespace DIseñoMongoDBExamen.UserControls
{
    partial class UC_Sucursal
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
            groupBox1 = new GroupBox();
            label5 = new Label();
            txtBuscar = new TextBox();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnAgregar = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtTelefono = new TextBox();
            txtRegion = new TextBox();
            txtUbicacion = new TextBox();
            txtNombreSucursal = new TextBox();
            dgvSucursal = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSucursal).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnLimpiar);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnEditar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(txtRegion);
            groupBox1.Controls.Add(txtUbicacion);
            groupBox1.Controls.Add(txtNombreSucursal);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(302, 418);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 227);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 13;
            label5.Text = "Buscar Sucursal:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(16, 264);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(264, 23);
            txtBuscar.TabIndex = 12;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(176, 371);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 37);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(26, 371);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 37);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(176, 316);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 38);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(26, 316);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 38);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 182);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 7;
            label4.Text = "Teléfono:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 134);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 6;
            label3.Text = "Región:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 88);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 5;
            label2.Text = "Ubicación:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 50);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 4;
            label1.Text = "Nombre de la Sucursal:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(151, 179);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(129, 23);
            txtTelefono.TabIndex = 3;
            // 
            // txtRegion
            // 
            txtRegion.Location = new Point(151, 131);
            txtRegion.Name = "txtRegion";
            txtRegion.Size = new Size(129, 23);
            txtRegion.TabIndex = 2;
            // 
            // txtUbicacion
            // 
            txtUbicacion.Location = new Point(151, 88);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.Size = new Size(129, 23);
            txtUbicacion.TabIndex = 1;
            // 
            // txtNombreSucursal
            // 
            txtNombreSucursal.Location = new Point(151, 47);
            txtNombreSucursal.Name = "txtNombreSucursal";
            txtNombreSucursal.Size = new Size(129, 23);
            txtNombreSucursal.TabIndex = 0;
            // 
            // dgvSucursal
            // 
            dgvSucursal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSucursal.Location = new Point(300, 0);
            dgvSucursal.Name = "dgvSucursal";
            dgvSucursal.Size = new Size(478, 415);
            dgvSucursal.TabIndex = 1;
            dgvSucursal.CellClick += dgvSucursales_CellClick;
            // 
            // UC_Sucursal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvSucursal);
            Controls.Add(groupBox1);
            Name = "UC_Sucursal";
            Size = new Size(778, 415);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSucursal).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtTelefono;
        private TextBox txtRegion;
        private TextBox txtUbicacion;
        private TextBox txtNombreSucursal;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnAgregar;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dgvSucursal;
        private Label label5;
        private TextBox txtBuscar;
    }
}

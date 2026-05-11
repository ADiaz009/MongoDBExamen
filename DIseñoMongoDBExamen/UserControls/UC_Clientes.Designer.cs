namespace DIseñoMongoDBExamen.UserControls
{
    partial class UC_Clientes
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
            txtNombre = new TextBox();
            txtApellidos = new TextBox();
            txtCorreo = new TextBox();
            txtBuscar = new TextBox();
            dgvClientes = new DataGridView();
            dgvHistorial = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLimpiar);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnEditar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(txtCorreo);
            groupBox1.Controls.Add(txtApellidos);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(270, 506);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(114, 32);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(135, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(114, 76);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(135, 23);
            txtApellidos.TabIndex = 1;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(114, 117);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(135, 23);
            txtCorreo.TabIndex = 2;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(23, 221);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(226, 23);
            txtBuscar.TabIndex = 3;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(296, 30);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(470, 214);
            dgvClientes.TabIndex = 1;
            // 
            // dgvHistorial
            // 
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(296, 286);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.Size = new Size(470, 198);
            dgvHistorial.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 35);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 4;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 79);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 5;
            label2.Text = "Apellido:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 120);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 6;
            label3.Text = "Correo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 172);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 7;
            label4.Text = "Buscar Cliente:";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(23, 298);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(226, 31);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(23, 357);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(226, 31);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(23, 408);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(226, 30);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(23, 457);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(226, 27);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // UC_Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvHistorial);
            Controls.Add(dgvClientes);
            Controls.Add(groupBox1);
            Name = "UC_Clientes";
            Size = new Size(792, 506);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtBuscar;
        private TextBox txtCorreo;
        private TextBox txtApellidos;
        private TextBox txtNombre;
        private DataGridView dgvClientes;
        private DataGridView dgvHistorial;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnAgregar;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}

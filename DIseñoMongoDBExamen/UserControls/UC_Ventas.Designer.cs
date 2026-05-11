namespace DIseñoMongoDBExamen.UserControls
{
    partial class UC_Ventas
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
            btnEliminar = new Button();
            btnEditar = new Button();
            btnAgregar = new Button();
            txtBuscarProd = new TextBox();
            numCantidad = new NumericUpDown();
            label3 = new Label();
            lstProductos = new ListBox();
            label2 = new Label();
            label1 = new Label();
            lstClientes = new ListBox();
            txtBuscarCliente = new TextBox();
            dgvCarrito = new DataGridView();
            btnFinalizar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnEditar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(txtBuscarProd);
            groupBox1.Controls.Add(numCantidad);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lstProductos);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lstClientes);
            groupBox1.Controls.Add(txtBuscarCliente);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(289, 463);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(198, 421);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 36);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(106, 421);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 36);
            btnEditar.TabIndex = 10;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(6, 421);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 36);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscarProd
            // 
            txtBuscarProd.Location = new Point(109, 224);
            txtBuscarProd.Name = "txtBuscarProd";
            txtBuscarProd.Size = new Size(149, 23);
            txtBuscarProd.TabIndex = 8;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(109, 378);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(149, 23);
            numCantidad.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 380);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 6;
            label3.Text = "Cantidad:";
            // 
            // lstProductos
            // 
            lstProductos.FormattingEnabled = true;
            lstProductos.ItemHeight = 15;
            lstProductos.Location = new Point(109, 266);
            lstProductos.Name = "lstProductos";
            lstProductos.Size = new Size(149, 94);
            lstProductos.TabIndex = 5;
            lstProductos.Click += lstProductos_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 227);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 3;
            label2.Text = "Productos:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 53);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 2;
            label1.Text = "Cliente: ";
            // 
            // lstClientes
            // 
            lstClientes.FormattingEnabled = true;
            lstClientes.ItemHeight = 15;
            lstClientes.Location = new Point(106, 96);
            lstClientes.Name = "lstClientes";
            lstClientes.Size = new Size(152, 94);
            lstClientes.TabIndex = 1;
            lstClientes.Click += lstClientes_Click;
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Location = new Point(106, 49);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.Size = new Size(152, 23);
            txtBuscarCliente.TabIndex = 0;
            // 
            // dgvCarrito
            // 
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(285, 0);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.Size = new Size(483, 411);
            dgvCarrito.TabIndex = 1;
            dgvCarrito.CellClick += dgvCarrito_CellClick;
            // 
            // btnFinalizar
            // 
            btnFinalizar.Location = new Point(500, 421);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(102, 39);
            btnFinalizar.TabIndex = 2;
            btnFinalizar.Text = "Finalizar";
            btnFinalizar.UseVisualStyleBackColor = true;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // UC_Ventas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnFinalizar);
            Controls.Add(dgvCarrito);
            Controls.Add(groupBox1);
            Name = "UC_Ventas";
            Size = new Size(768, 463);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private ListBox lstClientes;
        private TextBox txtBuscarCliente;
        private NumericUpDown numCantidad;
        private Label label3;
        private ListBox lstProductos;
        private TextBox txtBuscarProd;
        private DataGridView dgvCarrito;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnAgregar;
        private Button btnFinalizar;
    }
}

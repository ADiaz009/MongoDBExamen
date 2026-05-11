namespace DIseñoMongoDBExamen.UserControls
{
    partial class UC_Inventario
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
            txtNombreProd = new TextBox();
            groupBox1 = new GroupBox();
            btnLimpiar = new Button();
            label5 = new Label();
            btnEliminar = new Button();
            label4 = new Label();
            btnEditar = new Button();
            label3 = new Label();
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            txtCategoria = new TextBox();
            txtStock = new TextBox();
            txtPrecio = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dgvInventario = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            SuspendLayout();
            // 
            // txtNombreProd
            // 
            txtNombreProd.Location = new Point(137, 47);
            txtNombreProd.Name = "txtNombreProd";
            txtNombreProd.Size = new Size(137, 23);
            txtNombreProd.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLimpiar);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnEditar);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(txtCategoria);
            groupBox1.Controls.Add(txtStock);
            groupBox1.Controls.Add(txtPrecio);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNombreProd);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(298, 431);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Inventario";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(151, 402);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 271);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 9;
            label5.Text = "Buscador:";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(151, 351);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 221);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 8;
            label4.Text = "Categoría:";
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(46, 402);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 163);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 7;
            label3.Text = "Cantidad:";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(46, 351);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(15, 299);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(261, 23);
            txtBuscar.TabIndex = 6;
            // 
            // txtCategoria
            // 
            txtCategoria.Location = new Point(137, 215);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new Size(137, 23);
            txtCategoria.TabIndex = 5;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(137, 160);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(137, 23);
            txtStock.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(137, 100);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(137, 23);
            txtPrecio.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 96);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 2;
            label2.Text = "Precio";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 50);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre del Producto:";
            // 
            // dgvInventario
            // 
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Location = new Point(298, 0);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.Size = new Size(474, 431);
            dgvInventario.TabIndex = 2;
            dgvInventario.CellClick += dgvInventario_CellClick;
            // 
            // UC_Inventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvInventario);
            Controls.Add(groupBox1);
            Name = "UC_Inventario";
            Size = new Size(772, 431);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNombreProd;
        private GroupBox groupBox1;
        private TextBox txtStock;
        private TextBox txtPrecio;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtBuscar;
        private TextBox txtCategoria;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private DataGridView dgvInventario;
    }
}

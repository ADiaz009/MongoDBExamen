namespace DIseñoMongoDBExamen.UserControls
{
    partial class UC_Promociones
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
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            cmbCategoria = new ComboBox();
            dtpFin = new DateTimePicker();
            dtpInicio = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            chkActiva = new CheckBox();
            txtDescuento = new TextBox();
            txtDescripcion = new TextBox();
            txtNombre = new TextBox();
            dgvPromociones = new DataGridView();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPromociones).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbCategoria);
            groupBox1.Controls.Add(dtpFin);
            groupBox1.Controls.Add(dtpInicio);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(chkActiva);
            groupBox1.Controls.Add(txtDescuento);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(283, 495);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 354);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 12;
            label6.Text = "Fecha Final:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 254);
            label5.Name = "label5";
            label5.Size = new Size(89, 15);
            label5.TabIndex = 11;
            label5.Text = "Fecha de Inicio:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 223);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 10;
            label4.Text = "Categorias:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(117, 220);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(121, 23);
            cmbCategoria.TabIndex = 9;
            // 
            // dtpFin
            // 
            dtpFin.Location = new Point(21, 407);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(217, 23);
            dtpFin.TabIndex = 8;
            // 
            // dtpInicio
            // 
            dtpInicio.Location = new Point(21, 297);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(217, 23);
            dtpInicio.TabIndex = 7;
            dtpInicio.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 180);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 6;
            label3.Text = "Descuento:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 101);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 5;
            label2.Text = "Descripción:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 61);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 4;
            label1.Text = "Nombre:";
            // 
            // chkActiva
            // 
            chkActiva.AutoSize = true;
            chkActiva.Location = new Point(100, 457);
            chkActiva.Name = "chkActiva";
            chkActiva.Size = new Size(59, 19);
            chkActiva.TabIndex = 3;
            chkActiva.Text = "Activa";
            chkActiva.UseVisualStyleBackColor = true;
            // 
            // txtDescuento
            // 
            txtDescuento.Location = new Point(117, 177);
            txtDescuento.Name = "txtDescuento";
            txtDescuento.Size = new Size(125, 23);
            txtDescuento.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(117, 98);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(125, 59);
            txtDescripcion.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(117, 58);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 23);
            txtNombre.TabIndex = 0;
            // 
            // dgvPromociones
            // 
            dgvPromociones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPromociones.Location = new Point(281, 0);
            dgvPromociones.Name = "dgvPromociones";
            dgvPromociones.Size = new Size(523, 443);
            dgvPromociones.TabIndex = 1;
            dgvPromociones.CellClick += dgvPromociones_CellClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(321, 457);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 35);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click_1;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(446, 457);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 35);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(560, 457);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 35);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(684, 457);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 35);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // UC_Promociones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvPromociones);
            Controls.Add(groupBox1);
            Name = "UC_Promociones";
            Size = new Size(804, 495);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPromociones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckBox chkActiva;
        private TextBox txtDescuento;
        private TextBox txtDescripcion;
        private TextBox txtNombre;
        private DataGridView dgvPromociones;
        private ComboBox cmbCategoria;
        private DateTimePicker dtpFin;
        private DateTimePicker dtpInicio;
        private Label label4;
        private Label label6;
        private Label label5;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
    }
}

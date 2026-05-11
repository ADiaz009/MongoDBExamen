namespace DIseñoMongoDBExamen.UserControls
{
    partial class UC_Usuarios
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
            txtBuscar = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            cmbRol = new ComboBox();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            txtApellido = new TextBox();
            label2 = new Label();
            txtNombre = new TextBox();
            label1 = new Label();
            dgvUsuarios = new DataGridView();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmbRol);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUserName);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(296, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gestión de Usuarios";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(23, 375);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(254, 23);
            txtBuscar.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 335);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 10;
            label6.Text = "Buscador:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 288);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 9;
            label5.Text = "Rol:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 232);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 8;
            label4.Text = "Contraseña:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 174);
            label3.Name = "label3";
            label3.Size = new Size(113, 15);
            label3.TabIndex = 7;
            label3.Text = "Nombre de Usuario:";
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "CEO", "Administrador", "Tecnico", "Vendedor", "Analista" });
            cmbRol.Location = new Point(114, 285);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(163, 23);
            cmbRol.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(114, 229);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(163, 23);
            txtPassword.TabIndex = 5;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(148, 171);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(129, 23);
            txtUserName.TabIndex = 4;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(114, 104);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(163, 23);
            txtApellido.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 107);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Apellido:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(114, 39);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(163, 23);
            txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 42);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(296, 0);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(526, 350);
            dgvUsuarios.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(337, 377);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 36);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(457, 377);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 36);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(575, 377);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 36);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(698, 377);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 36);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // UC_Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvUsuarios);
            Controls.Add(groupBox1);
            Name = "UC_Usuarios";
            Size = new Size(822, 426);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtNombre;
        private Label label1;
        private DataGridView dgvUsuarios;
        private TextBox txtApellido;
        private Label label2;
        private ComboBox cmbRol;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private TextBox txtBuscar;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
    }
}

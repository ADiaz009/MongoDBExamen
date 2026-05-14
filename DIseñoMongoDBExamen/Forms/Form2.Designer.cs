namespace DIseñoMongoDBExamen.Forms
{
    partial class Form2
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
            pnlSidebar = new Panel();
            btnPromociones = new Button();
            btnSucursal = new Button();
            btnCerrarSesion = new Button();
            btnGestionUsuarios = new Button();
            btnEstadisticas = new Button();
            btnClientes = new Button();
            btnVentas = new Button();
            btnInventario = new Button();
            pnlHeader = new Panel();
            label1 = new Label();
            cmbSucursalGlobal = new ComboBox();
            lblSucursal = new Label();
            lblRol = new Label();
            lblUsuario = new Label();
            button5 = new Button();
            pnlContenedor = new Panel();
            pnlSidebar.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(26, 35, 126);
            pnlSidebar.Controls.Add(btnPromociones);
            pnlSidebar.Controls.Add(btnSucursal);
            pnlSidebar.Controls.Add(btnCerrarSesion);
            pnlSidebar.Controls.Add(btnGestionUsuarios);
            pnlSidebar.Controls.Add(btnEstadisticas);
            pnlSidebar.Controls.Add(btnClientes);
            pnlSidebar.Controls.Add(btnVentas);
            pnlSidebar.Controls.Add(btnInventario);
            pnlSidebar.Location = new Point(0, -1);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(247, 689);
            pnlSidebar.TabIndex = 0;
            // 
            // btnPromociones
            // 
            btnPromociones.Location = new Point(12, 461);
            btnPromociones.Name = "btnPromociones";
            btnPromociones.Size = new Size(211, 63);
            btnPromociones.TabIndex = 6;
            btnPromociones.Text = "Promociones";
            btnPromociones.UseVisualStyleBackColor = true;
            btnPromociones.Click += btnPromociones_Click;
            // 
            // btnSucursal
            // 
            btnSucursal.Location = new Point(12, 26);
            btnSucursal.Name = "btnSucursal";
            btnSucursal.Size = new Size(211, 63);
            btnSucursal.TabIndex = 4;
            btnSucursal.Text = "Sucursales";
            btnSucursal.UseVisualStyleBackColor = true;
            btnSucursal.Click += btnSucursal_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(12, 632);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(211, 34);
            btnCerrarSesion.TabIndex = 5;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.Location = new Point(12, 547);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Size = new Size(211, 63);
            btnGestionUsuarios.TabIndex = 4;
            btnGestionUsuarios.Text = "Gestión de Usuarios";
            btnGestionUsuarios.UseVisualStyleBackColor = true;
            btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            // 
            // btnEstadisticas
            // 
            btnEstadisticas.Location = new Point(12, 374);
            btnEstadisticas.Name = "btnEstadisticas";
            btnEstadisticas.Size = new Size(211, 63);
            btnEstadisticas.TabIndex = 3;
            btnEstadisticas.Text = "Analíticas";
            btnEstadisticas.UseVisualStyleBackColor = true;
            btnEstadisticas.Click += btnEstadisticas_Click;
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(12, 284);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(211, 63);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnVentas
            // 
            btnVentas.Location = new Point(12, 195);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(211, 63);
            btnVentas.TabIndex = 1;
            btnVentas.Text = "Ventas";
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnInventario
            // 
            btnInventario.Location = new Point(12, 109);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(211, 63);
            btnInventario.TabIndex = 0;
            btnInventario.Text = "Inventario";
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += btnInventario_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(label1);
            pnlHeader.Controls.Add(cmbSucursalGlobal);
            pnlHeader.Controls.Add(lblSucursal);
            pnlHeader.Controls.Add(lblRol);
            pnlHeader.Controls.Add(lblUsuario);
            pnlHeader.Location = new Point(245, -1);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(777, 115);
            pnlHeader.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(490, 51);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 4;
            label1.Text = "Cambio de Sucursal";
            // 
            // cmbSucursalGlobal
            // 
            cmbSucursalGlobal.FormattingEnabled = true;
            cmbSucursalGlobal.Location = new Point(608, 47);
            cmbSucursalGlobal.Name = "cmbSucursalGlobal";
            cmbSucursalGlobal.Size = new Size(121, 23);
            cmbSucursalGlobal.TabIndex = 3;
            // 
            // lblSucursal
            // 
            lblSucursal.AutoSize = true;
            lblSucursal.Location = new Point(356, 51);
            lblSucursal.Name = "lblSucursal";
            lblSucursal.Size = new Size(38, 15);
            lblSucursal.TabIndex = 2;
            lblSucursal.Text = "label3";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(221, 50);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(38, 15);
            lblRol.TabIndex = 1;
            lblRol.Text = "label2";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(86, 50);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(38, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "label1";
            // 
            // button5
            // 
            button5.Location = new Point(406, 258);
            button5.Name = "button5";
            button5.Size = new Size(211, 63);
            button5.TabIndex = 2;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            // 
            // pnlContenedor
            // 
            pnlContenedor.Location = new Point(245, 111);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Size = new Size(777, 577);
            pnlContenedor.TabIndex = 3;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 688);
            Controls.Add(pnlContenedor);
            Controls.Add(button5);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            Name = "Form2";
            Text = "Form2";
            Load += FormMenu_Load;
            pnlSidebar.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlHeader;
        private Button btnEstadisticas;
        private Button btnClientes;
        private Button btnVentas;
        private Button btnInventario;
        private Button button5;
        private Button btnGestionUsuarios;
        private Button btnCerrarSesion;
        private Button btnSucursal;
        private Panel pnlContenedor;
        private Label lblSucursal;
        private Label lblRol;
        private Label lblUsuario;
        private Button btnPromociones;
        private Label label1;
        private ComboBox cmbSucursalGlobal;
    }
}
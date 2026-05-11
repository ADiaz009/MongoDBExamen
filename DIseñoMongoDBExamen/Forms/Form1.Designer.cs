namespace DIseñoMongoDBExamen
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            txtContraseña = new TextBox();
            txtNombreUsuario = new TextBox();
            label3 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(txtContraseña);
            groupBox1.Controls.Add(txtNombreUsuario);
            groupBox1.Location = new Point(1, 64);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(343, 265);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 107);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 4;
            label2.Text = "Contraseña:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 43);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 3;
            label1.Text = "Nombre de Usuario:";
            // 
            // button1
            // 
            button1.Location = new Point(119, 191);
            button1.Name = "button1";
            button1.Size = new Size(103, 55);
            button1.TabIndex = 2;
            button1.Text = "Iniciar Sesión";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(144, 104);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(173, 23);
            txtContraseña.TabIndex = 1;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(144, 40);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(173, 23);
            txtNombreUsuario.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(75, 19);
            label3.Name = "label3";
            label3.Size = new Size(204, 26);
            label3.TabIndex = 1;
            label3.Text = "Sistema Comercial";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 35, 126);
            ClientSize = new Size(346, 378);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Button button1;
        private TextBox txtContraseña;
        private TextBox txtNombreUsuario;
        private Label label3;
    }
}

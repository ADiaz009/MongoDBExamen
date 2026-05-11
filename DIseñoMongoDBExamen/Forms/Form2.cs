using DIseñoMongoDBExamen.Models;
using DIseñoMongoDBExamen.Services;
using DIseñoMongoDBExamen.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIseñoMongoDBExamen.Forms
{
    public partial class Form2 : Form
    {
        private readonly DataService _service = new DataService();
        public Form2()
        {
            InitializeComponent();
            pnlHeader.BackColor = Color.FromArgb(245, 245, 245); // Gris claro
            pnlContenedor.BackColor = Color.White;
            
        }

        private async void FormMenu_Load(object sender, EventArgs e)
        {
            // 1. Seteamos tus 3 labels con la info de la sesión
            lblUsuario.Text = $"Usuario: {UserSession.Nombre}";
            lblRol.Text = $"Rol: {UserSession.Rol}";
            lblSucursal.Text = $"Sucursal: {UserSession.SucursalNombre}";

            // 2. Aplicar la lógica de acceso restringido
            AplicarSeguridad();

            // 3. Manejo del ComboBox y Sucursal para el CEO
            await ConfigurarComboSucursales();
        }

        private void AplicarSeguridad()
        {
            string rol = UserSession.Rol;

            // - Promociones y Ventas: Vendedor, Administrador y CEO
            bool accesoVentas = (rol == "Vendedor" || rol == "Administrador" || rol == "CEO");
            btnVentas.Visible = accesoVentas;
            btnPromociones.Visible = accesoVentas;

            // - Gestionar Usuarios: Tecnico, Administrador y CEO
            btnGestionUsuarios.Visible = (rol == "Tecnico" || rol == "Administrador" || rol == "CEO");

            // - Analíticas: Analistas, Administrador y CEO
            btnEstadisticas.Visible = (rol == "Analista" || rol == "Administrador" || rol == "CEO");

            // - Apartado de Sucursales (Botón) y ComboBox: Solo el CEO
            btnSucursal.Visible = (rol == "CEO");
            cmbSucursalGlobal.Visible = (rol == "CEO");
        }

        private async Task ConfigurarComboSucursales()
        {
            if (UserSession.Rol == "CEO")
            {
                try
                {
                    var lista = await _service.GetAllAsync<Sucursal>("Sucursal");
                    cmbSucursalGlobal.DataSource = lista;
                    cmbSucursalGlobal.DisplayMember = "Nombre";
                    cmbSucursalGlobal.ValueMember = "Id";

                    // Seteamos el combo en la sucursal actual del CEO
                    cmbSucursalGlobal.SelectedValue = UserSession.SucursalId;

                    // Evento para cambiar de sucursal
                    cmbSucursalGlobal.SelectedIndexChanged += (s, e) =>
                    {
                        if (cmbSucursalGlobal.SelectedItem is Sucursal suc)
                        {
                            // Actualizamos la sesión global
                            UserSession.SucursalId = suc.Id;
                            UserSession.SucursalNombre = suc.Nombre;

                            // ACTUALIZAMOS TU LABEL DE SUCURSAL AL INSTANTE
                            lblSucursal.Text = $"Sucursal: {UserSession.SucursalNombre}";

                            // Si hay analíticas abiertas, se refrescan para la nueva sucursal
                            if (pnlContenedor.Controls.Count > 0 && pnlContenedor.Controls[0] is UC_Analiticas uc)
                                uc.CargarAnalisisGerencial();
                        }
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar sucursales para CEO: " + ex.Message);
                }
            }
        }

        // --- NAVEGACIÓN ---
        private void AbrirModulo(UserControl uc)
        {
            pnlContenedor.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(uc);
        }

        
       
        
        
        

        private void btnSucursal_Click(object sender, EventArgs e)
        {
            AbrirModulo(new UC_Sucursal());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirModulo(new UC_Inventario());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirModulo(new UC_Ventas());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirModulo(new UC_Clientes());
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            AbrirModulo(new UC_Analiticas());
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            AbrirModulo(new UC_Usuarios());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la sesión actual?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                // Aquí llamás a tu Form de Login
                // FormLogin login = new FormLogin();
                // login.Show();
                this.Close();
            }
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            AbrirModulo(new UC_Promociones());
        }
    }
}

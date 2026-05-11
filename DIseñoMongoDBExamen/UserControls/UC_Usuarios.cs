using DIseñoMongoDBExamen.Models;
using DIseñoMongoDBExamen.Services;
using System.Data;

namespace DIseñoMongoDBExamen.UserControls
{
    public partial class UC_Usuarios : UserControl
    {
        private DataService _service = new DataService();
        private List<Usuario> listaUsuarios = new List<Usuario>();
        private Guid? idSeleccionado = null;

        public UC_Usuarios()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarDatos();
        }

        private void ConfigurarGrid()
        {
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public async void CargarDatos()
        {
            var todos = await _service.GetAllAsync<Usuario>("Usuario");

            if (GlobalConfig.SucursalSeleccionadaId != null && GlobalConfig.SucursalSeleccionadaId != Guid.Empty)
            {
                // Filtramos por la sucursal que manda en el menú global
                listaUsuarios = todos.Where(u => u.SucursalId == GlobalConfig.SucursalSeleccionadaId).ToList();
            }
            else
            {
                // Si no hay sucursal seleccionada (ej. al arrancar), podrías mostrar todo o nada
                listaUsuarios = todos;
            }

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = listaUsuarios;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string b = txtBuscar.Text.ToLower();
            var filtrados = listaUsuarios
                .Where(u => u.Nombre.ToLower().Contains(b) || u.NombreUsuario.ToLower().Contains(b))
                .ToList();

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = filtrados;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var user = (Usuario)dgvUsuarios.Rows[e.RowIndex].DataBoundItem;

            idSeleccionado = user.Id;
            // Usamos tus nombres de propiedad: Nombre, Apellidos, NombreUsuario
            txtNombre.Text = user.Nombre;
            txtApellido.Text = user.Apellidos;
            txtUserName.Text = user.NombreUsuario;
            txtPassword.Text = user.Password;
            cmbRol.SelectedItem = user.Rol;

            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || cmbRol.SelectedIndex == -1) return;

            var nuevo = new Usuario
            {
                Id = Guid.NewGuid(),
                Nombre = txtNombre.Text,
                Apellidos = txtApellido.Text,
                NombreUsuario = txtUserName.Text,
                Password = txtPassword.Text,
                Rol = cmbRol.Text,
                SucursalId = GlobalConfig.SucursalSeleccionadaId ?? Guid.Empty
            };

            if (await _service.CreateAsync("Usuario", nuevo))
            {
                MessageBox.Show("Registrado.");
                LimpiarTodo();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null) return;

            var modificado = new Usuario
            {
                Id = idSeleccionado.Value,
                Nombre = txtNombre.Text,
                Apellidos = txtApellido.Text,
                NombreUsuario = txtUserName.Text,
                Password = txtPassword.Text,
                Rol = cmbRol.Text,
                SucursalId = GlobalConfig.SucursalSeleccionadaId ?? Guid.Empty
            };

            if (await _service.UpdateAsync("Usuario", idSeleccionado.Value, modificado))
            {
                MessageBox.Show("Actualizado.");
                LimpiarTodo();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null) return;

            if (MessageBox.Show("¿Borrar?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (await _service.DeleteAsync("Usuario", idSeleccionado.Value))
                {
                    LimpiarTodo();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarTodo();

        private void LimpiarTodo()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtBuscar.Clear();
            cmbRol.SelectedIndex = -1;
            idSeleccionado = null;
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            CargarDatos();
        }
    }
}
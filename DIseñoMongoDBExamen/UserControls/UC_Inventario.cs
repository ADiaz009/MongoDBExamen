using DIseñoMongoDBExamen.Models;
using DIseñoMongoDBExamen.Services;
using System.Data;

namespace DIseñoMongoDBExamen.UserControls
{
    public partial class UC_Inventario : UserControl
    {
        private DataService _service = new DataService();
        private List<Inventario> listaCompleta = new List<Inventario>();
        private Guid? idSeleccionado = null;

        public UC_Inventario()
        {
            InitializeComponent();
            CargarDatos();
            // Configuración básica del DataGridView
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.MultiSelect = false;
            dgvInventario.ReadOnly = true;
        }

        private async void CargarDatos()
        {
            var todos = await _service.GetAllAsync<Inventario>("Inventario");

            // FILTRO DINÁMICO:
            listaCompleta = todos.Where(p => p.SucursalId == GlobalConfig.SucursalSeleccionadaId).ToList();
            dgvInventario.DataSource = null;
            dgvInventario.DataSource = listaCompleta;
        }

        // --- BUSCADOR DINÁMICO (Escribís y se filtra el Grid) ---
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string b = txtBuscar.Text.ToLower();
            var filtrados = listaCompleta
                .Where(p => p.NombreProducto.ToLower().Contains(b) ||
                            p.Categoria.ToLower().Contains(b))
                .ToList();

            dgvInventario.DataSource = null;
            dgvInventario.DataSource = filtrados;
        }

        // --- CLIC EN GRID: RELLENA LOS TEXTBOX ---
        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var producto = (Inventario)dgvInventario.Rows[e.RowIndex].DataBoundItem;

            idSeleccionado = producto.Id;
            txtNombreProd.Text = producto.NombreProducto;
            txtPrecio.Text = producto.Precio.ToString();
            txtStock.Text = producto.Stock.ToString();
            txtCategoria.Text = producto.Categoria;

            // Lógica de botones: No podés "Guardar" uno que ya existe, solo "Editar"
            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;
        }

        // --- BOTÓN GUARDAR (Para nuevos) ---
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreProd.Text)) return;

            var nuevo = new Inventario
            {
                Id = Guid.NewGuid(),
                NombreProducto = txtNombreProd.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Categoria = txtCategoria.Text
            };

            if (await _service.CreateAsync("Inventario", nuevo))
            {
                MessageBox.Show("Producto registrado.");
                LimpiarInterfaz();
                CargarDatos();
            }
        }

        // --- BOTÓN EDITAR (Para cambios) ---
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null) return;

            var modificado = new Inventario
            {
                Id = idSeleccionado.Value,
                NombreProducto = txtNombreProd.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Categoria = txtCategoria.Text
            };

            if (await _service.UpdateAsync("Inventario", idSeleccionado.Value, modificado))
            {
                MessageBox.Show("Producto actualizado.");
                LimpiarInterfaz();
                CargarDatos();
            }
        }

        // --- BOTÓN ELIMINAR ---
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null) return;

            if (MessageBox.Show("¿Seguro de borrarlo?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (await _service.DeleteAsync("Inventario", idSeleccionado.Value))
                {
                    LimpiarInterfaz();
                    CargarDatos();
                }
            }
        }

        // --- BOTÓN LIMPIAR ---
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarInterfaz();
        }

        // Método centralizado para vaciar todo
        private void LimpiarInterfaz()
        {
            txtNombreProd.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtCategoria.Clear();
            txtBuscar.Clear();

            idSeleccionado = null;

            // Reset de botones
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;

            // Forzar que el grid vuelva a mostrar todo si estaba filtrado
            dgvInventario.DataSource = null;
            dgvInventario.DataSource = listaCompleta;
        }
    }
}
using DIseñoMongoDBExamen.Models;
using DIseñoMongoDBExamen.Services;
using System.Data;

namespace DIseñoMongoDBExamen.UserControls
{
    public partial class UC_Ventas : UserControl
    {
        private readonly DataService _service = new DataService();

        private List<ItemCompra> carrito = new();
        private List<Cliente> listaClientes = new();
        private List<Inventario> listaProductos = new();

        private Cliente? clienteSeleccionado = null;
        private Inventario? productoSeleccionado = null;

        private int? indexEdicion = null;

        public UC_Ventas()
        {
            InitializeComponent();

            lstClientes.Visible = false;
            lstProductos.Visible = false;

            btnEditar.Enabled = false;

            dgvCarrito.AutoGenerateColumns = true;

            CargarCatalogos();
        }

        // =====================================================
        // CARGAR CATÁLOGOS
        // =====================================================

        private async void CargarCatalogos()
        {
            try
            {
                
                // CLIENTES
                listaClientes =
                    await _service.GetAllAsync<Cliente>("Cliente");

                // PRODUCTOS
                var todosProductos =
                    await _service.GetAllAsync<Inventario>("Inventario");

                // FILTRAR POR SUCURSAL
                listaProductos = todosProductos
                    .Where(p =>
                        p.SucursalId ==
                        GlobalConfig.SucursalSeleccionadaId)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error cargando datos:\n{ex.Message}"
                );
            }
        }

        // =====================================================
        // BUSCADOR CLIENTES
        // =====================================================

        private void txtBuscarCliente_TextChanged(
    object sender,
    EventArgs e)
        {
            string busqueda =
                txtBuscarCliente.Text.Trim().ToLower();

            lstClientes.Items.Clear();

            if (string.IsNullOrWhiteSpace(busqueda))
            {
                lstClientes.Visible = false;
                return;
            }

            var filtrados = listaClientes
                .Where(c =>
                    c.Nombre.ToLower()
                    .Contains(busqueda))
                .ToList();

            foreach (var cliente in filtrados)
            {
                lstClientes.Items.Add(cliente.Nombre);
            }

            lstClientes.Visible = filtrados.Any();

            lstClientes.BringToFront();
        }

        private void lstClientes_Click(
     object sender,
     EventArgs e)
        {
            if (lstClientes.SelectedItem != null)
            {
                string nombreSeleccionado =
                    lstClientes.SelectedItem.ToString();

                clienteSeleccionado =
                    listaClientes.FirstOrDefault(
                        c => c.Nombre == nombreSeleccionado);

                txtBuscarCliente.Text =
                    nombreSeleccionado;

                lstClientes.Visible = false;
            }
        }

        // =====================================================
        // BUSCADOR PRODUCTOS
        // =====================================================

        private void txtBuscarProd_TextChanged(
            object sender,
            EventArgs e)
        {
            string busqueda =
                txtBuscarProd.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(busqueda))
            {
                lstProductos.Visible = false;
                return;
            }

            var filtrados = listaProductos
                .Where(p =>
                    p.NombreProducto.ToLower()
                    .Contains(busqueda))
                .ToList();

            lstProductos.DataSource = null;
            lstProductos.DataSource = filtrados;

            lstProductos.DisplayMember =
                "NombreProducto";

            lstProductos.Visible =
                filtrados.Any();

            if (lstProductos.Visible)
                lstProductos.BringToFront();
        }

        private void lstProductos_Click(
            object sender,
            EventArgs e)
        {
            if (lstProductos.SelectedItem is Inventario prod)
            {
                productoSeleccionado = prod;

                txtBuscarProd.Text =
                    prod.NombreProducto;

                lstProductos.Visible = false;
            }
        }

        // =====================================================
        // AGREGAR PRODUCTO
        // =====================================================

        private void btnAgregar_Click(
            object sender,
            EventArgs e)
        {
            if (productoSeleccionado == null)
            {
                MessageBox.Show(
                    "Seleccioná un producto."
                );

                return;
            }

            int cantidad =
                (int)numCantidad.Value;

            // VALIDAR STOCK
            if (cantidad > productoSeleccionado.Stock)
            {
                MessageBox.Show(
                    "No hay suficiente stock."
                );

                return;
            }

            var item = new ItemCompra
            {
                ProductoId =
                    productoSeleccionado.Id,

                ProductoNombre =
                    productoSeleccionado.NombreProducto,

                Cantidad = cantidad,

                PrecioUnitario =
                    productoSeleccionado.Precio
            };

            carrito.Add(item);

            ActualizarGrid();
        }

        // =====================================================
        // CLICK GRID
        // =====================================================

        private void dgvCarrito_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            indexEdicion = e.RowIndex;

            var item =
                carrito[e.RowIndex];

            productoSeleccionado =
                listaProductos.FirstOrDefault(
                    p => p.Id == item.ProductoId);

            txtBuscarProd.Text =
                item.ProductoNombre;

            numCantidad.Value =
                item.Cantidad;

            btnAgregar.Enabled = false;

            btnEditar.Enabled = true;
        }

        // =====================================================
        // EDITAR
        // =====================================================

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            if (indexEdicion == null)
                return;

            carrito[indexEdicion.Value].Cantidad =
                (int)numCantidad.Value;

            ActualizarGrid();
        }

        // =====================================================
        // ELIMINAR
        // =====================================================

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            if (dgvCarrito.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná una fila."
                );

                return;
            }

            carrito.RemoveAt(
                dgvCarrito.CurrentRow.Index);

            ActualizarGrid();
        }

        // =====================================================
        // ACTUALIZAR GRID
        // =====================================================

        private void ActualizarGrid()
        {
            dgvCarrito.DataSource = null;

            dgvCarrito.AutoGenerateColumns = true;

            dgvCarrito.DataSource = carrito;

            LimpiarProducto();
        }

        // =====================================================
        // LIMPIAR PRODUCTO
        // =====================================================

        private void LimpiarProducto()
        {
            txtBuscarProd.Clear();

            numCantidad.Value = 1;

            productoSeleccionado = null;

            btnAgregar.Enabled = true;

            btnEditar.Enabled = false;

            indexEdicion = null;
        }

        // =====================================================
        // FINALIZAR VENTA
        // =====================================================

        private async void btnFinalizar_Click(
            object sender,
            EventArgs e)
        {
            // VALIDAR CLIENTE
            if (clienteSeleccionado == null)
            {
                MessageBox.Show(
                    "Seleccioná un cliente."
                );

                return;
            }

            // VALIDAR CARRITO
            if (!carrito.Any())
            {
                MessageBox.Show(
                    "El carrito está vacío."
                );

                return;
            }

            try
            {
                // PROMOCIONES
                var promociones =
                    await _service
                    .GetAllAsync<Promocion>(
                        "Promocion");

                DateTime hoy = DateTime.Now;

                var promo =
                    promociones
                    .Where(p =>
                        p.Activa &&
                        hoy >= p.FechaInicio &&
                        hoy <= p.FechaFin)
                    .OrderByDescending(
                        p => p.PorcentajeDescuento)
                    .FirstOrDefault();

                decimal descuento =
                    promo?.PorcentajeDescuento ?? 0;

                // CÁLCULOS
                decimal subtotal =
                    carrito.Sum(x =>
                        x.Cantidad *
                        x.PrecioUnitario);

                decimal montoDescuento =
                    subtotal *
                    (descuento / 100);

                decimal subtotalNeto =
                    subtotal - montoDescuento;

                decimal iva =
                    subtotalNeto * 0.15m;

                decimal total =
                    subtotalNeto + iva;

                // CREAR VENTA
                var venta = new Compra
                {
                    Id = Guid.NewGuid(),

                    ClienteId =
                        clienteSeleccionado.Id,

                    SucursalId =
                        GlobalConfig
                        .SucursalSeleccionadaId
                        ?? Guid.Empty,

                    Fecha = DateTime.Now,

                    Items =
                        new List<ItemCompra>(carrito),

                    Subtotal = subtotal,

                    Iva = iva,

                    Total = total
                };

                // GUARDAR VENTA
                bool ok =
                    await _service.CreateAsync(
                        "Compra",
                        venta);

                if (!ok)
                {
                    MessageBox.Show(
                        "No se pudo guardar la venta."
                    );

                    return;
                }

                // DESCONTAR STOCK
                foreach (var item in carrito)
                {
                    var producto =
                        listaProductos.FirstOrDefault(
                            p => p.Id == item.ProductoId);

                    if (producto != null)
                    {
                        producto.Stock -=
                            item.Cantidad;

                        await _service.UpdateAsync(
                            "Inventario",
                            producto.Id,
                            producto);
                    }
                }

                // MENSAJE FINAL
                MessageBox.Show(
                    $"Venta realizada.\n\n" +
                    $"Subtotal: C$ {subtotal:N2}\n" +
                    $"Descuento: C$ {montoDescuento:N2}\n" +
                    $"IVA: C$ {iva:N2}\n" +
                    $"Total: C$ {total:N2}"
                );

                // LIMPIAR TODO
                carrito.Clear();

                dgvCarrito.DataSource = null;

                txtBuscarCliente.Clear();

                clienteSeleccionado = null;

                LimpiarProducto();

                CargarCatalogos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error:\n{ex.Message}"
                );
            }
        }
    }
}
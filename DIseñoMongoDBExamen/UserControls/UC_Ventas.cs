using DIseñoMongoDBExamen.Models;
using DIseñoMongoDBExamen.Services;
using System.Data;

namespace DIseñoMongoDBExamen.UserControls
{
        public partial class UC_Ventas : UserControl
        {
            private DataService _service = new DataService();
            private List<ItemCompra> carrito = new List<ItemCompra>();
            private List<Cliente> listaClientes = new List<Cliente>();
            private List<Inventario> listaProductos = new List<Inventario>();

            private Cliente clienteSeleccionado = null;
            private Inventario productoSeleccionado = null;
            private int? indexEdicion = null;

            public UC_Ventas()
            {
                InitializeComponent();
                lstClientes.Visible = false;
                lstProductos.Visible = false;
                btnEditar.Enabled = false;
                CargarCatalogos();
            }

            private async void CargarCatalogos()
            {
                listaClientes = await _service.GetAllAsync<Cliente>("Cliente");
                listaProductos = await _service.GetAllAsync<Inventario>("Inventario");
            }

            // --- BUSCADOR DE CLIENTES ---
            private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
            {
                string b = txtBuscarCliente.Text.ToLower();
                var filtrados = listaClientes.Where(c => c.Nombre.ToLower().Contains(b)).ToList();
                lstClientes.DataSource = filtrados;
                lstClientes.DisplayMember = "Nombre";
                lstClientes.Visible = filtrados.Any() && !string.IsNullOrEmpty(b);
                if (lstClientes.Visible) lstClientes.BringToFront();
            }

            private void lstClientes_Click(object sender, EventArgs e)
            {
                if (lstClientes.SelectedItem is Cliente c)
                {
                    clienteSeleccionado = c;
                    txtBuscarCliente.Text = c.Nombre;
                    lstClientes.Visible = false;
                }
            }

            // --- BUSCADOR DE PRODUCTOS ---
            private void txtBuscarProd_TextChanged(object sender, EventArgs e)
            {
                string b = txtBuscarProd.Text.ToLower();
                var filtrados = listaProductos.Where(p => p.NombreProducto.ToLower().Contains(b)).ToList();
                lstProductos.DataSource = filtrados;
                lstProductos.DisplayMember = "NombreProducto";
                lstProductos.Visible = filtrados.Any() && !string.IsNullOrEmpty(b);
                if (lstProductos.Visible) lstProductos.BringToFront();
            }

            private void lstProductos_Click(object sender, EventArgs e)
            {
                if (lstProductos.SelectedItem is Inventario p)
                {
                    productoSeleccionado = p;
                    txtBuscarProd.Text = p.NombreProducto;
                    lstProductos.Visible = false;
                }
            }

            // --- ACCIONES DEL CARRITO ---

            private void btnAgregar_Click(object sender, EventArgs e)
            {
                if (productoSeleccionado == null) return;

                carrito.Add(new ItemCompra
                {
                    ProductoId = productoSeleccionado.Id,
                    ProductoNombre = productoSeleccionado.NombreProducto,
                    Cantidad = (int)numCantidad.Value,
                    PrecioUnitario = productoSeleccionado.Precio
                });

                ActualizarTodo();
            }

            private void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex < 0) return;

                indexEdicion = e.RowIndex;
                var item = carrito[e.RowIndex];
                productoSeleccionado = listaProductos.FirstOrDefault(p => p.Id == item.ProductoId);

                txtBuscarProd.Text = item.ProductoNombre;
                numCantidad.Value = item.Cantidad;

                btnAgregar.Enabled = false;
                btnEditar.Enabled = true;
            }

            private void btnEditar_Click(object sender, EventArgs e)
            {
                if (indexEdicion != null)
                {
                    carrito[indexEdicion.Value].Cantidad = (int)numCantidad.Value;
                    ActualizarTodo();
                }
            }

            private void btnEliminar_Click(object sender, EventArgs e)
            {
                if (dgvCarrito.CurrentRow != null)
                {
                    // Eliminamos de la lista usando el índice de la fila seleccionada
                    carrito.RemoveAt(dgvCarrito.CurrentRow.Index);
                    ActualizarTodo();
                }
                else
                {
                    MessageBox.Show("Seleccioná un producto del grid para volarlo.");
                }
            }

            // --- MÉTODOS DE APOYO ---

            private void ActualizarTodo()
            {
                dgvCarrito.DataSource = null;
                dgvCarrito.DataSource = carrito;
                LimpiarCamposProd();
            }

            private void LimpiarCamposProd()
            {
                txtBuscarProd.Clear();
                numCantidad.Value = 1;
                productoSeleccionado = null;
                btnAgregar.Enabled = true;
                btnEditar.Enabled = false;
                indexEdicion = null;
            }

            // --- FINALIZAR VENTA ---

            private async void btnFinalizar_Click(object sender, EventArgs e)
            {
            // 1. Validaciones iniciales
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("¡Ideay! Seleccioná un cliente primero.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agregá productos antes de facturar.", "Carrito vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // --- LÓGICA DE PROMOCIONES INTELIGENTE (REFORMADA) ---

                // Traemos las promociones de la base de datos
                var todasLasPromos = await _service.GetAllAsync<Promocion>("Promocion");
                DateTime ahora = DateTime.Now;

                // Buscamos la promo que cumpla: Activa, dentro de rango de fecha y para el nivel del cliente
                var promoVigente = todasLasPromos
                    .Where(p => p.Activa &&
                                ahora >= p.FechaInicio &&
                                ahora <= p.FechaFin &&
                                (p.CategoriaObjetivo == "Todas" || clienteSeleccionado.Nivel.Contains(p.CategoriaObjetivo.Split(' ')[0])))
                    .OrderByDescending(p => p.PorcentajeDescuento)
                    .FirstOrDefault();

                decimal porcentajePromo = promoVigente?.PorcentajeDescuento ?? 0;

                // Beneficio extra según el Nivel del Cliente (bono de fidelidad)
                decimal bonoFidelidad = 0;
                if (clienteSeleccionado.Nivel.Contains("Rubí")) bonoFidelidad = 10;
                else if (clienteSeleccionado.Nivel.Contains("Esmeralda")) bonoFidelidad = 7;
                else if (clienteSeleccionado.Nivel.Contains("Diamante")) bonoFidelidad = 5;
                else if (clienteSeleccionado.Nivel.Contains("Oro")) bonoFidelidad = 3;

                decimal descuentoTotalPorcentaje = porcentajePromo + bonoFidelidad;

                // --- CÁLCULOS FINANCIEROS ---

                // Suma de (Precio * Cantidad) de cada item en el carrito
                decimal subtotalOriginal = carrito.Sum(x => x.SubtotalItem);

                // Calculamos cuánto se le va a descontar
                decimal montoDescuento = subtotalOriginal * (descuentoTotalPorcentaje / 100);

                // El subtotal neto sobre el cual se aplica el IVA
                decimal subtotalConDescuento = subtotalOriginal - montoDescuento;

                // IVA del 15% (Nicaragua)
                decimal ivaCalculado = subtotalConDescuento * 0.15m;

                // Total final que paga el cliente
                decimal totalFinal = subtotalConDescuento + ivaCalculado;

                // --- CREACIÓN DEL OBJETO COMPRA ---
                var venta = new Compra
                {
                    Id = Guid.NewGuid(),
                    ClienteId = clienteSeleccionado.Id,
                    SucursalId = GlobalConfig.SucursalSeleccionadaId ?? Guid.Empty,
                    Fecha = DateTime.Now,
                    Items = new List<ItemCompra>(carrito),
                    Subtotal = subtotalOriginal, // Guardamos el valor bruto
                    IVA = ivaCalculado,
                    Total = totalFinal
                };

                // 2. Guardar en MongoDB a través de la API
                if (await _service.CreateAsync("Compra", venta))
                {
                    string resumen = $"Venta Exitosa\n\n" +
                                     $"Subtotal: C$ {subtotalOriginal:N2}\n" +
                                     $"Desc. Aplicado ({descuentoTotalPorcentaje}%): -C$ {montoDescuento:N2}\n" +
                                     $"IVA (15%): C$ {ivaCalculado:N2}\n" +
                                     $"TOTAL A PAGAR: C$ {totalFinal:N2}";

                    MessageBox.Show(resumen, "Facturación UNI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // --- 3. LIMPIEZA TOTAL ---
                    carrito.Clear();
                    dgvCarrito.DataSource = null;
                    txtBuscarCliente.Clear();
                    clienteSeleccionado = null;
                    LimpiarCamposProd();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la venta en la API. Revisá la conexión.", "Error 500 / Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }
    
}
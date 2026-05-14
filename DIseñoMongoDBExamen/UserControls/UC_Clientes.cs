using DIseñoMongoDBExamen.Models;
using DIseñoMongoDBExamen.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIseñoMongoDBExamen.UserControls
{
    public partial class UC_Clientes : UserControl
    {
        private DataService _service = new DataService();
        private List<Cliente> listaClientes = new List<Cliente>();
        private Guid? idSeleccionado = null;
        public UC_Clientes()
        {
            InitializeComponent();
            ConfigurarGrids();
            CargarDatos();
        }

        private void ConfigurarGrids()
        {
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.ReadOnly = true;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvHistorial.ReadOnly = true;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public async void CargarDatos()
        {
            // Traemos todo de un solo para procesar en memoria (más rápido en C# que pedir uno por uno)
            var todosLosClientes = await _service.GetAllAsync<Cliente>("Cliente");
            var todasLasVentas = await _service.GetAllAsync<Compra>("Compra");

            foreach (var cliente in todosLosClientes)
            {
                // Contamos cuántas ventas tiene asociadas este ID de cliente
                int totalCompras = todasLasVentas.Count(v => v.ClienteId == cliente.Id);

                // Aplicamos la jerarquía de poder
                if (totalCompras >= 250) cliente.Nivel = "Rubí 🔴";
                else if (totalCompras >= 200) cliente.Nivel = "Esmeralda 🟢";
                else if (totalCompras >= 150) cliente.Nivel = "Diamante 💎";
                else if (totalCompras >= 100) cliente.Nivel = "Oro 🏆";
                else if (totalCompras >= 50) cliente.Nivel = "Plata 🥈";
                else cliente.Nivel = "Bronce 🥉";
            }

            listaClientes = todosLosClientes;
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = listaClientes;
        }

        private async void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var cliente = (Cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;

            idSeleccionado = cliente.Id;
            txtNombre.Text = cliente.Nombre;
            txtApellidos.Text = cliente.Apellidos;
            txtCorreo.Text = cliente.Correo;

            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;

            // Cargamos el historial de este cliente específico
            await CargarHistorial(cliente.Id);
        }

        private async Task CargarHistorial(Guid clienteId)
        {
            var todasLasCompras = await _service.GetAllAsync<Compra>("Compra");

            var historial = todasLasCompras
                .Where(c => c.ClienteId == clienteId)
                .OrderByDescending(c => c.Fecha)
                .Select(c => new {
                    c.Fecha,
                    Subtotal = "C$ " + c.Subtotal.ToString("N2"),
                    IVA = "C$ " + c.Iva.ToString("N2"),
                    Total = "C$ " + c.Total.ToString("N2")
                })
                .ToList();

            

            dgvHistorial.DataSource = null;
            dgvHistorial.DataSource = historial;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio, dog.");
                return;
            }

            var nuevo = new Cliente
            {
                Id = Guid.NewGuid(),
                Nombre = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                Correo = txtCorreo.Text,
                // El nivel no se manda aquí porque el modelo ya tiene "Bronce" por defecto
                // y se recalcula dinámicamente al cargar la tabla.
                Preferencias = new List<string>()
            };

            if (await _service.CreateAsync("Cliente", nuevo))
            {
                MessageBox.Show("Cliente guardado con éxito.");
                LimpiarTodo();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null) return;

            var modificado = new Cliente
            {
                Id = idSeleccionado.Value,
                Nombre = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                Correo = txtCorreo.Text,
                
            };

            if (await _service.UpdateAsync("Cliente", idSeleccionado.Value, modificado))
            {
                MessageBox.Show("Cliente actualizado.");
                LimpiarTodo();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Seleccioná un cliente."
                    );

                    return;
                }

                var cliente =
                    dgvClientes.CurrentRow.DataBoundItem
                    as Cliente;

                if (cliente == null)
                    return;

                var r = MessageBox.Show(
                    $"¿Eliminar a {cliente.Nombre}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (r != DialogResult.Yes)
                    return;

                bool ok =
                    await _service.DeleteAsync(
                        "Cliente",
                        cliente.Id
                    );

                if (!ok)
                {
                    MessageBox.Show(
                        "No se pudo eliminar."
                    );

                    return;
                }

                MessageBox.Show(
                    "Cliente eliminado."
                );

                // REFRESCAR GRID
                ConfigurarGrids();

                // LIMPIAR HISTORIAL
                dgvHistorial.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error:\n{ex.Message}"
                );
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)=>LimpiarTodo();

        private void LimpiarTodo()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtCorreo.Clear();
            txtBuscar.Clear();
            idSeleccionado = null;
            dgvHistorial.DataSource = null;
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            CargarDatos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string b = txtBuscar.Text.ToLower();
            dgvClientes.DataSource = listaClientes
                .Where(c => c.Nombre.ToLower().Contains(b) || c.Apellidos.ToLower().Contains(b))
                .ToList();
        }
    }
}

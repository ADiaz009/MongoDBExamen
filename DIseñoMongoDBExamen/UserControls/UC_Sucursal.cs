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
    public partial class UC_Sucursal : UserControl
    {
        private DataService _service = new DataService();
        private List<Sucursal> listaSucursales = new List<Sucursal>();
        private Guid? idSeleccionado = null;
        public UC_Sucursal()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarDatos();
        }

        private void ConfigurarGrid()
        {
            dgvSucursal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSucursal.MultiSelect = false;
            dgvSucursal.ReadOnly = true;
            dgvSucursal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void CargarDatos()
        {
            listaSucursales = await _service.GetAllAsync<Sucursal>("Sucursal");
            dgvSucursal.DataSource = null;
            dgvSucursal.DataSource = listaSucursales;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string b = txtBuscar.Text.ToLower();
            var filtrados = listaSucursales
                .Where(s => s.Nombre.ToLower().Contains(b) ||
                            s.Ubicacion.ToLower().Contains(b) ||
                            s.Region.ToLower().Contains(b))
                .ToList();

            dgvSucursal.DataSource = null;
            dgvSucursal.DataSource = filtrados;
        }

        private void dgvSucursales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var sucursal = (Sucursal)dgvSucursal.Rows[e.RowIndex].DataBoundItem;

            idSeleccionado = sucursal.Id;
            txtNombreSucursal.Text = sucursal.Nombre;
            txtUbicacion.Text = sucursal.Ubicacion;
            txtTelefono.Text = sucursal.Telefono;
            txtRegion.Text = sucursal.Region; // Campo nuevo

            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreSucursal.Text)) return;

            var nueva = new Sucursal
            {
                Id = Guid.NewGuid(),
                Nombre = txtNombreSucursal.Text,
                Ubicacion = txtUbicacion.Text,
                Telefono = txtTelefono.Text,
                Region = txtRegion.Text
            };

            if (await _service.CreateAsync("Sucursal", nueva))
            {
                MessageBox.Show("Sucursal agregada con éxito.");
                LimpiarTodo();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null) return;

            var modificada = new Sucursal
            {
                Id = idSeleccionado.Value,
                Nombre = txtNombreSucursal.Text,
                Ubicacion = txtUbicacion.Text,
                Telefono = txtTelefono.Text,
                Region = txtRegion.Text
            };

            if (await _service.UpdateAsync("Sucursal", idSeleccionado.Value, modificada))
            {
                MessageBox.Show("Sucursal actualizada.");
                LimpiarTodo();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null) return;

            if (MessageBox.Show("¿Borrar sucursal?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (await _service.DeleteAsync("Sucursal", idSeleccionado.Value))
                {
                    LimpiarTodo();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        private void LimpiarTodo()
        {
            txtNombreSucursal.Clear();
            txtUbicacion.Clear();
            txtTelefono.Clear();
            txtRegion.Clear();
            txtBuscar.Clear();

            idSeleccionado = null;
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;

            CargarDatos();
        }
    }
}

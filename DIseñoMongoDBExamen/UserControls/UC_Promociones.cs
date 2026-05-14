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
    public partial class UC_Promociones : UserControl
    {
        private DataService _service = new DataService();
        private List<Promocion> listaPromos = new List<Promocion>();
        private Guid? idSeleccionado = null;
        public UC_Promociones()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarCatalogos();
            CargarDatos();
        }

        private void ConfigurarGrid()
        {
            dgvPromociones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPromociones.ReadOnly = true;
            dgvPromociones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPromociones.AllowUserToAddRows = false;
        }

        private void CargarCatalogos()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new string[] { "Todas", "Bronce 🥉", "Plata 🥈", "Oro 🏆", "Diamante 💎", "Esmeralda 🟢", "Rubí 🔴" });
            cmbCategoria.SelectedIndex = 0;
        }

        public async void CargarDatos()
        {
            // 1. Traemos la data cruda de la API
            var datosDB = await _service.GetAllAsync<Promocion>("Promocion");
            DateTime hoy = DateTime.Now;
            bool huboActualizacion = false;

            // 2. Lógica de expiración automática
            foreach (var promo in datosDB)
            {
                // Si la promo debería estar inactiva por fecha pero sigue marcada como Activa
                if (promo.Activa && hoy > promo.FechaFin)
                {
                    promo.Activa = false;
                    // Mandamos el update a la API para que se guarde el cambio en Mongo
                    await _service.UpdateAsync("Promocion", promo.Id, promo);
                    huboActualizacion = true;
                }
            }

            // 3. Si actualizamos algo, volvemos a traer la lista limpia; si no, usamos la que ya tenemos
            listaPromos = huboActualizacion ? await _service.GetAllAsync<Promocion>("Promocion") : datosDB;

            dgvPromociones.DataSource = null;
            dgvPromociones.DataSource = listaPromos;

            if (dgvPromociones.Columns["Id"] != null) dgvPromociones.Columns["Id"].Visible = false;
        }

       

        

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

       

        private async void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || !decimal.TryParse(txtDescuento.Text, out decimal desc))
            {
                MessageBox.Show("Rellená los campos obligatorios, brother.");
                return;
            }

            var nueva = new Promocion
            {
                Id = Guid.NewGuid(),
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                PorcentajeDescuento = desc,
                FechaInicio = dtpInicio.Value,
                FechaFin = dtpFin.Value,
                CategoriaObjetivo = cmbCategoria.Text,
                Activa = chkActiva.Checked
            };

            if (await _service.CreateAsync("Promocion", nueva))
            {
                MessageBox.Show("Promoción guardada exitosamente.");
                LimpiarTodo();
            }
        }

        private void dgvPromociones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var promo = (Promocion)dgvPromociones.Rows[e.RowIndex].DataBoundItem;
            idSeleccionado = promo.Id;

            txtNombre.Text = promo.Nombre;
            txtDescripcion.Text = promo.Descripcion;
            txtDescuento.Text = promo.PorcentajeDescuento.ToString();
            dtpInicio.Value = promo.FechaInicio;
            dtpFin.Value = promo.FechaFin;
            cmbCategoria.SelectedItem = promo.CategoriaObjetivo;
            chkActiva.Checked = promo.Activa;

            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null) return;

            var modificado = new Promocion
            {
                Id = idSeleccionado.Value,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                PorcentajeDescuento = decimal.Parse(txtDescuento.Text),
                FechaInicio = dtpInicio.Value,
                FechaFin = dtpFin.Value,
                CategoriaObjetivo = cmbCategoria.Text,
                Activa = chkActiva.Checked
            };

            if (await _service.UpdateAsync("Promocion", idSeleccionado.Value, modificado))
            {
                MessageBox.Show("Promoción actualizada.");
                LimpiarTodo();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null)
            {
                MessageBox.Show("Seleccioná una promoción del grid para eliminarla, brother.", "Aviso");
                return;
            }

            // Pedimos confirmación para que no borren por error
            var confirmacion = MessageBox.Show("¿Estás seguro de eliminar esta promo? Esta acción no se puede deshacer.",
                                              "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                if (await _service.DeleteAsync("Promocion", idSeleccionado.Value))
                {
                    MessageBox.Show("Promoción borrada de MongoDB.");
                    LimpiarTodo(); // Esto refresca el grid automáticamente
                }
                else
                {
                    MessageBox.Show("Error al intentar eliminar. Revisá la API.", "Error");
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        private void LimpiarTodo()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtDescuento.Clear();
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now.AddDays(7);
            cmbCategoria.SelectedIndex = 0;
            chkActiva.Checked = true;
            idSeleccionado = null;
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            CargarDatos();
        }
    }
}

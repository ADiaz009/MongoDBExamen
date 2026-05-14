using DIseñoMongoDBExamen.Forms;
using DIseñoMongoDBExamen.Models;
using DIseñoMongoDBExamen.Services;

namespace DIseñoMongoDBExamen
{
    public partial class Form1 : Form
    {
        private readonly DataService _service = new DataService();
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // 1. Llamamos a tu método existente
            var usuario = await _service.LoginAsync(txtNombreUsuario.Text, txtContraseña.Text);

            if (usuario != null)
            {
                // Guardamos el objeto en tu AuthService
                AuthService.UsuarioActual = usuario;

                // 2. Intentamos obtener el nombre de la sucursal desde la base de datos
                // ya que el objeto 'usuario' no lo trae.
                string nombreSucursal = "Cargando...";
                try
                {
                    var sucursales = await _service.GetAllAsync<Sucursal>("Sucursal");
                    var miSucursal = sucursales.FirstOrDefault(s => s.Id == usuario.SucursalId);
                    nombreSucursal = miSucursal?.Nombre ?? "Sede Central";
                }
                catch { nombreSucursal = "Sede Particular"; }

                // 3. Llenamos la sesión estática (UserSession) para que el FormMenu lea estos datos
                UserSession.Nombre = usuario.NombreUsuario;
                UserSession.Rol = usuario.Rol;
                UserSession.SucursalId = usuario.SucursalId;
                UserSession.SucursalNombre = nombreSucursal; // <--- Aquí ya no dará error

                // 4. Salto al Menú
                this.Hide();
                Form2 menu = new Form2();
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }
    }
}

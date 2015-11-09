using ProyectoFinal.Aplicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Escritorio
{
    public partial class Login : Form

    {

        private readonly UsuarioAppService _usuarioAppService;
        
        public readonly EmpresaAppService _empresaAppService;



        public Login(UsuarioAppService usuarioAppService,  EmpresaAppService empresaAppService)
        {
            _usuarioAppService = usuarioAppService;
            _empresaAppService = empresaAppService;
            InitializeComponent();
        }

        //Mostrar mensaje de Confirmacion

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Proyecto Final", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        // Mostrar mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Proyecto Final", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            var user = 1;// _usuarioAppService.BuscarUsuario(usuario, password, Convert.ToInt32(this.cmbEmpresa.ValueMember));

            if (user != null)
            {

                MensajeOk("Usuario encontrado");

                CompositionRoot.Wire(new ProductoModule());


                Application.EnableVisualStyles();

               
                Application.Run(CompositionRoot.Resolve<Productos>());
                
            }
            else
            {

                MensajeError("Usuario encontrado");

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            
            this.StartPosition = FormStartPosition.CenterParent;
            LlenarComboEmpresa();
        }

        public void LlenarComboEmpresa()
        {
            this.cmbEmpresa.DataSource = _empresaAppService.ObtenerTodo().ToList();

            cmbEmpresa.ValueMember = "Id";
            cmbEmpresa.DisplayMember = "Descripcion";
        }
    }
}

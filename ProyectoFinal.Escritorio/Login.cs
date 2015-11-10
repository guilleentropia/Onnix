using ProyectoFinal.Aplicacion;
using ProyectoFinal.Aplicacion.Interface;
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

        private readonly ProductoAppService _productoAppservice;
        private readonly CategoriaAppService _categoriaAppservice;
        private readonly MarcaAppService _marcaAppservice;
        private readonly TerceroAppService _terceroAppservice;

        public Login(UsuarioAppService usuarioAppService,  EmpresaAppService empresaAppService,
            ProductoAppService productoAppservice, CategoriaAppService categoriaAppservice, MarcaAppService marcaAppservice,
            TerceroAppService terceroAppservice)
        {
            InitializeComponent();
            _usuarioAppService = usuarioAppService;
            _empresaAppService = empresaAppService;
            _productoAppservice = productoAppservice;
            _categoriaAppservice = categoriaAppservice;
            _marcaAppservice = marcaAppservice;
            _terceroAppservice = terceroAppservice;
           
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
            string usuario = this.txtUsuario.Text;
            string password = this.txtPassword.Text;
            int empresa = Convert.ToInt32(this.cmbEmpresa.SelectedValue);

            var user =  _usuarioAppService.BuscarUsuario(usuario, password, empresa );

            if (user != null)
            {


                MensajeOk("Bienvenido!");
                                

                var a =  CompositionRoot.Resolve<Productos>();
                a.ShowDialog();
                
                               
            }
            else
            {

                MensajeError("Usuario no encontrado");

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

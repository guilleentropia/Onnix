using ProyectoFinal.Aplicacion;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Infraestructura.Datos.Repositorios;
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
    public partial class Productos : Form
    {
        private bool IsNuevo = false;
        private bool IsModificar = false;
        private readonly IProductoAppService _productoAppservice;
        private readonly ICategoriaAppService _categoriaAppservice;
        private readonly IMarcaAppService _marcaAppservice;
        private readonly ITerceroAppService _terceroAppservice;

        public Productos(ProductoAppService productoAppservice, CategoriaAppService categoriaAppservice, MarcaAppService marcaAppservice,
            TerceroAppService terceroAppservice)
        {
            InitializeComponent();
            _productoAppservice = productoAppservice;
            _categoriaAppservice = categoriaAppservice;
            _marcaAppservice = marcaAppservice;
            _terceroAppservice = terceroAppservice;
           
        }


        
       
        private void Mostrar()
        {
            var contenedor = _productoAppservice.ObtenerTodo().ToList();

            

            foreach(var item in contenedor){
                
                dgvProductos.CurrentCell.Value = item.Id;
                dgvProductos.CurrentCell.Value = item.Codigo;
               
            } 
            
            
            
        }
        private void Productos_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.OcultarColumnas();
            
            this.Habilitar(false);
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

        private void Habilitar(bool valor)
        {
            this.combo_Categoria.Enabled = valor;
            this.combo_tercero.Enabled = valor;
            this.comboMarca.Enabled = valor;
            this.txtCodigo.Enabled = valor;
            this.txtCompra.Enabled = valor;
            this.txtDescripcion.Enabled = valor;
            this.txtTalle.Enabled = valor;
            this.txtVenta.Enabled = valor;
            this.txtStock.Enabled = valor;
            this.btnCancelar.Enabled = valor;
            this.btnGuardar.Enabled = valor;
            this.btnModificar.Enabled = valor;
            this.btnExaminar.Enabled = valor;
            this.btnNuevo.Enabled = !valor;
        }



        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtCompra.Text =string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtStock.Text =string.Empty;
            this.txtTalle.Text =string.Empty;
            this.txtVenta.Text = string.Empty;
            this.picImagen.Image = null;


        }

        private void OcultarColumnas()
        {
            this.dgvProductos.Columns[0].Visible = false;
            this.dgvProductos.Columns[1].Width = 60;
            this.dgvProductos.Columns[2].HeaderText = "Producto";
            this.dgvProductos.Columns[2].Width = 230;
            this.dgvProductos.Columns[3].HeaderText = "Compra";
            this.dgvProductos.Columns[3].Width = 60;
            this.dgvProductos.Columns[4].HeaderText = "Venta";
            this.dgvProductos.Columns[4].Width = 60;
            this.dgvProductos.Columns[5].Width = 50;
            this.dgvProductos.Columns[6].Width = 50;
            this.dgvProductos.Columns[7].Visible = false;
            this.dgvProductos.Columns[8].Visible = false;
            this.dgvProductos.Columns[9].Visible = false;
            this.dgvProductos.Columns[10].Visible = false;
            this.dgvProductos.Columns[11].Visible = false;
            this.dgvProductos.Columns[12].Visible = false;
            this.dgvProductos.Columns[13].Visible = false; 
            
            
        }

        public void LlenarComboCategoria()
        {
            this.combo_Categoria.DataSource = _categoriaAppservice.ObtenerTodo().ToList();

            combo_Categoria.ValueMember = "Id";
            combo_Categoria.DisplayMember = "Descripcion";
        }

        public void LlenarComboMarca()
        {
            this.comboMarca.DataSource = _marcaAppservice.ObtenerTodo().ToList();

            comboMarca.ValueMember = "Id";
            comboMarca.DisplayMember = "Descripcion";
        }


        public void LlenarComboTercero()
        {
            this.combo_tercero.DataSource = _terceroAppservice.ObtenerTodo().ToList();

            combo_tercero.ValueMember = "Id";
            combo_tercero.DisplayMember = "Apellido";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            this.txtId.Text = Convert.ToString(this.dgvProductos.CurrentRow.Cells["Id"].Value);
            this.txtTalle.Text = Convert.ToString(this.dgvProductos.CurrentRow.Cells["Talle"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dgvProductos.CurrentRow.Cells["Codigo"].Value);
            this.txtStock.Text = Convert.ToString(this.dgvProductos.CurrentRow.Cells["Stock"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dgvProductos.CurrentRow.Cells["Descripcion"].Value);
            this.combo_Categoria.DisplayMember = Convert.ToString(this.dgvProductos.CurrentRow.Cells["CategoriaProducto"].Value);
            this.comboMarca.DisplayMember = Convert.ToString(this.dgvProductos.CurrentRow.Cells["MarcaProducto"].Value);
            this.combo_tercero.DisplayMember = Convert.ToString(this.dgvProductos.CurrentRow.Cells["TerceroProducto"].Value);


            byte[] imagenbuffer = (byte[])this.dgvProductos.CurrentRow.Cells["Imagen"].Value;
            if (imagenbuffer != null)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenbuffer);
                this.picImagen.Image = Image.FromStream(ms);
            }
            

            this.txtCompra.Text = Convert.ToString(this.dgvProductos.CurrentRow.Cells["PrecioCompra"].Value);
            this.txtVenta.Text = Convert.ToString(this.dgvProductos.CurrentRow.Cells["PrecioVenta"].Value);

            this.tabControl1.SelectedIndex = 1;

            if (dgvProductos.CurrentRow != null)
            {
                this.btnModificar.Enabled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.txtCodigo.Text == string.Empty || this.txtCompra.Text ==string.Empty 
                    || this.txtDescripcion.Text == string.Empty || this.txtStock.Text ==string.Empty
                    || this.txtTalle.Text ==string.Empty || this.txtVenta.Text ==string.Empty)
                {
                    MensajeError("Faltan ingresar algunos datos, observe las alertas");

                    if (this.txtCodigo.Text == string.Empty)
                    {
                        ErrorProvider.SetError(txtCodigo, "Ingrese el Codigo");
                    }

                    if (this.txtCompra.Text == string.Empty)
                    {
                        ErrorProvider.SetError(txtCompra, "Ingrese el Precio de Compra");
                    }

                    if (this.txtDescripcion.Text == string.Empty)
                    {
                        ErrorProvider.SetError(txtDescripcion, "Ingrese el Nombre del Producto");
                    }

                    if (this.txtStock.Text == string.Empty)
                    {
                        ErrorProvider.SetError(txtStock, "Ingrese el Stock del Producto");
                    }

                    if (this.txtTalle.Text == string.Empty)
                    {
                        ErrorProvider.SetError(txtTalle, "Ingrese el Talle del Producto");
                    }

                    if (this.txtVenta.Text == string.Empty)
                    {
                        ErrorProvider.SetError(txtVenta, "Ingrese el Precio de Venta");
                    }
                    
                    


                }
                else
                {

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.picImagen.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();

                    if (this.IsNuevo)
                    {
                        Producto nuevo = new Producto();

                        nuevo.Codigo = Convert.ToInt32(this.txtCodigo.Text);
                        nuevo.Descripcion = this.txtDescripcion.Text;
                        nuevo.PrecioCompra = Convert.ToDouble(this.txtCompra.Text);
                        nuevo.PrecioVenta = Convert.ToDouble(this.txtVenta.Text);
                        nuevo.Talle = this.txtTalle.Text;
                        nuevo.Stock = Convert.ToInt32(this.txtStock.Text);
                        nuevo.MarcaId = Convert.ToInt32(this.comboMarca.SelectedValue);
                        nuevo.TerceroId = Convert.ToInt32(this.combo_tercero.SelectedValue);
                        nuevo.CategoriaId = Convert.ToInt32(this.combo_Categoria.SelectedValue);

                        if (imagen != null)
                        {
                            nuevo.Imagen = imagen;
                            _productoAppservice.Agregar(nuevo);
                            MensajeOk("Se grabó el producto correctamente");
                        }
                        else
                        {
                            MensajeError("Elija una imagen para el producto");
                        }
                        


                        
                    }

                    else if (this.IsModificar)
                    {
                        Producto modificar = new Producto();
                        modificar = _productoAppservice.BuscarporId(Convert.ToInt32(this.txtId.Text));


                        modificar.Codigo = Convert.ToInt32(this.txtCodigo.Text);
                        modificar.Descripcion = this.txtDescripcion.Text;
                        modificar.PrecioCompra = Convert.ToDouble(this.txtCompra.Text);
                        modificar.PrecioVenta = Convert.ToDouble(this.txtVenta.Text);
                        modificar.Talle = this.txtTalle.Text;
                        modificar.Stock = Convert.ToInt32(this.txtStock.Text);
                        modificar.MarcaId = Convert.ToInt32(this.comboMarca.SelectedValue);
                        modificar.TerceroId = Convert.ToInt32(this.combo_tercero.SelectedValue);
                        modificar.CategoriaId = Convert.ToInt32(this.combo_Categoria.SelectedValue);

                        if (imagen != null)
                        {
                            modificar.Imagen = imagen;
                        }

                        _productoAppservice.Actualizar(modificar);


                        MensajeOk("Se actualizó el producto correctamente");


                    }

                    this.Limpiar();
                    this.Mostrar();
                    this.dgvProductos.Enabled = true;
                    this.tabControl1.TabIndex = 1;
                    this.Habilitar(false);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsModificar = false;
            this.Habilitar(true);
            this.LlenarComboCategoria();
            this.LlenarComboMarca();
            this.LlenarComboTercero();
            this.Limpiar();
        }

        // Validacion de los tipos de datos ingresados en los controles

        private void txtTalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.txtId.Text.Equals(""))
            {
                this.IsModificar = true;
                this.Habilitar(true);
                this.btnModificar.Enabled = false;
            }
            else
            {
                MensajeError("Debe seleccionar primero el registro a modificar");
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.picImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.picImagen.Image = Image.FromFile(dialog.FileName);


            }
        }

      



        

       

    }
}

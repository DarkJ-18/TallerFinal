using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONTROLADOR.DatosFarmacia;


namespace TallerFinal
{
    public partial class Menu : Form
    {
        ProductosDTO productosDTO = null;
        ProductosDAO productosDAO = null;
        DataTable Dtt = null;


        public Menu()
        {
            InitializeComponent();
            ListarProductos();
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;

        }

       public void ListarProductos()
       {
            productosDTO = new ProductosDTO();
            productosDAO = new ProductosDAO(productosDTO);

            Dtt = new DataTable();
            Dtt = productosDAO.ListarProductos();

            if (Dtt.Rows.Count > 0)
            {
                dtproductos.DataSource = Dtt;
            }
            else
            {
                MessageBox.Show("No hay registros de productos");
                label7.Visible = true;
                txtid.Visible = true;
               

            }

       }

        public void GuardarProductos()
        {
            productosDTO = new ProductosDTO();
            productosDTO.setNombre(txtnombre.Text);
            productosDTO.setDescripcion(txtdescripcion.Text);
            productosDTO.setPrecio(Convert.ToInt32(txtprecio.Text));
            productosDTO.setStock(Convert.ToInt32(txtstock.Text));

            productosDAO = new ProductosDAO(productosDTO);

            productosDAO.GuardarProductos();
            MessageBox.Show("Producto Guardado.");
        }

        public void GuardarCambiosProductos()
        {
            productosDTO = new ProductosDTO();
            productosDTO.setId(Convert.ToInt32(txtid.Text));
            productosDTO.setNombre(txtnombre.Text);
            productosDTO.setDescripcion(txtdescripcion.Text);
            productosDTO.setPrecio(Convert.ToInt32(txtprecio.Text));
            productosDTO.setStock(Convert.ToInt32(txtstock.Text));
            productosDAO = new ProductosDAO(productosDTO);

            productosDAO.GuardarCambiosProductos();
            MessageBox.Show("Producto Modificado");

        }



        public void EliminarProducto()
        {
            productosDTO = new ProductosDTO();
            productosDTO.setId(Convert.ToInt32(txtid.Text));
            productosDAO = new ProductosDAO(productosDTO);

            productosDAO.EliminarProducto();
            MessageBox.Show("Producto Eliminado.");
        }

        

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            ListarProductos();

            label7.Visible = false;
            txtid.Visible = false;
            btnguardarcambios.Enabled = false;
            btnguardar.Enabled = true;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
           
            txtstock.Clear();
            txtnombre.Focus();
            LimpiarCampos();
        }

        private void Btneliminar_Click(object sender, EventArgs e)
        {
            EliminarProducto();

            ListarProductos();
            label7.Visible = false;
            txtid.Visible = false;
            btnguardarcambios.Enabled = false;
            btnguardar.Enabled = true;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
            LimpiarCampos();
            txtnombre.Clear();
            txtnombre.Focus();
        }

        private void Dtproductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label7.Visible = true;
            txtid.Visible = true;
            txtid.Enabled = false;

            txtid.Text = dtproductos.Rows[dtproductos.CurrentRow.Index].Cells[0].Value.ToString();
            txtnombre.Text = dtproductos.Rows[dtproductos.CurrentRow.Index].Cells[1].Value.ToString();
            txtdescripcion.Text = dtproductos.Rows[dtproductos.CurrentRow.Index].Cells[2].Value.ToString();
            txtprecio.Text = dtproductos.Rows[dtproductos.CurrentRow.Index].Cells[3].Value.ToString();
            txtstock.Text= dtproductos.Rows[dtproductos.CurrentRow.Index].Cells[4].Value.ToString();


            btnguardarcambios.Enabled = true;
            btnguardar.Enabled = false;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    
        public void LimpiarCampos()
        {
            txtid.Clear();
            txtnombre.Clear();
            txtdescripcion.Clear();
            txtprecio.Clear();
            txtstock.Clear();
        }

        private void Btnguardarcambios_Click_1(object sender, EventArgs e)
        {
            if (txtnombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingresa Un Producto.");
            }
            else
            {
                GuardarCambiosProductos();
                ListarProductos();

                txtid.Visible = false;
                txtid.Visible = false;
                btnguardarcambios.Enabled = false;
                btnguardar.Enabled = true;
                btneliminar.Enabled = false;
                btncancelar.Enabled = false;
                LimpiarCampos();
                txtnombre.Clear();
                txtnombre.Focus();
            }
        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingresa Un Producto.");
                txtnombre.Focus();
            }
            else
            {
                GuardarProductos();
                ListarProductos();


                txtnombre.Clear();
                txtnombre.Focus();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {

            Validacion.validacionNumerica(sender, e);
        }

        private void txtstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.validacionNumerica(sender, e);
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.validacionNumerica(sender, e);
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.validacionLetras(sender, e);
        }

        private void txtdescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.validacionLetras(sender, e);
        }
    }
}
